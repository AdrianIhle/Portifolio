#include "board.h"
#include "player.h"
#include <iostream>

using namespace std;

Board::Board()
{

}

void Board::drawBoard()
{
    for (int i=0; i<9; i++)
    {
        cout<<"___________________________"<<endl;

        for(int j=0; j<9; j++)
        {
            cout << board[i][j] << ' ';
            cout << "|";

        }
        cout <<endl;
    }
}

void Board::putCharacter(char cIn, int xIn, int yIn)
{

    board [xIn][yIn] = cIn;
}



