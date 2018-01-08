#ifndef TERNING_H
#define TERNING_H

#include "gameobject.h"

class terning : public GameObject
{
public:
    terning();
    ~terning();
    void initVertexBufferObjects();
    void draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute=-1);
};

#endif // TERNING_H
