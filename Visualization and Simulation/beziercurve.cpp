#include "beziercurve.h"
#include "vertex.h"
#include <cmath>

BezierCurve::BezierCurve(const Vec3 &b0, const Vec3 &b1, const Vec3 &b2, const Vec3 &b3)
{
    setControlPoints(b0, b1, b2, b3);
    initGeometry();
}

void BezierCurve::drawGeometry()
{
    glBindBuffer(GL_ARRAY_BUFFER, mVertexBuffer);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, mIndexBuffer);
    mMaterial->useMaterial();

    //refresh modelMatrix:
    getMatrix();

    mMVPMatrix = mProjectionMatrix*mViewMatrix*mModelMatrix;
    mMaterial->setMVPMatrix(mMVPMatrix);

    // Offset for position
    // Positions are the first data, therefor offset is 0
    int offset = 0;

    // Tell OpenGL programmable pipeline how to locate vertex position data
    glVertexAttribPointer(static_cast<GLuint>(mMaterial->getPositionAttribute()), 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*>(offset));

    // Offset for vertex coordinates
    // before normals
    offset += sizeof(Vec3);

    glVertexAttribPointer(static_cast<GLuint>(mMaterial->getNormalAttribute()), 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*>(offset));

    // Offset for normal coordinates
    // before UVs
    offset += sizeof(Vec2);

    // Tell OpenGL programmable pipeline how to locate vertex texture coordinate data
    glVertexAttribPointer(static_cast<GLuint>(mMaterial->getTextureAttribute()), 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*>(offset));

    // Draw cube geometry using indices from VBO 1

    glDrawElements(GL_LINES, 26, GL_UNSIGNED_SHORT, 0);
    //glDrawArrays(GL_LINES, 0, 100);

    //Unbind buffers:
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);

    //Unbind shader
    glUseProgram(0);
}

int BezierCurve::initGeometry()
{
    //for spiral
    //Vertex vertices[100];
    Vertex vertices[15];
    for (int i=0; i<=10; i++)
    {
        float t = 0.1 * i;
        //Spiral
        //Vec3 hvajegvil(cos(t), sin(t), t);
        //vertices[i].set_xyz(hvajegvil);
        Vec3 b = evaluateBezier(3, t);
        vertices[i].set_xyz(b.x, b.y, b.z);
        vertices[i].set_rgb(1, 0, 0);
    }
    //let you see the first points in that vector, our starting points.
    //spiral = x(t) = cos t, y(t) = sin t,z = t;

    vertices[11].set_xyz(b[0]);
    vertices[12].set_xyz(b[1]);
    vertices[13].set_xyz(b[2]);
    vertices[14].set_xyz(b[3]);

    vertices[11].set_rgb(0, 0, 1);
    vertices[12].set_rgb(0, 0, 1);
    vertices[13].set_rgb(0, 0, 1);
    vertices[14].set_rgb(0, 0, 1);

    GLushort indices[] =
    {
        0,1,1,2,2,3,3,4,4,
        5,5,6,6,7,7,8,8,9,9,10,//,

        11,12,12,13,13,14
    };

    initializeOpenGLFunctions();

    // Transfer vertex data to VBO 0
    glGenBuffers(1, &mVertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, mVertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, 15*sizeof(Vertex), vertices, GL_STATIC_DRAW);

    // Transfer index data to VBO 1
    glGenBuffers(1, &mIndexBuffer);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, mIndexBuffer);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER, 26*sizeof(GLushort), indices, GL_STATIC_DRAW);

  //  delete vertices;
    //delete indices;

    return 0;
}

void BezierCurve::setRendermode(int mode)
{
    if (mode == 1)
        mWireFrame = true;
    else if (mode == 0)
        mWireFrame = false;
}

void BezierCurve::setMaterial(Material *materialIn)
{
    mMaterial = materialIn;
}

void BezierCurve::setControlPoints(const Vec3 &b0, const Vec3 &b1, const Vec3 &b2, const Vec3 &b3)
{
    b[0] = b0;
    b[1] = b1;
    b[2] = b2;
    b[3] = b3;
}

Vec3 BezierCurve::getControlPoints(int controlPointNumber)
{
    return b[controlPointNumber];
}

Vec3 BezierCurve::evaluateBezier(int degree, float t)
{
    //sets c array to be like b
    Vec3 c[4];

    for (int i=0; i<4; i++)
        c[i] = b[i];

    //b[3] = c[0];
    //degree = grad
    for (int k=1; k<=degree; k++)
    {
          //1 grad så er det Tredje: grad(3) - 1 +1 = 3. Andre loop: 2-1 +1= 2. Første: 1-1 +1 = 1.
        for (int i=0; i<degree-k+1; i++)
            //function for de Casteljau
            c[i] = c[i] * (1-t) + c[i+1] * t;
    }
    return c[0];
}

void BezierCurve::setCurvetogether()
{
    //derivation = få stigningstallet
    c[3].x = (b[3].x * 3 - b[2].x * 3);
    c[3].y = (b[3].y * 3 - b[2].y * 3);
    c[3].z = (b[3].z * 3 - b[2].z * 3);
}


