#ifndef OKTAEDERBALL_H
#define OKTAEDERBALL_H
#include <cmath>
#include <string>
#include "gameobject.h"
#include "vec3.h"
#include "material.h"
#include "transform.h"


class Vertex;
class Ball : public GameObject
{
public:
    Ball(float xPos = 0.0, float yPos = 0.0, float zPos = 0.0, QString name = "Ball", int n=4);
    ~Ball();
    int initGeometry();
    void drawGeometry();
    void setRendermode(int mode);

    void setMaterial(Material *materialIn);

private:
    int mRecursions = 0;
    int mIndex = 0;
    float mRadius = 0;

    GLuint mVertexBuffer;
    GLuint mIndexBuffer;

    Material *mMaterial;

    QMatrix4x4 mMVPMatrix;

    Vertex* mVertices;

    GLuint mNumOfVertices;

    void lagTriangel(const Vec3& v1, const Vec3& v2, const Vec3& v3);
    void subDivide(const Vec3& a, const Vec3& b, const Vec3& c, int n);
    void oktaederUnitBall();
};

#endif
