#include "treelist.h"
#include "listofchildren.h"
#include <algorithm>
#include <iostream>
#include "myiterator.h"
using namespace std;

TreeList::TreeList()                                                //hver liste blir lagd med en rot til å starte og et antall (s0m for øyeblikket aldri blir modifiesert
    :header(NULL), trailer(NULL)
{
    root = new TreeNode("",0,0, false);
    n = 0;

}

int TreeList::GetSize()                                              //anskaffer størrelsen på treet når jeg får implementert det
{
    return n;
}

TreeNode *TreeList::getRoot(TreeList* List)                    //her anskaffes root for forskjellig bruk
{
    return List->root;
}

bool TreeList::empty()                                              //skjekker om listen er tom ved å se om root sitt barn er tomt (prøvde å bruke null, funket ikke, dette får ingen feil men uskker på om det funker, må fikse bool til det
{
    return (root->child == 0);
}

void TreeList::addNode(TreeNode* parent, const string &content)                       //legger til en node, her ville jeg til slutt lagt in samme funksjonen fra listOfChildren ettersom det er klumsete å ha to add funksjoner når de begge legger til samme
{

      parent->ChildList->addChildNode(parent, content);
      cout << "adding " << &content << endl;

}

void TreeList::print(TreeNode *printNode, int i)                                    //konsept til å printe hele treet tilslutt
{
    for(int j = 0; j < i; j++)
    {
        cout << "\t";
    }
    cout <<" World x: " << printNode->getxCo() << " World y: " << printNode->getyCo() <<" content: " << printNode->GetData() << endl;
//    cout << "Local x: " << printNode->getxCo() - printNode->GetParent()->getxCo() << "Local y: " << printNode->getyCo() - printNode->GetParent()->getyCo() << endl;

}

void TreeList::printTree(TreeNode* printee)                                     //logikk for å printe enkelt lister, mye tukling og mange fingre inne på den her
{

    print(printee, printee->getxCo());                                       //root skal være den første printee så dett vil printe den også gå videre og rekursivt printe de andre til det ikke er mer


     for(TreeNode* p = printee->ChildList->getEnd(); p != printee->ChildList->getStart()->Prev; p = p->Prev)       //så lenge p ikke er slutten på lista så vil den spille print på nytt; rinse and repeat,
     {                                                                                                                                             //den er tatt fra steinar og prøvd applikert til min kode, den skal i teorien funke men ikke mye tro på at den vil
       printTree(p);

     }

}

TreeNode* TreeList::search(string searchInput, TreeNode* searchNode)
{
    cout << "heil" <<endl;
    for(TreeNode* p = searchNode->ChildList->getEnd(); p != searchNode->ChildList->getStart()->Prev; p = p->Prev)
    {
        cout << "hitler" << endl;
        if(p->GetData() == searchInput){
            return p;
            cout << "you have navigated to " << p->GetData() << endl;
        }
        else if(p->GetData() != searchInput)
        {
            search(searchInput, p);
            cout << "input not found going to next"<< endl;
        }
        else
        {
            cout << "node not found " <<endl;
        }
        cout << "Goten dag" << endl;
    }
    return 0;
}

TreeList::~TreeList()
{

}



