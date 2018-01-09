#include "node.h"

node::node(int data, node *next) :
    mData(data), mNext(next)
{

}


int node::getData()
{
    return mData;
}

void node::setData(int data)
{
    mData = data;
}

bool node::node::operator ==(node node)
{
    return(this->mData == node.mData);
}
