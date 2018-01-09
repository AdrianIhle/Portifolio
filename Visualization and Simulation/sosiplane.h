#ifndef SOSIPLANE_H
#define SOSIPLANE_H

#include "gameobject.h"
#include "vertex.h"


class SOSIplane : public GameObject
{
public:
    SOSIplane(QString path = "", float scale = 1.0f, float heightDivide = 1.0f, float xPos = 0.0f, float yPos = 0.0f, float zPos = 0.0f, QString nameIn = "SOSIplane");
    void drawGeometry();
    void setMaterial(Material* materialIn);
    void setRendermode(int mode);

private:
    int initGeometry();
    int initGeometry(std::string filePath);
    float mScale;
    Vertex* mVertices;
    GLushort* mIndices;
    float mHeightScale;
    int numOfVertices{0};
    int numOfIndices{0};

};


#endif // SOSIPLANE_H
