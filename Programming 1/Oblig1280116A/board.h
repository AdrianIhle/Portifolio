#ifndef BOARD_H
#define BOARD_H
#include "player.h"

class Board
{
public:
    Board();


char board[10][10] = {};
void drawBoard();
//void printBoard();
void putCharacter(char cIn, int xIn, int yIn);
};

#endif // BOARD_H
