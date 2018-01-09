#ifndef MYITERATOR
#define MYITERATOR
#include "treelist.h"
#include <string>
using namespace std;

//template<typename T>
class MyIterator
{
public:
    MyIterator(TreeNode* u);
    const string operator *() const;
    MyIterator& operator++();
    MyIterator& operator--();
    bool operator !=(const MyIterator& i) const;
    friend class TreeList;
    friend class TreeNode;

private:
    TreeNode* v;
    Iterator(TreeNode* u);

};



#endif // MYITERATOR

