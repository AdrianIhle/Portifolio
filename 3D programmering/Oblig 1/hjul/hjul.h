#ifndef HJUL_H
#define HJUL_H
#include "gameobject.h"


class hjul :public GameObject
{
public:
    hjul();
    void initVertexBufferObjects();
    void draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute=-1);

};

#endif // HJUL_H
