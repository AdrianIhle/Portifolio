#ifndef TREENODE_H
#define TREENODE_H
#include <string>
#include "listofchildren.h"

class ListOfChildren;

using namespace std;

class TreeNode
{
public:
    string GetData();
    bool operator == (TreeNode node);
    bool isExternal();
    float getxCo();
    float getyCo();
    TreeNode(string content = "0", float xCo = 0, float yCo = 0, TreeNode* next = 0, bool external = true);
    TreeNode* getNext();
    ~TreeNode();
    TreeNode* GetChild();
    TreeNode* GetParent();
    TreeNode* GetFirst(ListOfChildren* list);
    TreeNode* Next;
    TreeNode* Prev;
    TreeNode* SetChild(TreeNode* newChild);
    TreeNode* SetParent(TreeNode* newParent);
    TreeNode* SetData(string newData);
    TreeNode* SetCo(float x, float y);
    ListOfChildren* ChildList;
private:
    float xCord;
    float yCord;
    string data;
    TreeNode* child;
    TreeNode* parent;
    static int Depth;
    friend class TreeList;
};

#endif // TREENODE_H
