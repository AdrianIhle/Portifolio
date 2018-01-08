#ifndef GULV_H
#define GULV_H
#include "gameobject.h"

class gulv : public GameObject
{
public:
    gulv();
    void initVertexBufferObjects();
    void draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute=-1);
};

#endif // GULV_H
