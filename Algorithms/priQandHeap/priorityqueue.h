#ifndef PRIORITYQUEUE_H
#define PRIORITYQUEUE_H
#include <string>
#include "heap.h"

class PriorityQueue
{
public:
    PriorityQueue();
    int size();
    bool empty();
    void insert(int priority, std::string data);
//    PriorityNode &minPri();
    void removeMinPri();
    heap Heap;
    bool isLess(PriorityNode* a, PriorityNode* b) {return a->priority < b->priority;}
};

#endif // PRIORITYQUEUE_H
