#ifndef NPC_H
#define NPC_H
#include "gameobject.h"


class NPC : public GameObject
{
public:
    NPC();
    void draw();
    bool move(Point2 positionIn);
    char getSprite();
    int xDistance;
    int yDistance;
    bool stillPlaying = true;

};

#endif // NPC_H
