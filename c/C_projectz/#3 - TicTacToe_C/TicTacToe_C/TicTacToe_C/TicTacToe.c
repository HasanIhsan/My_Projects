/*
* Program Name: TicTacToe.c
* Purpose: this is a tictactoe game created using c (this is created using an online tutorial.... so if there is borken/old code please be aware)
* Programmer: Hassan ihsan
* Date: ----
*/

 

//define
#define _CRT_SECURE_NO_WARNINGS

//imports
#include<stdio.h>
#include<conio.h> //conio.h is a C header file used mostly by MS-DOS compilers to provide console input/output.
#include<stdlib.h>
#include <windows.h> //windows.h is a Windows-specific header file for the C and C++ 
                    //programming languages which contains declarations for all of the functions in the Windows API, 
                    //all the common macros used by Windows programmers, and all the data types used by the various functions and subsystems.

//vars
int player_board[10] = { 2,2,2,2,2,2,2,2,2,2 };
int player_turn = 1, flag = 0;
int player, comp;

//methods declaration (expaations are shown later)
void menu();
void go(int n);
void start_game();
void check_draw();
void draw_board();
void player_first();

void put_X_O(char ch, int pos);
COORD coord = { 0,0 }; // this is global variable

//center of axis is set to the top left cornor of the screen
void gotoxy(int x, int y)
{
    coord.X = x;
    coord.Y = y;

    //setconsoleCurosrPostion: The cursor position determines where characters written by the WriteFile or WriteConsole function
   //getstdhandel: provides a mechanism for retrieving the standard input ( STDIN ), standard output ( STDOUT ), 
   //				and standard error ( STDERR ) handles associated with a process
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

/*method name : main
* Purpose: the main method
* data:
*/
void main()
{ 
    //uses the system termainl command "cls" to clear the console
    system("cls");

    menu();
    _getch();

}


/*method name : menu
* Purpose: this is the main menu which shows the items that the user can select
* data:
*/
void menu()
{
    //clear console
    system("cls");


    int choice;
 

    printf("\n--------MENU--------");
    printf("\n1 : Play with X");
    printf("\n2 : Play with O");
    printf("\n3 : Exit");

    printf("\nEnter your choice:>");
    scanf("%d", &choice);

    player_turn = 1; //check whoses turn it is

    switch (choice)
    {

        //this choice player start first and computer secion (computer will always choose pos 5)
        case 1:
            player = 1;
            comp = 0;
            player_first();
        break;
        

        //cimputer goes first and player second
        case 2:
            player = 0;
            comp = 1;
            start_game();
        break;
        
        case 3:
            exit(1);
    default:
        menu();
    }
}
/*method name : make_2
* Purpose: ... make a player_board of computer choice
* data:
*/

int make_2()
{
    if (player_board[5] == 2)
    {
        return 5;
    }

    if (player_board[2] == 2)
    {
        return 2;
    }

    if (player_board[4] == 2)
    {
        return 4;
    }

    if (player_board[6] == 2)
    {
        return 6;
    }

    if (player_board[8] == 2)
    {
        return 8;
    }

    return 0;
}

int make_4()
{
    if (player_board[1] == 2)
    {
        return 1;
    }

    if (player_board[3] == 2)
    {
        return 3;
    }

    if (player_board[7] == 2)
    {
        return 7;
    }

    if (player_board[9] == 2)
    {
        return 9;
    }

    return 0;
}


/*method name : poss_win
* Purpose: checking of win
* data:
*/
int poss_win(int p)
{
    // p==1 then X   p==0  then  O
    int i;
    int check_val, pos;

    if (p == 1)
    {
        check_val = 18;
    }
    else
    {
        check_val = 50;
    }

    i = 1;
    while (i <= 9)//row check
    {
        if (player_board[i] * player_board[i + 1] * player_board[i + 2] == check_val)
        {
            if (player_board[i] == 2)
            {
                return i;
            }

            if (player_board[i + 1] == 2)
            {
                return i + 1;
            }

            if (player_board[i + 2] == 2)
            {
                return i + 2;
            }
        }
        i += 3;
    }

    i = 1;
    //column check
    while (i <= 3) 
    {
        if (player_board[i] * player_board[i + 3] * player_board[i + 6] == check_val)
        {
            if (player_board[i] == 2)
            {
                return i;
            }

            if (player_board[i + 3] == 2)
            {
                return i + 3;
            }

            if (player_board[i + 6] == 2)
            {
                return i + 6;
            }
        }
        i++;
    }
    if (player_board[1] * player_board[5] * player_board[9] == check_val)
    {
        if (player_board[1] == 2)
        {
            return 1;
        }

        if (player_board[5] == 2)
        {
            return 5;
        }

        if (player_board[9] == 2)
        {
            return 9;
        }

    }

    if (player_board[3] * player_board[5] * player_board[7] == check_val)
    {
        if (player_board[3] == 2)
        {
            return 3;
        }

        if (player_board[5] == 2)
        {
            return 5;
        }

        if (player_board[7] == 2)
        {
            return 7;
        }

    }
    return 0;
}


/*method name : go
* Purpose: go to position on board
* data:
*/
void go(int n)
{
    if (player_turn % 2)
    {
        player_board[n] = 3;
    }
    else
    {
        player_board[n] = 5;
    }
    player_turn++;
}

/*method name : player_first
* Purpose: the player(aka you) get to go first
* data:
*/
void player_first()
{
    int pos;

    //check draw and board draw
    check_draw();
    draw_board();
    gotoxy(30, 18);

    printf("Your Turn: ");
    scanf("%d", &pos);

    if (player_board[pos] != 2)
    {
        player_first();
    }

    if (pos == poss_win(player))
    {
        go(pos);
        draw_board();
        gotoxy(30, 20);

        printf("player wins");
        _getch();
        exit(0);
    }

    go(pos);
    draw_board();
    start_game();
}


/*method name : start_game
* Purpose: start the game...
* data:
*/
void start_game()
{ // p == 1 then x p ==0 then O
    if (poss_win(comp))
    {
        go(poss_win(comp));
        flag = 1;
    }
    else if (poss_win(player))
    {
        go(poss_win(player));
    }
    else if (make_2())
    {
        go(make_2());
    }
    else
    {
        go(make_4());
    }

    draw_board();

    if (flag)
    {
        gotoxy(30, 20);
        printf("comp wins");
        _getch();
    }
    else
    {
        player_first();
    }
}


/*method name : checK_draw
* Purpose: checks if player and comp are in a draw
* data:
*/
void check_draw()
{
    if (player_turn > 9)
    {
        gotoxy(30, 20);
        printf("draw");
        _getch();

        exit(0);
    }
}


/*method name : cdraw_board
* Purpose: draws the player board
* data:
*/
void draw_board()
{
    int j;
    for (j = 9; j < 17; j++)
    {
        gotoxy(35, j);
        printf("|       |");
    }

    gotoxy(28, 11);
    printf("-----------------------");
    gotoxy(28, 14);
    printf("-----------------------");

    for (j = 1; j < 10; j++)
    {
        if (player_board[j] == 3)
        {
            put_X_O('X', j);
        }
        else if (player_board[j] == 5)
        {
            put_X_O('O', j);
        }
    }
}


/*method name : put_x_o
* Purpose: draws the X and O onto the board
* data:
*/
void put_X_O(char ch, int pos)
{
    int m;
    int x = 31, y = 10;

    m = pos;

    if (m > 3)
    {
        while (m > 3)
        {
            y += 3;
            m -= 3;
        }

    }

    if (pos % 3 == 0)
    {
        x += 16;
    }
    else
    {
        pos %= 3;
        pos--;

        while (pos)
        {
            x += 8;
            pos--;
        }
    }

    gotoxy(x, y);
    printf("%c", ch);
}
