#ifndef PLANE_H
#define PLANE_H

#include <QOpenGLFunctions>
#include <QOpenGLShaderProgram>
#include <QOpenGLBuffer>
#include <QMatrix4x4>
#include "vertex.h"
#include "transform.h"
#include "gameobject.h"


class Plane : public GameObject
{
public:
    Plane(float xPos = 0.0, float yPos = 0.0, float zPos = 0.0, QString name = "Plane");
    ~Plane();

    void setRendermode(int mode);
    void setMaterial(Material *materialIn);
    void drawGeometry();

    void highlightPosition(Vec3 inPos);
    void collide(GameObject* collider);

    int getS1(int triangle);
    int getS2(int triangle);
    int getS3(int triangle);

private:
    int findTriangleUnder(Vec3 inPos);

    int initGeometry();
    Vertex* vertices;

    int lastTriangle = 0;
    Vec3 lastColor1;
    Vec3 lastColor2;
    Vec3 lastColor3;

    void refreshVertices();


    //mapSize should be set to the same as pixles on one side of the height map
    //This sets how many vertecies there will be;
    int mapSize = 16;
    //int heightFactor = 500;   //used to scale height - not used now
    float mapFactor = 3.0;      //used to scale width/length - length between vertecies

    GLsizei indexCount;
    QMatrix4x4 mModelMatrix;

    GLuint mVertexBuffer;
    GLuint mIndexBuffer;

    Material *mMaterial;

    QMatrix4x4 mMVPMatrix;


    Vertex* getP1(int triangle);
    Vertex* getP2(int triangle);
    Vertex* getP3(int triangle);
};

#endif // PLANE_H
