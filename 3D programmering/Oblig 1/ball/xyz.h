#ifndef XYZ_H
#define XYZ_H

#include "gameobject.h"

class XYZ : public GameObject
{
private:
    //GLuint m_vertexBuffer;
    //GLuint m_colorBuffer;

public:
    XYZ();
    ~XYZ();
    void initVertexBufferObjects();
    void draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute=-1);
};

#endif // XYZ_H
