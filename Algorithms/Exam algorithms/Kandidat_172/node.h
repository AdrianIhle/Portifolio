#ifndef NODE_H
#define NODE_H
#include <iostream>

using namespace std;

class node
{
private:
    int mData;

public:
    node(int data = 0, node* next = nullptr);
        node* mNext;
    int getData();
    void setData(int data);
    bool operator == (node node);
    void print(){
        std::cout << " data in Node: "<< mData <<std::endl;
    }


};

#endif // NODE_H
