#include <iostream>
#include "quest.h"
#include "questboard.h"

using namespace std;

void AddQuests(QuestBoard LiliTown);
//print fungerer for hver enkelt node, men ikke når jeg bruker viewBoard funksjonen
int main()
{
    QuestBoard LiliTown(10);

    AddQuests(LiliTown);
//    LiliTown.viewBoard();


    cout << "questline finished" << endl;



    return 0;
}

void AddQuests(QuestBoard LiliTown){
    Quest* q1 = new Quest("tutorial", 1, 100);
    Quest* q2 = new Quest("goblin fight", 1, 150);
    Quest* q3 = new Quest("bandit Fight", 2, 200);
    Quest* q4 = new Quest("Centaur Cascade", 3, 250);
    Quest* q5 = new Quest("Fearal Money", 0, 50);
    Quest* q6 = new Quest("Hung and Burnt", 2, 350);
    Quest* q7 = new Quest("The Boss of My Boss", 4, 400);
    Quest* q8 = new Quest("Next Level Boss", 4, 450);
    Quest* q9 = new Quest("Intrigue in the Manor", 5, 500);
    Quest* q10 = new Quest("Final Boss", 6, 1000);

    q1->print();
    q2->print();
    q3->print();
    q4->print();
    q5->print();
    q6->print();
    q7->print();
    q8->print();
    q9->print();
    q10->print();

        LiliTown.addNew(q1);
        LiliTown.addNew(q2);
        LiliTown.addNew(q3);
        LiliTown.addNew(q4);
        LiliTown.addNew(q5);
        LiliTown.addNew(q6);
        LiliTown.addNew(q7);
        LiliTown.addNew(q8);
        LiliTown.addNew(q9);
        LiliTown.addNew(q10);
}

