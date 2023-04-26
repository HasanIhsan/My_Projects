using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.IO;

namespace GamerLib
{

    /*
     * Interface Name: IDrawingServiceCallback
     * Purpose: This code defines an interface called "IDrawingServiceCallback". 
     *          An interface in C# is a contract that defines a set of methods and properties that a class must implement.
     */

    public interface IDrawingServiceCallback
    {

        //"ReceiveDrawingCommand" is a method that takes a "DrawingCommand" object as a parameter. 
        [OperationContract(IsOneWay = true)]
        void ReceiveDrawingCommand(DrawingCommand command);

        //"SendAllMessages" is a method that takes an array of strings as a parameter.
        [OperationContract(IsOneWay = true)]
        void SendAllMessages(string[] messages);

        //"ReceiveClearCanvas" is a method that has no parameters.
        [OperationContract(IsOneWay = true)] 
        void ReceiveClearCanvas();
        [OperationContract(IsOneWay = true)]

        //"RecieveAWord" is a method that takes a string parameter called "word".
        void RecieveAWord(string word);

        //"RecieveGameOver" is a method that takes a string parameter called "playername".
        [OperationContract(IsOneWay = true)]
        void RecieveGameOver(string playername);

        //"RecieveCurrentPlayerTurn" is a method that takes a string parameter called "playername"
        [OperationContract(IsOneWay = true)]
        void RecieveCurrentPlayerTurn(string playername);

    }

    /*
     * Interface Name: IDrawingService
     * Purpose: This code defines an interface called "IDrawingService". 
     *          An interface in C# is a contract that defines a set of methods and properties that a class must implement.
     */
    [ServiceContract(CallbackContract = typeof(IDrawingServiceCallback))]
    public interface IDrawingService
    {
        //"RegisterForDrawingService" is a method that takes a string parameter called "name" and returns a boolean. 
        //This method is used to register a client for the drawing service.
        [OperationContract]
        bool RegisterForDrawingService(string name);

        //"UnRegisterForDrawingService" is a method that takes a string parameter called "name".
        //This method is used to unregister a client from the drawing service.
        [OperationContract(IsOneWay = true)]
        void UnRegisterForDrawingService(string name);

        //"AddDrawingCommand" is a method that takes a "DrawingCommand" object as a parameter and returns a boolean.
        //This method is used to add a new drawing command to the service.
        [OperationContract]
        bool AddDrawingCommand(DrawingCommand command);

        //"CanDraw" is a method that returns a boolean. This method is used to determine if the client is currently able to draw.
        [OperationContract]
        bool CanDraw();

        //"CurrentPlayerTurn" is a method that returns a boolean, This method is used to detemine who the current player is
        [OperationContract(IsOneWay = true)]
        void CurrentPlayerTurn();

        //"TurnComplete" is a method  used to indicate that the client has completed its turn.
        [OperationContract]
        void TurnComplete();

        //"PostMessage" is a method that takes a string parameter called "message". This method is used to post a message to the drawing service.
        [OperationContract(IsOneWay = true)]
        void PostMessage(string message);

        //"GetAllMessages" is a method that returns an array of strings. This method is used to retrieve all messages posted to the drawing service.
        [OperationContract]
        string[] GetAllMessages();

        //"ClearCanvas" is a method with no parameters. This method is used to clear the drawing canvas.
        [OperationContract(IsOneWay = true)]
        void ClearCanvas();

        //"GetAWord" is a method used to retrieve a word from the drawing service.
        [OperationContract(IsOneWay = true)]
        void GetAWord();

        //"GameOver" is a method that returns a boolean. This method is used to indicate if the game is over.
        [OperationContract]
        bool GameOver();

    }

    /*
     * Class Name: DrawingService
     * Purpose: contains all the definitions for the Iterface methods and more
     */
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class DrawingService : IDrawingService
    {
        //callback Dictionary with client name and callbacks
        private readonly Dictionary<string, IDrawingServiceCallback> _callbacks = new Dictionary<string, IDrawingServiceCallback>();

       
        // list of players (name, count)
        // list of Drawing commands
        // list of player messages
        private readonly List<Player> _players = new List<Player>();
        private readonly List<DrawingCommand> _pendingCommands = new List<DrawingCommand>();
        private readonly List<string> _messages = new List<string>();
    
        // Timer
        private readonly Timer _broadcastTimer;

        // Current player name, player index, player points
        private string _currentPlayer = "";
        private int _currentPlayerIndex = -1;
        private int _currentPlayerPontsToEarn = 5; //can only earn 5 points
        private int _currentPlayerPointsToEndGame = 10; //points needed to win
        private string _currentImageToDraw = "";
       
        //words deserialization with newtonsoft (I put all the words into a json file cause it would just be eaiser to update it later if wanted)
        // Read the JSON file into a string   
        private const string DIR_EXT_JSON_DATA_FILE = "../../data/words.json";
        List<string> _wordToDraw = new List<string>();

        /*
         * Method Name: Default constructor
         * Purpose: Initilalizes the timer and desealizes the json data that stores words 
         */
        public DrawingService()
        {
            // Create a timer to broadcast pending commands every 5000 milliseconds.
            _broadcastTimer = new Timer(BroadcastPendingCommands, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(5000));
            
            //get json data
            DesealizeJsonData();
 
        }

        /*
         * Method Name: RegisterForDrawingService
         * Purpose: Registers a client for the drawing service.
         * Parameters:
         *      - name: a string representing the user alias
         * Returns: 
         *      - true if the registration was successful, false otherwise.
         */
        public bool RegisterForDrawingService(string name)
        {
            // Check if user alias is already registered
            if (_callbacks.ContainsKey(name.ToUpper()))
            {
                // User alias must be unique
                return false;
            }
            else
            {
                Console.WriteLine(_callbacks.Count);
                Console.WriteLine(_players.Count);
                // Get the callback channel for the client
                IDrawingServiceCallback cb = OperationContext.Current.GetCallbackChannel<IDrawingServiceCallback>();
                // Add the callback channel to the callbacks dictionary
                _callbacks.Add(name.ToUpper(), cb);

                // Add the player to the players list with score 0
                _players.Add(new Player(name, 0));
                // Add a message to the messages list indicating that the player has joined the game
                _messages.Add($"{name} has joined the game");

                // If no player is currently drawing, set the current player index to 0 and add a message indicating that the player is up next to draw
                if (_currentPlayerIndex == -1)
                {
                    _currentPlayerIndex = 0;
                    _messages.Add($"{_players[_currentPlayerIndex].playerName} is up next to draw");
                }

                

                // Registration successful
                return true;
            }
        }


        /*
         * Method Name: UnRegisterForDrawingService
         * Purpose: Unregister a user from the drawing service and notify all other users
         * Parameters:
         *      - name: a string representing the user alias
         */
        public void UnRegisterForDrawingService(string name)
        {
            Player playerToRemove = _players.FirstOrDefault(player => player.playerName == name);
            // Check if user alias is registered
            if (_callbacks.ContainsKey(name.ToUpper()))  
            {
                // Remove the user's callback channel from the callbacks dictionary
                _callbacks.Remove(name.ToUpper());
                
                //remove player form _players list
                if (playerToRemove != null)
                {
                    _players.Remove(playerToRemove);
                }

                // Print a message indicating that the user has left the game to console
                Console.WriteLine($"{name} has Left the game!");  

                // Add a message to the message log indicating that the user has left the game
                _messages.Add($"{name} has Left the game!");

                CurrentPlayerTurn();
                

                // Update all users with the latest message log
                UpdateAllUsers();  
            }
        }


        /*
         * Method Name: CanDraw
         * Purpose: Check if it's the current player's turn to draw
         */
        public bool CanDraw()
        {
            //sets the current player variable 
            _currentPlayer = _players[_currentPlayerIndex].playerName;

            // Check if the callback channel for the current user matches the callback channel stored in the dictionary for the current player
            if (OperationContext.Current.GetCallbackChannel<IDrawingServiceCallback>() != _callbacks[_currentPlayer.ToUpper()])
            {
                // It's not the current player's turn to draw
                Console.WriteLine("It's not your turn to draw.");
                return false;
            }
            // If the callback channel matches, it's the current player's turn to draw
            return true;

        }


        /*
         * Method Name: ClearCanvas
         * Purpose: Clear the canvas on the server and notify all clients to clear their canvas
         */
        public void ClearCanvas()
        {
            // Clear the canvas on the serverstring word
            //this already gets cleared in the revice command 
            //but just incase we clear it here
            _pendingCommands.Clear();

            // Broadcast a message to all clients to clear their canvas
            foreach (var callback in _callbacks.Values)
            {
                callback.ReceiveClearCanvas();
            }
        }


        /*
         * Method Name: TurnComplete
         * Purpose: Move to the next player's turn
         */
        public void TurnComplete()
        {


            //next player turn
            //string currentPlayer = _users[_currentPlayerIndex];
            _currentPlayer = _players[_currentPlayerIndex].playerName;



            foreach (var callback in _callbacks)
            {
                // Checks if the callback.key(the player name) is equal to the current player name
                if (callback.Key.ToUpper() == _currentPlayer.ToUpper())
                {
                    // Move to the next player
                    _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;

                    //add message to tell players who is up next to draw
                    _messages.Add($"{_players[_currentPlayerIndex].playerName} is up next to draw");

                }
            }

            //UpdateAllUsers();
        }

        /*
         * Method Name: CurrentPlayerTurn
         * Purpose: checks whos turn it is
         */
        public void CurrentPlayerTurn()
        {
            // Get the name of the current player
             
                _currentPlayer = _players[_currentPlayerIndex].playerName;
           
             

            // Broadcast a message to all clients to clear their canvas
            foreach (var callback in _callbacks.Values)
            {
                callback.RecieveCurrentPlayerTurn(_currentPlayer);
            }
        }

        /*
         * Method Name: AddDrawingCommand
         * Purpose: Add a drawing command to the list of pending commands
         * Parameters: 
         *       - command: a DrawingCommand object representing the drawing command to add
         * Return:
         *       - true if the command was successfully added, false otherwise
         */
        public bool AddDrawingCommand(DrawingCommand command)
        {
             
            // Use a lock to ensure thread safety when modifying the pending commands list
            lock (_pendingCommands)
            {
                //add command to list of pending commands
                _pendingCommands.Add(command);
            }

            return true;
        }


        /*
         * Method Name: DesealizeJsonData
         * Purpose: Deserialize the JSON file containing a list of words to draw
         */
        public void DesealizeJsonData()
        {

            //read in json data
            string json = File.ReadAllText(DIR_EXT_JSON_DATA_FILE);

            // Deserialize the JSON string into a WordData object
            Word data = JsonConvert.DeserializeObject<Word>(json);

            // Access the list of words
            _wordToDraw = data.Words;
         
        }


        /* 
         * Method Name: GetAWord
         * Purpose: Gets a random word from the list of words to be drawn and notifies all clients about it
        */
        public void GetAWord()
        {
             
            //get a random value form list 
            Random random = new Random();
            
            //sets the word to a global variable
           _currentImageToDraw = _wordToDraw[random.Next(_wordToDraw.Count)];

            //shows the server console which word is going to be drawn
            Console.WriteLine("Draw: " + _currentImageToDraw);

            // Notify all clients about the word to be drawn
            foreach (var cb in _callbacks.Values)
            {
                cb.RecieveAWord(_currentImageToDraw);
            } 
        }


        /*
         * Method Name: CheckWordGuessed
         * Purpose: Checks the words from the list of messages
         */
        public void CheckWordGuessed()
        {

            // Get the name of the current player
            _currentPlayer = _players[_currentPlayerIndex].playerName;


            // Loop through all players and check if they guessed the current word
            // This is prob not the best implmentation but it works
            foreach (var player in _players)
            {
                // Construct the word to test by combining the player's name with the current word
                string wordToTest = $"[{player.playerName}] {_currentImageToDraw}";

                // Showing which message is being tested for to the console
                Console.WriteLine($"WORD TO TEST: {wordToTest}");

                // If the messages list contains the word, the player guessed correctly
                if (_messages.Contains(wordToTest))
                {

                    // Showing message correct word to server console
                    Console.WriteLine("Correct Word!");

                    //once the correct word is guessed update the players points (each player who is correct gets 5 points)
                    player.setPlayerPoints(_currentPlayerPontsToEarn);


                    // Call the NextRoundStart method to prepare for the next round
                    NextRoundStart();
                }
                
            }

            
        }


        /*
         * Method Name: NextEound
         * Purpose: Calls the methods needed to get the client ready for the next round
         * Return: 
         *     - true: simply just to avoid a infinte loop
         */
        public bool NextRoundStart()
        {
            //if user is correct

            //clear the chat message getting ready for next round:
            _messages.Clear();

            //get new word
            GetAWord();

            //clear the canvas
            ClearCanvas();

            //check if the a player has enough points to win!
            GameOver();
           

            //turn is complete going to next player
            TurnComplete();

            //this is not good but it works
            //the update all users calls this method. 
            UpdateAllUsers();

            //update the current player:
            CurrentPlayerTurn();

            //the return stop the potential infinte loop
            return true;
        }


        /*
         * Method Name: GameOver
         * Purpose: check if conditions are met to end the game
         * Return:
         *      - true: if the players points are equal to the points needed to win else return false
         */
        public bool GameOver()
        {
            // Iterate through each player
            foreach (var player in _players)
            {
                Console.WriteLine(player.playerPoints);
                // Check if the player's points are equal to the points required to end the game 
                if (player.playerPoints == _currentPlayerPointsToEndGame)
                {
                    //Prints Game over to the server console
                    Console.WriteLine("Game Over!");

                    //reset the player points (for all players)
                    player.setPlayerPoints(0);

                    // Notify all clients that the game has ended and which player has won
                    foreach (var cb in _callbacks.Values)
                    {
                        cb.RecieveGameOver(player.playerName);
                    }
                    return true;
                }

            }

            // Return false if the game has not ended
            return false;
        }


        /*
         * Method Name: PostMessage
         * Purpose: Adds a message to the _message array
         * Parameters: 
         *      - message: gets a string message
         */
        public void PostMessage(string message)
        {
            //Insert message to _messages
            _messages.Insert(0, message);

            //updates all clients (showing new message added)
            UpdateAllUsers();
        }


        /*
         * Method Name: GetAllMessages
         * Purpose: returns all the messages that have been sent during the game.
         */
        public string[] GetAllMessages()
        {
            return _messages.ToArray<string>();
        }


        /*
         * Method Name: UpdateAllUsers
         * Purpose: updates the users messages
         */
        private void UpdateAllUsers()
        {

            // Convert the list of messages to an array
            string[] msgs = _messages.ToArray<string>();

            // Send all messages to each client
            foreach (IDrawingServiceCallback cb in _callbacks.Values)
            {
                cb.SendAllMessages(msgs);
            }

            // Check if the correct word has been guessed (from the list of messages)
            CheckWordGuessed();
        }


        /*
         * Method Name: BroadcastPendingCommands
         * Purpose: Broadcasts the pending drawing commands to all connected clients
         */
        private void BroadcastPendingCommands(object state)
        {
            // Get a copy of the list of pending commands to broadcast and clear the original list.
            List<DrawingCommand> commandsToBroadcast;
            lock (_pendingCommands)
            {
                commandsToBroadcast = _pendingCommands.ToList();
                _pendingCommands.Clear();
            }

            // If there are pending commands, send them to all clients.
            if (commandsToBroadcast.Count > 0)
            {
                // Get the current player's name.
                string currentPlayer = _players[_currentPlayerIndex].playerName;

                // Send each command to each client's callback.
                foreach (var callback in _callbacks)
                {
                    foreach (var command in commandsToBroadcast)
                    {
                        callback.Value.ReceiveDrawingCommand(command);
                        Console.WriteLine(callback.Value + " " + currentPlayer);
                    }
                }
            }
        }


    }


}
