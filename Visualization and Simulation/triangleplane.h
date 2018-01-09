#ifndef TRIANGLEPLANE_H
#define TRIANGLEPLANE_H

#include <QOpenGLFunctions>
#include <QOpenGLShaderProgram>
#include <QOpenGLBuffer>
#include <QMatrix4x4>
#include "vertex.h"
#include "transform.h"
#include "gameobject.h"

class TrianglePlane : public GameObject
{
public:
    TrianglePlane(float xPos = 0.0, float yPos = 0.0, float zPos = 0.0, QString name = "TriPlane");
    ~TrianglePlane();

    void drawGeometry();
    void highlightPosition(Vec3 inPos);
    void collide(GameObject *collider);
    void setRendermode(int mode);
    void setMaterial(Material *materialIn);


private:
    int findTriangleUnder(Vec3 inPos);
    int initGeometry();

    Vertex* vertices;
    int* indices;

    void refreshVertices();

    GLsizei indexCount;
    Vertex* getP1(int triangle);
    Vertex* getP2(int triangle);
    Vertex* getP3(int triangle);



};

#endif // TRIANGLEPLANE_H
