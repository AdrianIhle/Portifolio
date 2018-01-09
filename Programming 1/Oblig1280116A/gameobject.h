#ifndef GAMEOBJECT_H
#define GAMEOBJECT_H
#include "point2.h"

class GameObject
{
public:
    GameObject();

    Point2 position;

    void draw();
    void move();

protected:
    char sprite;
};



#endif // GAMEOBJECT_H
