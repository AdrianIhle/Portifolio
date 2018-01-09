#include <iostream>
#include<vector>
#include "node.h"
#include "kant.h"

using namespace std;


int main()
{

    std::vector<Node*> nodeVec;
    Node* graf;

    Node* tempNode;
    Node* currentNode;
    int index = 0;
    char inchar = 'f';
    for(char x = 'a'; x <= inchar; x++)
    {
        tempNode = new Node();
        tempNode->mNavn = x;
        cout << tempNode->mNavn << endl;
        if(x == 'a'){
            graf = tempNode;
            currentNode = graf;
        }
        else
        {
            index++;
            currentNode->mNestenode = tempNode;
            currentNode = currentNode->mNestenode;
        }

    }

    currentNode = graf;

    do
    {
        cout << currentNode->mNavn;
        cout << " this node's next is " << currentNode->mNestenode->mNavn << endl;
        if(currentNode->mNestenode != nullptr)
            currentNode = currentNode->mNestenode;
    }    while(currentNode->mNavn != 'f');


    //        for(int i = 0; i < index; i++)
    //        {
    //            if(nodeVec[i]->mNestenode != nullptr)
    //                nodeVec[i]->settinnkant((double)1*i, nodeVec[i+1]);
    //        }


    currentNode = graf;
    do
    {
        int i = 0;
        i++;
        if(currentNode->mNestenode != nullptr)
            currentNode->settinnkant((double)1*rand(),currentNode->mNestenode);
        currentNode = currentNode->mNestenode;
    }    while(currentNode->mNavn != 'f');

    //    for(int i = 0; i < index; i++)
    //    {
    //        cout << "kant fra node " <<  nodeVec[i]->mForstekant->mFranode->mNavn << " til node " <<nodeVec[i]->mForstekant->mTilnode-> mNavn <<" med vekt " << nodeVec[i]->mForstekant->mVekt <<endl ;
    //    }

        currentNode = graf;
    do
    {
        if(currentNode->mNestenode != nullptr)
            cout << "kant fra node " <<  currentNode->mForstekant->mFranode->mNavn
                 << " til node " <<currentNode->mForstekant->mTilnode-> mNavn
                 <<" med vekt " << currentNode->mForstekant->mVekt <<endl ;
        currentNode = currentNode->mNestenode;
    }    while(currentNode->mNavn != 'f');

    //    for(int i = 0; i < index; i++)
    //    {
    //        nodeVec[i]->mForstekant->skriv();
    //    }

        currentNode = graf;
    do
    {
        if(currentNode->mNestenode != nullptr)
            currentNode->mForstekant->skriv();
        currentNode = currentNode->mNestenode;
    }    while(currentNode->mNavn != 'f');
        cout << endl;


            graf->skrivrek();
            cout<< endl;





    return 0;
}
