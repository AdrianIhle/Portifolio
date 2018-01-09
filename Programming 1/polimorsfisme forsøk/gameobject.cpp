#include "gameobject.h"
#include "point2.h"
#include <iostream>

using namespace std;
GameObject::GameObject()
{

}



void GameObject::draw()             //not used
{
    cout <<" moving " << endl;
}

Point2 GameObject::getPosition()        //gives the position of the requested class
{
    return position;
}
