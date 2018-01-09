#include "listofchildren.h"
#include "treenode.h"
#include <iostream>
using namespace std;

class TreeNode;

ListOfChildren::ListOfChildren()            //når denne listen blir konstruert vil den komme med og linke sammen sentinel values som en dobbelt lenket lsite
{
    head = new TreeNode("0",0,0,0,true);
    tail = new TreeNode("0",0,0,0,true);
    head->Next = tail;
    tail->Prev = head;
    head->SetChild(tail);
    tail->SetParent(head);
    head->Next = tail;
    tail->Prev = head;
    numberOfChilds = 0;
}

ListOfChildren::~ListOfChildren()
{

}
bool ListOfChildren::empty()            //skjekker om det er noe mellom sentinels
{
    return(head->GetChild() == tail);
}

TreeNode* ListOfChildren::getStart()     //anskaffer første brukbare node
{
    return head->Next;
}
TreeNode* ListOfChildren::getEnd() //anskaffer siste brukbare node, i begge disse tilfellene har jeg da tenkt child/parent logikk når jeg  brude ha brukt next previous
{
    return tail->Prev;
}
void ListOfChildren::addChildNode(TreeNode* parent, const string& data)           //denne får et sett data in, lager en ny node, setter dens data som det vi fikk inn, finner en current node i listen og
{                                                               //leter igjennom (som jeg da har gjort som on jeg sorterer verdier) etter plass og finner den, strengt tatt ikke nødvendig
    numberOfChilds++;
    TreeNode* newNode = new TreeNode(data, parent->getxCo() +1, numberOfChilds, parent->ChildList->head->Next);
    newNode->SetData(data);
    newNode->SetParent(parent);
    parent->SetChild(newNode);

    newNode->Next = parent->ChildList->head->Next;
    newNode->Prev= parent->ChildList->head;
    parent->ChildList->head->Next->Prev = newNode;
    parent->ChildList->head->Next = newNode;

    newNode->SetCo(parent->getxCo()+1 ,numberOfChilds);
}

void ListOfChildren::recursiveSearch (TreeNode* ptr, string Querry)                                 //en funskjon som ikke trenger og være her men har blitt innkludert for testing mulgiheter
{
    if(ptr->GetData() == "")                                             //om ptr kommer til et punkt hvor noden ikke inneholder noe (altså halen) så finnes ikke objektet i listen
    {
        cout << Querry << " er ikke i listen \n" << endl;            //forteller bruker at det de søker etter ikke er i listen
    }
    else if(ptr->GetData() == Querry)                                    // om søkeparameteret finnes i listen så får brukeren svar
    {
        cout << Querry << " er i listen \n";
    }
    else                                                            //om ikke søket har funnet det den leter etter ller nådd slutten av listen så hopper den til neste node
    {
        recursiveSearch(ptr->GetChild(), Querry);
    }

}


