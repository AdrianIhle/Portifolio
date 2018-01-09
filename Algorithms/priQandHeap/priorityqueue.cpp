#include "priorityqueue.h"

PriorityQueue::PriorityQueue()
{

}

int PriorityQueue::size()
{
    return Heap.size();
}

bool PriorityQueue::empty()
{
    return size() == 0;
}

//PriorityNode& PriorityQueue::minPri()
//{
//    return* (Heap.root());
//}

void PriorityQueue::insert(int priority, string data)
{
    Heap.addToQueue(priority, data);

}
