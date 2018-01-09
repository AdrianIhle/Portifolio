#include "ball.h"
#include "vertex.h"

Ball::Ball(float xPos, float yPos, float zPos, QString name, int n) : mRecursions(n), mIndex(0), GameObject(xPos, yPos, zPos, name)
{
    mRadius = 1.0f;
    mNumOfVertices = 3 * 8 * pow(4, mRecursions);
    mVertices = new Vertex[mNumOfVertices];
    oktaederUnitBall();
    initGeometry();
}

Ball::~Ball()
{

}
//makes a triangel
void Ball::lagTriangel(const Vec3& v1, const Vec3& v2, const Vec3& v3)
{
    mVertices[mIndex].set_xyz(v1.x, v1.y, v1.z);
    mVertices[mIndex].set_normal(v1.x, v1.y, v1.z);
    mVertices[mIndex++].set_st(0.0f, 0.0f);
    mVertices[mIndex].set_xyz(v2.x, v2.y, v2.z);
    mVertices[mIndex].set_normal(v2.x, v2.y, v2.z);
    mVertices[mIndex++].set_st(1.0f, 0.0f);
    mVertices[mIndex].set_xyz(v3.x, v3.y, v3.z);
    mVertices[mIndex].set_normal(v3.x, v3.y, v3.z);
    mVertices[mIndex++].set_st(0.5f, 1.0f);
}
//subdivides triangles a set number of times
void Ball::subDivide(const Vec3& a, const Vec3& b, const Vec3& c, int n)
{
    if (n>0) {
        Vec3 v1 = a+b; v1.normalize();
        Vec3 v2 = a+c; v2.normalize();
        Vec3 v3 = c+b; v3.normalize();
        subDivide(a, v1, v2, n-1);
        subDivide(c, v2, v3, n-1);
        subDivide(b, v3, v1, n-1);
        subDivide(v3, v2, v1, n-1);
    } else {
        lagTriangel(a, b, c);
    }
}
//creates an octrahedron based ball
void Ball::oktaederUnitBall()
{
    Vec3 v0(0, 0, 1);
    Vec3 v1(1, 0, 0);
    Vec3 v2(0, 1, 0);
    Vec3 v3(-1, 0, 0);
    Vec3 v4(0, -1, 0);
    Vec3 v5(0, 0, -1);
    subDivide(v0, v1, v2, mRecursions);
    subDivide(v0, v2, v3, mRecursions);
    subDivide(v0, v3, v4, mRecursions);
    subDivide(v0, v4, v1, mRecursions);
    subDivide(v5, v2, v1, mRecursions);
    subDivide(v5, v3, v2, mRecursions);
    subDivide(v5, v4, v3, mRecursions);
    subDivide(v5, v1, v4, mRecursions);
}

int Ball::initGeometry()
{
    initializeOpenGLFunctions();
    glGenBuffers(1, &mVertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, mVertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, mNumOfVertices*sizeof(Vertex),mVertices, GL_STATIC_DRAW);
}

void Ball::drawGeometry()
{
    glBindBuffer(GL_ARRAY_BUFFER, mVertexBuffer);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, mIndexBuffer);
    mMaterial->useMaterial();

    //refresh modelMatrix:
    getMatrix();

    mMVPMatrix = mProjectionMatrix*mViewMatrix*mModelMatrix;
    mMaterial->setMVPMatrix(mMVPMatrix);

    int offset = 0;

    // Tell OpenGL programmable pipeline how to locate vertex position data
    glVertexAttribPointer(static_cast<GLuint>(mMaterial->getPositionAttribute()), 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*>(offset));

    // Offset for vertex coordinates
    // before normals
    offset += sizeof(Vec3);

    glVertexAttribPointer(static_cast<GLuint>(mMaterial->getNormalAttribute()), 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*>(offset));

    // Offset for normal coordinates
    // before UVs
    offset += sizeof(Vec3);

    // Tell OpenGL programmable pipeline how to locate vertex texture coordinate data
    glVertexAttribPointer(static_cast<GLuint>(mMaterial->getTextureAttribute()), 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*>(offset));

    glDrawArrays(GL_TRIANGLES, 0, mNumOfVertices);

    //Unbind buffers:
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);

    //Unbind shader
    glUseProgram(0);
}

void Ball::setRendermode(int mode)
{
    if (mode == 1)
        mWireFrame = true;
    else if (mode == 0)
        mWireFrame = false;
}

void Ball::setMaterial(Material *materialIn)
{
    mMaterial = materialIn;
}
