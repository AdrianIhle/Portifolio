#include "gameobject.h"
#include "point2.h"
#include <iostream>

using namespace std;
GameObject::GameObject()
{

}



void GameObject::draw()
{
    cout << sprite << position.getX() << position.getY();
}
