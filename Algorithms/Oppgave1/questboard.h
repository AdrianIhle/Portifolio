#ifndef QUESTBOARD_H
#define QUESTBOARD_H

#include "quest.h"

class QuestBoard
{
public:
    int boardSize;
    QuestBoard(int size);
    Quest* questBoard[];
    void addNew(Quest* q);
    void viewBoard();
    void searchBoard();
};

#endif // QUESTBOARD_H
