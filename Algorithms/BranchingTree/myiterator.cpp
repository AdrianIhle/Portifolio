#include "treelist.h"
#include "treenode.h"
#include <string>
using namespace std;

//template<typename T>
MyIterator::MyIterator(TreeNode* u)
{
    v = u;
}

//template<typename T>
const string MyIterator::operator *() const                 //her overlastes pekeren til å peke på dataen i en node isteden for noden selv
{
    return v->GetData();
}



//template<typename T>                                          samme men motsatt
bool MyIterator::operator !=(const MyIterator& i) const
{
    return v != i.v;
}

//template<typename T>                                          her ville ++ anskaffet neste i lista men igjen feil bruk av child/parent logikk
MyIterator& MyIterator::operator ++()
{
    v = v->getNext();
    return *this;
}

