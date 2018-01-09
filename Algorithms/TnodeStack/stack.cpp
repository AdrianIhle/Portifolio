#include "stack.h"

stack::stack()  { liste = 0; }
stack::~stack()
{
    CharNode* p = liste;
    while (p!=0) {
        CharNode* ut = p;
        p = p->hentNeste();
        delete ut;
    }
}
void stack::push(char tegn)
{
    liste = new CharNode(tegn, liste);
}
void stack::pop()
{
    if (!empty())
    {
        // Slette den første i lista. Er det trygt når det er igjen ett objekt?
        CharNode* ut = liste;
        liste = liste->hentNeste();
        delete ut;
    }
}
int stack::size() const     { return liste->hentAntall(); }
bool stack::empty() const   { return liste==0;  }
char stack::top() const     { return liste->hentData(); }

