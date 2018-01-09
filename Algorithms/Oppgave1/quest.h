#ifndef QUEST_H
#define QUEST_H
#include <iostream>
#include <string>
using namespace std;

class Quest
{
public:
    Quest(string name = " ", int reward = 0, int xp = 0);
    string Name;
    int Reward;
    int XP;
    void print();

};

#endif // QUEST_H
