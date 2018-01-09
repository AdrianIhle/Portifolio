#ifndef BEZIERCURVE_H
#define BEZIERCURVE_H

#include "vec3.h"
#include "gameobject.h"
#include "vertex.h"

class BezierCurve : public GameObject
{
public:
    BezierCurve(const Vec3 &b0, const Vec3 &b1, const Vec3 &b2, const Vec3 &b3);
    void drawGeometry();
    int initGeometry();
    void setRendermode(int mode);
    void setMaterial(Material *materialIn);
    void setControlPoints(const Vec3 &b0,const Vec3& b1, const Vec3& b2,const Vec3 &b3);
    void setNewControlPoint(const Vec3 &b);
    Vec3 getControlPoints(int controlPointNumber);
    Vec3 evaluateBezier(int degree,float t);
    void setCurvetogether();

private:
    Vec3 b[4];
    std::vector<Vec3> mControlPoints;
    int vertexCount = 0;
    Vec3 c[4]; //controlpoints to second curve
};

#endif // BEZIERCURVE_H
