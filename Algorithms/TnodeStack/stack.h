#ifndef STACK_H
#define STACK_H

#include "CharNode.h"

class stack
{
public:
    stack();
    ~stack();
    void push(char tegn);
    void pop();
    int size() const;
    bool empty() const;
    char top() const;
private:
    CharNode* liste;
};

#endif // STACK_H
