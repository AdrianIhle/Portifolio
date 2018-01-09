#ifndef BOARD_H
#define BOARD_H
#include "player.h"
#include <iostream>

class Board
{
public:
    Board();


    char board[10][10] = {};
    void drawBoard();
    void putCharacter(char cIn, int xIn, int yIn);
    void clearBoard();
};

#endif // BOARD_H
