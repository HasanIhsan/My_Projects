using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.ServiceModel;
using GamerLib;
using Point = System.Windows.Point;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //[CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public partial class MainWindow : Window, IDrawingServiceCallback
    {

        private IDrawingService _drawingServiceClient = null;
      
        private List<DrawingPoints> _points = new List<DrawingPoints>();
        // private Point _start;
        //private DrawingPoints _startPoint;
        private bool _isDrawing;

        private bool _hasConnection = false;
        private string _userPrefix = "";
        public MainWindow()
        {
            InitializeComponent();

            //Hide the UI not until the user connects to game
            clear_drawing.Visibility = Visibility.Collapsed;
            submit_button.Visibility = Visibility.Collapsed;
            userInput_box.Visibility = Visibility.Collapsed;
            user_messages.Visibility = Visibility.Collapsed;
            wordToDraw.Visibility = Visibility.Collapsed;
            drawingCanvas.Visibility = Visibility.Collapsed;
            gameOver.Visibility = Visibility.Collapsed;
            quitButton.Visibility = Visibility.Collapsed;
            continueButton.Visibility = Visibility.Collapsed;
            whosTurn.Visibility = Visibility.Collapsed;
        }

        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if the user exits the game with the window X then unregister them form the drawing client
            _drawingServiceClient?.UnRegisterForDrawingService(user_alais.Text);
        }


        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            //unregister the service
            _drawingServiceClient?.UnRegisterForDrawingService(user_alais.Text);
            
            // Close the window
            this.Close();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            //just continune the game
            //hide the other items on the screen
            clear_drawing.Visibility = Visibility.Visible;
            submit_button.Visibility = Visibility.Visible;
            userInput_box.Visibility = Visibility.Visible;
            user_messages.Visibility = Visibility.Visible;
            wordToDraw.Visibility = Visibility.Visible;
            drawingCanvas.Visibility = Visibility.Visible;
          


            //hide the game over items
            //show the items that needed for game over
            gameOver.Visibility = Visibility.Collapsed; 
            quitButton.Visibility = Visibility.Collapsed;
            continueButton.Visibility = Visibility.Collapsed;

             

        }
        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if the client has a connection
            if(_hasConnection == true)
            {
                //and the current user can draw
                if(_drawingServiceClient.CanDraw())
                {
                    //clear the array, and add the new points to the array
                    _points.Clear();
                    _points.Add(new DrawingPoints { X = e.GetPosition(drawingCanvas).X, Y = e.GetPosition(drawingCanvas).Y });
                    _isDrawing = true; //can draw on the canvas
                }
                else
                {
                    //else if the user cannot draw (they simply cannot draw on the canvas(
                    _isDrawing = false;
                }
                
            }
            //tell the user they don't have a connection to the server
            else
            {
                MessageBox.Show("There Is No Connection to the Service");
            }
           
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            //if the user can draw and has a connection
            //NOTE: at this point the use will always have a connnection (so checking again if the user has a conenction is useless)...
            if (_isDrawing && _hasConnection == true)
            { 
                //add the points to the points array
                _points.Add(new DrawingPoints { X = e.GetPosition(drawingCanvas).X, Y = e.GetPosition(drawingCanvas).Y });
            }
        }

        private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {

            //the the point array has values
            if (_points.Count > 1)
            {
                //add a command to the pending commands array in the lib
                var command = new DrawingCommand
                {

                    ActionType = DrawingActionType.DrawLine, //choosing action type as drawing a line
                    Color = "Black", //choosing a color 
                    Thickness = 2, //line thickness
                    StartPoint = _points.First(), //first point
                    EndPoint = _points.Last(), // last point
                    Points = _points.ToArray() // adding the points to the array
                };
                //add command to lib array
                _drawingServiceClient.AddDrawingCommand(command);
            }

            //now the user is not drawing anymore
            _isDrawing = false;


        }

        public void ReceiveDrawingCommand(DrawingCommand command)
        {
            
            //check if the user is drawing or clearning the cancas
            switch (command.ActionType)
            {
                //add a polyline to the canvas from the give data
                /// the Polyline element is used to draw a series of connected straight line segments. 
                case DrawingActionType.DrawLine:
                var polyline = new Polyline
                {
                    Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(command.Color)),
                    StrokeThickness = command.Thickness,
                    Points = new PointCollection(command.Points.Select(p => new Point(p.X, p.Y)))
                };
                drawingCanvas.Children.Add(polyline);
                break;
            case DrawingActionType.ClearCanvas:
                // Clear the canvas
                drawingCanvas.Children.Clear();
                break;
                // handle other drawing actions as needed
            }
           
           
        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {

            //if the useralias is not empty
            if (user_alais.Text != "")
            {
                try
                {
                    //set a user prefix
                    _userPrefix = "[" + user_alais.Text + "] ";
                   
                    //connect to game
                    connectToGame();
                   

                }
                catch (Exception ex)
                {
                    //if error throw err
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void submit_button_Click(object sender, RoutedEventArgs e)
        {
            //if the user message is not empty
            if (userInput_box.Text != "")
            {
                
                try
                {
                    //post the message with the user alias
                    _drawingServiceClient.PostMessage(_userPrefix + userInput_box.Text); 
                    userInput_box.Clear();
                }
                catch (Exception ex)
                {
                    //if err throw err
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void clear_drawing_Click(object sender, RoutedEventArgs e)
        { 
            //NOTE:
            /// this is a simply solution (because i was unable to hide the clear button)
            //if the current client can draw
            if(_drawingServiceClient.CanDraw())
            {  
                //then clear the canvas
                _drawingServiceClient.ClearCanvas(); 
            }
            else
            {
                //else the user cannot clear the canvas
                MessageBox.Show("not you turn");
            }
             
        }


        public void connectToGame()
        {
            try
            {
                // Configure the ABCs of using the MessageBoard service
                _drawingServiceClient = new DuplexChannelFactory<IDrawingService>(new InstanceContext(this), new NetTcpBinding(), "net.tcp://localhost:5000/DrawingServiceEndpoint").CreateChannel();
                
                //using this datacontext and setting the connection to true
                DataContext = this;
                _hasConnection = true; 


                //if the user is registed for the client 
                if (_drawingServiceClient.RegisterForDrawingService(user_alais.Text))
                {
                    
                    // Alias accepted by the service so update GUI
                    user_messages.ItemsSource = _drawingServiceClient.GetAllMessages();
                    
                   //hide the user register info UI items
                    setButton.Visibility = Visibility.Collapsed;
                    user_alais.Visibility = Visibility.Collapsed;
                
                    //show the game UI items
                    submit_button.Visibility = Visibility.Visible;
                    userInput_box.Visibility = Visibility.Visible;
                    user_messages.Visibility = Visibility.Visible;
                    wordToDraw.Visibility = Visibility.Visible;
                    clear_drawing.Visibility = Visibility.Visible;
                    drawingCanvas.Visibility = Visibility.Visible;

                    //get a word for the user to draw
                    _drawingServiceClient.GetAWord();

                    //get the current player: 
                    _drawingServiceClient.CurrentPlayerTurn();
                }
                else
                {
                    // Alias rejected by the service so nullify service proxies
                    _drawingServiceClient = null;
                    MessageBox.Show("ERROR: Alias in use. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Implements the callback logic that will be triggered by a callback event in the service

        private delegate void GuiUpdateDelegate(string[] messages);

        public void SendAllMessages(string[] messages)
        {

            // it checks whether the current thread is the same as the dispatcher thread.
            if (this.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
            {
                try
                {
                    //set the messages to the list box
                    user_messages.ItemsSource = messages; 
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
            //If the current thread is not the dispatcher thread, then it uses the dispatcher to execute the method in the dispatcher thread using the "BeginInvoke" method.
            //It passes the "SendAllMessages" method itself and the "messages" array as parameters to "BeginInvoke".
            else
                this.Dispatcher.BeginInvoke(new GuiUpdateDelegate(SendAllMessages), new object[] { messages });
        }


        public void ReceiveClearCanvas()
        {
            //  Clear the drawing canvas here
            drawingCanvas.Children.Clear();
        }

       
        //delegate for getting a word
        private delegate void GuiUpdateDelegate2(string word);
         

        public void RecieveAWord(string word)
        {
            // it checks whether the current thread is the same as the dispatcher thread.
            if (this.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
            {
                try
                {
                    //sets the word gotten from the lib
                    wordToDraw.Content = word;
                }
                catch (Exception ex)
                {
                    //throws error if any
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void RecieveGameOver(string playerName)
        {

            //hide the other items on the screen
            clear_drawing.Visibility = Visibility.Collapsed;
            submit_button.Visibility = Visibility.Collapsed;
            userInput_box.Visibility = Visibility.Collapsed;
            user_messages.Visibility = Visibility.Collapsed;
            wordToDraw.Visibility = Visibility.Collapsed;
            drawingCanvas.Visibility = Visibility.Collapsed;
            whosTurn.Visibility = Visibility.Collapsed;


            //show the items that needed for game over
            gameOver.Visibility = Visibility.Visible;
            gameOver.Content = playerName + " Has Won!";

            quitButton.Visibility = Visibility.Visible;
            continueButton.Visibility = Visibility.Visible;


        }

        public void RecieveCurrentPlayerTurn(string playerName)
        {
            whosTurn.Visibility = Visibility.Visible;
            whosTurn.Content =  "Current Player: " + playerName;
        }

 
    }
}
