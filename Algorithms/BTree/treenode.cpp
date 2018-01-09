#include "treenode.h"
#include "listofchildren.h"

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


