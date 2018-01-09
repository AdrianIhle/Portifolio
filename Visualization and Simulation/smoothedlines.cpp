#include "smoothedlines.h"
#include "vertex.h"

SmoothedLines::SmoothedLines(const Vec3 &b0,const Vec3 &b1,const Vec3 &b2,const Vec3 &b3)
{
    name = "smooth Line";
    setControlPoints(b0,b1,b2,b3);
    createNewCurve(b0,b1,b2,b3);
}

void SmoothedLines::setNewControlPoint(const Vec3 &b)
{
    controlPoints.push_back(b);
    vertexCount++;

}

void SmoothedLines::createNewCurve(const Vec3 &b0, const Vec3 &b1, const Vec3 &b2, const Vec3 &b3)
{
    bezList.push_back(new BezierCurve(b0,b1,b2,b3));
    setControlPoints(b0,b1,b2,b3);
}

void SmoothedLines::drawGeometry()
{
    for(unsigned int i = 0; i < bezList.size(); i++)
    {
        bezList[i]->drawGeometry();
    }
}

int SmoothedLines::initGeometry()
{
    for(int i = 0; i < bezList.size(); i++)
    {
        bezList[i]->initGeometry();
    }
}

void SmoothedLines::setRendermode(int mode)
{
    for(int i = 0; i < bezList.size(); i++)
    {
    if (mode == 1)
        mWireFrame = true;
    else if (mode == 0)
        mWireFrame = false;
    }
}

void SmoothedLines::setMaterial(Material *materialIn)
{
    for(int i = 0; i < bezList.size(); i++)
    {
        bezList[i]->setMaterial(materialIn);
    }
}

void SmoothedLines::setControlPoints(const Vec3 &b0, const Vec3 &b1, const Vec3 &b2, const Vec3 &b3)
{
    controlPoints.push_back(b0);
    controlPoints.push_back(b1);
    controlPoints.push_back(b2);
    controlPoints.push_back(b3);
    vertexCount += 4;
}

Vec3 SmoothedLines::getControlPoint(int controlPointNumber)
{
    return controlPoints[controlPointNumber];
}

Vec3 SmoothedLines::evaluateBezier(int degree, float t)
{
    Vec3 c[vertexCount];

    for(int i=0;i<vertexCount;i++)
        c[i]=controlPoints[i];

    for(int k=1;k<=degree;k++)
    {
        for(int i=0;i<degree-k+1;i++)
            c[i]=c[i]*(1-t)+c[i+1]*t;
    }

    return c[0];
}
