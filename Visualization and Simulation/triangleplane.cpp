#include "triangleplane.h"

TrianglePlane::TrianglePlane(float xPos, float yPos, float zPos, QString name) : GameObject(xPos, yPos, zPos, name)
{
    initGeometry();
}

TrianglePlane::~TrianglePlane()
{
    delete vertices;
    delete indices;
}

void TrianglePlane::drawGeometry()
{
    glBindBuffer(GL_ARRAY_BUFFER, mVertexBuffer);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, mIndexBuffer);
    mMaterial->useMaterial();

    //refresh modelMatrix:
    getMatrix();

    mMVPMatrix = mProjectionMatrix*mViewMatrix*mModelMatrix;
    mMaterial->setMVPMatrix(mMVPMatrix);

    // Offset for position
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

    // Draw cube geometry using indices from VBO 1
    if (!mWireFrame)
        glDrawElements(GL_TRIANGLES, 42, GL_UNSIGNED_SHORT, 0);
    else
        glDrawElements(GL_LINE_STRIP, 42, GL_UNSIGNED_SHORT, 0);

    //Unbind buffers:
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);

    //Unbind shader
    glUseProgram(0);
}

int TrianglePlane::initGeometry()
{
    vertices = new Vertex[12];

    vertices[0] = Vertex(Vec3(0.0f, 2.0f, 0.0f),Vec3(0.0f, 0.0f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[1] = Vertex(Vec3(0.0f, 2.0f, 1.0f),Vec3(0.0f, 0.1f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[2] = Vertex(Vec3(0.0f, 2.0f, 4.0f),Vec3(0.0f, 0.2f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[3] = Vertex(Vec3(1.0f, 1.0f, 3.0f),Vec3(0.0f, 0.3f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[4] = Vertex(Vec3(1.5f, 2.0f, 0.0f),Vec3(0.0f, 0.4f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[5] = Vertex(Vec3(2.0f, 2.0f, 2.0f),Vec3(0.0f, 0.5f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[6] = Vertex(Vec3(2.5f, 1.0f, 1.0f),Vec3(0.0f, 0.6f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[7] = Vertex(Vec3(2.5f, 2.0f, 4.0f),Vec3(0.0f, 0.7f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[8] = Vertex(Vec3(3.5f, 1.0f, 2.5f),Vec3(0.0f, 0.8f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[9] = Vertex(Vec3(4.0f, 2.0f, 0.0f),Vec3(0.0f, 0.9f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[10] = Vertex(Vec3(4.0f, 2.0f, 0.5f),Vec3(0.0f, 1.0f, 0.0f),Vec2(0.0f, 0.0f));
    vertices[11] = Vertex(Vec3(4.0f, 2.0f, 4.0f),Vec3(0.0f, 1.0f, 0.0f),Vec2(0.0f, 0.0f));


    GLushort tempIndices[43] =
    {
        0, 1, 4,
        1, 2, 3,
        1, 3, 4,
        2, 7, 3,
        3, 5, 4,

        3, 7, 5,
        4, 5, 6,
        4, 6, 9,
        5, 7, 8,
        5, 8, 6,

        6, 8, 10,
        6, 10, 9,
        7, 11, 8,
        8, 11, 10
    };

    indices = new int(42);

    for(int T = 0; T < 42; T++)
    {
        indices[T] = tempIndices[T];
    }

    refreshVertices();

    // Transfer index data to VBO 1
    glGenBuffers(1, &mIndexBuffer);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, mIndexBuffer);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER, 42*sizeof(GLushort), tempIndices, GL_STATIC_DRAW);

    return 0;
}

void TrianglePlane::refreshVertices()
{
    glGenBuffers(1, &mVertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, mVertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, 12*sizeof(Vertex), vertices, GL_STATIC_DRAW);
}

void TrianglePlane::highlightPosition(Vec3 inPos)
{
    int foundTriangle = findTriangleUnder(inPos);

    getP1(foundTriangle)->set_rgb(1, 1, 1);
    refreshVertices();
}

Vertex* TrianglePlane::getP1(int triangle)
{
    return &vertices[indices[triangle * 3]];
}

Vertex* TrianglePlane::getP2(int triangle)
{
    return &vertices[indices[triangle * 3 + 1]];
}

Vertex* TrianglePlane::getP3(int triangle)
{
    return &vertices[indices[triangle * 3 + 2]];
}

int TrianglePlane::findTriangleUnder(Vec3 inPos)
{
    for(int T = 0; T < 14; T++)
    {
        Vec3 barCo = Vec2(inPos.x, inPos.z).getBarCo(getP1(T)->get_xz(), getP2(T)->get_xz(), getP3(T)->get_xz());

        if(barCo.x >= 0 && barCo.y >= 0 && barCo.z >= 0)
        {
            return T;
        }
    }

    return -1;
}

void TrianglePlane::collide(GameObject *collider)
{
    int triangle = findTriangleUnder(collider->mTransform->getPosition());

    if(triangle != -1)
    {
        Vec3 ballToPoint = getP1(triangle)->get_xyz() - collider->mTransform->getPosition();

        Vec3 vector1 = getP1(triangle)->get_xyz() - getP2(triangle)->get_xyz();
        Vec3 vector2 = getP1(triangle)->get_xyz() - getP3(triangle)->get_xyz();
        Vec3 normal;

        normal = Vec3(vector1 ^ vector2).identity();

        if(abs(ballToPoint * normal) < collider->mTransform->getScale().x)
        {
            Vec3 velOntoNorm = normal * (collider->getVelocity() * normal);

            collider->addForce(normal * velOntoNorm.length());
        }
    }
}

void TrianglePlane::setRendermode(int mode)
{
    if (mode == 1)
        mWireFrame = true;
    else if (mode == 0)
        mWireFrame = false;
}

void TrianglePlane::setMaterial(Material *materialIn)
{
    mMaterial = materialIn;
}
