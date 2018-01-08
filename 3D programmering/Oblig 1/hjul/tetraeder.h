#ifndef TETRAEDER_H
#define TETRAEDER_H

#include "gameobject.h"

class Tetraeder : public GameObject
{
private:

public:
    Tetraeder();
    ~Tetraeder();
    void initVertexBufferObjects();
    void draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute=-1);
};

#endif // TETRAEDER_H
