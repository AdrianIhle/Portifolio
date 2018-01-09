#ifndef TREELIST_H
#define TREELIST_H
#include <string>
#include "treenode.h"
#include "myiterator.h"

using namespace std;

class ListOfChildren;

class TreeNode;

class TreeList
{

public:
    class MyIterator
    {
    public:
        MyIterator(TreeNode* u);
        const string operator *() const;
        MyIterator& operator++();
        MyIterator& operator--();
        friend class TreeList;
        friend class TreeNode;

    private:
        TreeNode* v;
        Iterator(TreeNode* u);

    };

public:
    TreeList();
    ~TreeList();
    int size;
    int GetSize();
    bool empty();
    MyIterator begin() const;
    MyIterator end()const;
    void insertFront(const string& e);
    void insertBack(const string& e);
    void insert(const MyIterator& p, const string& e);
    void addNode(TreeNode *parent, const string& content);
    void printTree(TreeNode *printee);
    void print(TreeNode* printNode, int i);
    TreeNode *search(string searchInput, TreeNode *searchNode);
    TreeNode* getRoot(TreeList* List);

private:
    TreeNode* root;
    int n;
    TreeNode* header;
    TreeNode* trailer;


};

#endif // TREELIST_H
