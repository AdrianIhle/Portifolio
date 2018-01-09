#ifndef SMOOTHEDLINES_H
#define SMOOTHEDLINES_H
#include "beziercurve.h"

class SmoothedLines : public GameObject
{
private:

    std::vector<Vec3> controlPoints;
    unsigned int vertexCount = 0;


public:
    std::vector<BezierCurve*> bezList;
    SmoothedLines(const Vec3 &b0 = Vec3(0,0,0),const Vec3 &b1 = Vec3(0,1,0),const Vec3 &b2 = Vec3(0,2,1),const Vec3 &b3= Vec3(0,5,2));
    void setNewControlPoint(const Vec3 &b);
    void createNewCurve(const Vec3 &b0,const Vec3 &b1,const Vec3 &b2,const Vec3 &b3);
    void setControlPoints(const Vec3 &b0, const Vec3 &b1, const Vec3 &b2, const Vec3 &b3);
    void drawGeometry();
    int initGeometry();
    void setRendermode(int mode);
    void setMaterial(Material *materialIn);
    Vec3 getControlPoint(int controlPointNumber);
    Vec3 evaluateBezier(int degree, float t);

};

#endif // SMOOTHEDLINES_H
