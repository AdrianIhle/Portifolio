#include <iostream>
#include <chrono>
#include <ctime>
#include "thread"
#include <iostream>
#include "list.h"


using namespace std;



void fillList(List* inList, int nrOfEntry)
{
    for(int i = 0; i < nrOfEntry; i++)
    {
        node* newNode = new node(rand()%10);
        inList->addNode(newNode);
    }
}
void testFill(List* inList, int nrOfEntry)
{
    for(int i = 0; i < nrOfEntry; i++)
    {
        node* newNode = new node(i);
        inList->addNode(newNode);
    }
}

int main()
{
    List* mList;
    mList = new List();
    fillList(mList, 10);
//    testFill(mList, 10);
//    mList->sortByValueAscending();
    mList->printList();
    return 0;
}


