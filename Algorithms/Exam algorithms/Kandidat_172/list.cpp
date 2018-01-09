#include "list.h"

List::List()
{
    mRoot = new node(-1);
    mCurrentNode = mRoot;

}

void List::addNode(node* newNode)
{
        mSize++;
        node* tempNode;
        tempNode = mRoot->mNext;
        if(tempNode == nullptr)
            mRoot->mNext = newNode;
        else
        {
            while(tempNode->mNext != nullptr)
            {

            }
        }

}

int List::getSize()
{
    return mSize;
}

void List::sortByValueAscending()
{
    mCurrentNode = mRoot->mNext;
    while(mCurrentNode->mNext != nullptr){
        if(mCurrentNode->getData() > mCurrentNode->mNext->getData())
        {
            node* tempNode;
            tempNode = mCurrentNode->mNext->mNext;
            mCurrentNode->mNext->mNext = mCurrentNode;
            mCurrentNode->mNext = tempNode;

        }
    }
}

void List::printList()
{
    mCurrentNode = mRoot->mNext;
    while(mCurrentNode->mNext != nullptr)
    {
        mCurrentNode->print();
        mCurrentNode = mCurrentNode->mNext;
    }
}
