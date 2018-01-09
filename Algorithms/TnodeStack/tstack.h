#ifndef TSTACK_H
#define TSTACK_H

#include "tNode.h"

template <typename T>
class stack
{
public:
    stack();
    ~stack();
    void push(T data);
    void pop();
    int size() const;
    bool empty() const;
    T top() const;
private:
    Node<T>* liste;
};

template <typename T>
stack<T>::stack()  { liste = 0; }
template <typename T>
stack<T>::~stack()
{
    Node<T>* p = liste;
    while (p!=0) {
        Node<T>* ut = p;
        p = p->hentNeste();
        delete ut;
    }
}
template <typename T>
void stack<T>::push(T data)
{
    liste = new Node<T>(data, liste);
}
template <typename T>
void stack<T>::pop()
{
    if (!empty()) {
        Node<T>* ut = liste;
        liste = liste->hentNeste();
        delete ut;
    }
}
template <typename T>
int stack<T>::size() const     { return liste->hentAntall(); }
template <typename T>
bool stack<T>::empty() const   { return liste==0;  }
template <typename T>
T stack<T>::top() const     { return liste->hentData(); }

#endif // STACK_H

