#ifndef PRIQUEUE_H
#define PRIQUEUE_H
#include "heap.h"

class PriQueue
{
public:
    PriQueue();
    heap HP;                                    //creates the heap this priority queue will be situated in
    void insert(int priority, string data);     //insert and sorts the node accourding to is priority
    void removeTopPri();                        //by moving the root to the last node point we use removeLAst to remove the top priority from the list
    void print();                               //prints the tree, with name and priority and indents according to priority
//    void sort();
    typedef typename heap::Pos Pos;             //declears an iterator for later use

};

#endif // PRIQUEUE_H
