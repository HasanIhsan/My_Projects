/*
* FileName: main.cpp
* ProgramName : tic-tac-toe
* Purpose: this contains all the code for the tic-tac-toe game using c++
* Date: ----/--/--
*/

//imports
#include <iostream>
#include <stdlib.h>

//array for the board
char board[3][3] = { {'1','2','3'}, {'4','5','6'}, {'7','8','9'} };

//variables
int choice;
int row, column;
char turn = 'X';
bool draw = false;

/*
* Method Name: display_board
* Purpose: to show the current status of the game board
* Date: ----/--/--
*/
void display_board()
{
	//render the game board layout
    std::cout << "PLAYER - 1 [X]\t PLAYER - 2 [O]" << std::endl;
    std::cout << "\t\t     |     |     " << std::endl;
    std::cout << "\t\t  " << board[0][0] << "  | " << board[0][1] << "   |  " << board[0][2] << std::endl;
    std::cout << "\t\t_____|_____|_____" << std::endl;
    std::cout << "\t\t     |     |     " << std::endl;
    std::cout << "\t\t  " << board[1][0] << "  | " << board[1][1] << "   |  " << board[1][2] << std::endl;
    std::cout << "\t\t_____|_____|_____" << std::endl;
    std::cout << "\t\t     |     |     " << std::endl;
    std::cout << "\t\t  " << board[2][0] << "  | " << board[2][1] << "   |  " << board[2][2] << std::endl;
    std::cout << "\t\t     |     |     " << std::endl;
}

/*
* Method Name: player_turn
* Purpose: to get the player input and update the board
* Date: ----/--/--
*/
void player_turn()
{
    if (turn == 'X')
    {
        std::cout << "\n\tPlayer - 1 [X] turn: ";
    }
    else if (turn == 'O')
    {
        std::cout << "\n\tPlayer - 2 [O] turn : ";
    }

    //taking input from user
    //updating the board according to choice and reassigning the trun Start
    std::cin >> choice;

    //switch case to get which row and column will be updated
    switch (choice)
    {
    case 1: 
            row = 0; 
            column = 0; 
        break;
    case 2: 
            row = 0; 
            column = 1; 
        break;
    case 3: 
            row = 0; 
            column = 2; 
        break;
    case 4: 
            row = 1; 
            column = 0; 
        break;
    case 5: 
            row = 1; 
            column = 1; 
        break;
    case 6: 
            row = 1; 
            column = 2; 
        break;
    case 7: 
            row = 2; 
            column = 0; 
        break;
    case 8: 
            row = 2; 
            column = 1; 
        break;
    case 9: 
            row = 2; 
            column = 2; 
        break;
    default:
        std::cout << "invalid move!";
        break;
    }

    if (turn == 'X' && board[row][column] != 'X' && board[row][column] != 'O')
    {
        //update the postion for 'X' if
        //it is not already occupied
        board[row][column] = 'X';
        turn = 'O';
    }
    else if (turn == 'O' && board[row][column] != 'X' && board[row][column] != 'O')
    {
        //update the postion of 'O' if
        //it is not occupiced
        board[row][column] = 'O';
        turn = 'X';
    }
    else
    {
        //if unput position already fillled
        std::cout << "Box alread filled! Please choose another!!" << std::endl;
        player_turn();
    }

    //ends
    //display_board();
}

/*
* Method Name: gameover
* Purpose: to get the game status e.g GAME WON, GAME DRAW, GAME CONTINUE
* Date: ----/--/--
*/
bool gameover()
{
    //checking the win for simple row and column
    for (int i = 0; i < 3; i++)
    {
        if (board[i][0] == board[i][1] && board[i][0] == board[i][2] || board[0][i] == board[1][i] && board[0][i] == board[2][i])
        {
            return false;
        }

        //checking win for both diagonal 
        if (board[0][0] == board[1][1] && board[0][0] == board[2][2] || board[0][2] == board[1][1] && board[0][2] == board[2][0])
        {
            return false;
        }

        //checing for game continue or not
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i][j] != 'X' && board[i][j] != 'O')
                {
                    return true;
                }
            }
        }


        
    }

     
    //checking draw
    draw = true;
    return false;
}


/*
* Method Name: main
* Purpose: main method
* Date: ----/--/--
*/

int main()
{
    std::cout << "\t\t\tT I C K -- T A C -- T O E -- G A M E\t\t\t" << std::endl;
    std::cout << "\t\t\tFOR 2 PLAYERS\t\t\t" << std::endl;

    while (gameover()) {
        display_board();
        player_turn();
        gameover();
    }



    //this logic is a bit odd/weird but works
    if (turn == 'X' && draw == false) {
        std::cout << "Congratulations! Player 2 has won the game" << std::endl;
    }
    else if (turn == 'O' && draw == false) {
        std::cout << "Congratulations! Player 1 has won the game" << std::endl;
    }
    else
    {
        std::cout << "GAME DRAW!!!" << std::endl;
    }
         
}