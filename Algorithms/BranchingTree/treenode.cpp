#include "treenode.h"
#include "listofchildren.h"

/*inntil jeg begynte å innkludere getChildList hadde jeg bare enkele syntaks feil her, når er det for det meste det også men ikke tid til å fikse.
 * annet enn det vill denne lage en node med string som innhold, to kordinater og en peker til dens neste, annet enn det er det hovedsaklig å kalle
 * opp variabler og pekere fra privat og sette de for å kunne applikere de i liste struktur
*/

TreeNode::TreeNode(string content, float xCo, float yCo, TreeNode* next, bool external)
    :Next(next), Prev(NULL), ChildList(NULL), child(NULL), parent(NULL)
{
    external = isExternal();
    data = content;
    xCord = xCo;
    yCord = yCo;
    if(!external)
    {
    ChildList = new ListOfChildren;
    }
}

int TreeNode::Depth;

TreeNode::~TreeNode()
{

}

bool TreeNode::operator ==(TreeNode node)
{
    return (data == node.data);
}

bool TreeNode::isExternal()
{
    return this->Next == 0 && this->Prev == 0;
}

string TreeNode::GetData()
{
    return data;
}

TreeNode* TreeNode::GetChild()
{
    return child;
}

TreeNode* TreeNode::GetParent()
{
    return parent;
}

TreeNode* TreeNode::getNext()
{
    return Next;
}

TreeNode* TreeNode::GetFirst(ListOfChildren* list)
{
    return list->getStart();
}

TreeNode* TreeNode::SetChild(TreeNode *newChild)
{
    this->child = newChild;
}

TreeNode* TreeNode::SetParent(TreeNode *newParent)
{
    this->parent = newParent;
}
 TreeNode* TreeNode::SetData(string newData)
 {
     this->data = newData;
 }

 float TreeNode::getxCo()
 {
     return xCord;
 }

 float TreeNode::getyCo()
 {
     return yCord;
 }

 TreeNode* TreeNode::SetCo(float x, float y)
 {
     xCord = x;
     yCord = y;
 }


