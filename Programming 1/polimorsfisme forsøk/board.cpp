#include "board.h"
#include "player.h"
#include <iostream>

using namespace std;

Board::Board()
{

}

void Board::drawBoard()                             //prints the baord on screen
{
    for (int i=0; i<10; i++)
    {
        cout<<"______________________________"<<endl;

        for(int j=0; j<10; j++)
        {
            cout << board[i][j] << ' ';
            cout << "|";

        }
        cout <<endl;
    }
}

void Board::putCharacter(char cIn, int xIn, int yIn) //inserts the character on to the board
{

    board [xIn][yIn] = cIn;
}

void Board::clearBoard()                //whipes the visual board clean to clear out old sprites
{
    for (int i=0; i<10; i++)
    {


        for(int j=0; j<10; j++)
        {
            board[i][j] = ' ';


        }

    }
}

