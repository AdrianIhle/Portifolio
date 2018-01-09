#include "heap.h"
#include <vector>
using namespace std;

typedef typename std::vector<PriorityNode* >::iterator Pos;


heap::heap()
{
    PriorityNode* root = new PriorityNode(0, "");
    heapVector.push_back(root);
}

void heap::addToQueue(int priority, string data)
{
    PriorityNode* n = new PriorityNode(priority, data);
    heapVector.push_back(n);
}


int heap::size()
{
    return heapVector.size() -1;
}

int heap::index(const Pos &p) const
{
    return p-heapVector.begin();
}

Pos heap::ps(int i)
{
    return( heapVector.begin() + i);
}

Pos heap::left(const Pos &p)
{
    return ps(2*index(p));
}

Pos heap::right(const Pos &p)
{
    return ps((2*index(p))+1);
}

Pos heap::parent(const Pos &p)
{
    return  ps(index(p)/2);
}

bool heap::hasLeft(const Pos &p)
{
    return 2*index(p) <= size();
}

bool heap::hasRight(const Pos &p)
{
    return 2*index(p)+1 <= size();
}

bool heap::isRoot(const Pos &p) const
{
    return index(p) == 1;
}

Pos heap::root()
{
    return ps(1);
}

Pos heap::last()
{
    return ps(size());
}

void heap::removeLast()
{
    heapVector.pop_back();
}

void heap::swap(const Pos &p, const Pos &q)                 //bytter pekere til nodene
{
    PriorityNode* e = *q; *q = *p, *p = e;
}

bool heap::isLess(PriorityNode *a, PriorityNode *b)
{
    return a->priority < b->priority;
}


