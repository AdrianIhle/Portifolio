#include "node.h"

Node::Node(int priority, string name, Node* next, Node* prev)
{
    Next = next;
    Prev = prev;
    Name = name;
    Priority = priority;
}

