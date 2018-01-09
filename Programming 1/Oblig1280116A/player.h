#ifndef PLAYER_H
#define PLAYER_H
#include "gameobject.h"

class Player : public GameObject
{
public:
    Player();

    void move();
     char input;
    void draw();
    char getSprite();

};

#endif // PLAYER_H
