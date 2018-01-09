#ifndef LIST_H
#define LIST_H
#include "node.h"

class List
{
private:
    node* mRoot;
    node* mCurrentNode;
    int mSize = 0;
public:
    List();
    void addNode(node *newNode);
    int getSize();
    void sortByValueAscending();
    void printList();
};

#endif // LIST_H
