#include "questboard.h"
#include "quest.h"

QuestBoard::QuestBoard(int size)
{
    questBoard[size];

}

void QuestBoard::addNew(Quest* q)
{
    boardSize =+ 1;
    questBoard[boardSize] = q;


}

void QuestBoard::viewBoard()
{
    for(int i = 0; i < 10; i++)
    {
        int j = i;
        questBoard[j]->print();
    }
}
void QuestBoard::searchBoard()
{

}

