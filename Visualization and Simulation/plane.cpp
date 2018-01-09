#include "plane.h"
#include <QImage>
#include "cmath"

Plane::Plane(float xPos, float yPos, float zPos, QString name) : GameObject(xPos, yPos, zPos, name)
{
    // Initializes map geometry and transfers it to VBOs
    initGeometry();
}

Plane::~Plane()
{
    delete vertices;
}

int Plane::initGeometry()
{
    //For height maps:
    //QImage *height = new QImage("Orf::assetFilePath + height.jpg");
    //    for (int i = 0; i< mapSize*2; i++)
    //    {
    //        qDebug() << i << " " << qBlue(height->pixel(i, 0));
    //    }

    //Make the array for all the vertecies:
    vertices = new Vertex[mapSize*mapSize];

    //Double for-loop to make the vertecies by row and coloumn
    for(int row = 0; row < mapSize; row++)
    {
        for(int col = 0; col < mapSize; col++)
        {
            vertices[col + (row * mapSize)] = {

                    //This is what I use when reading height from heightmap:
                    //              x,                 y (-128 for height +-128),                            z
                    //Vec3(col*mapFactor, (float(qBlue(height->pixel(col, row)))-128.0f)/heightFactor,  row*mapFactor),


                    //The height (y-value) here is just an arbertrary formula to get some variation:
                    Vec3(col*mapFactor, cos(float(row)/2 + 0.7) * 6 - 6 - 0.15f * col,  row*mapFactor),
                    Vec3(float(col)/mapSize, float(row)/mapSize,  (0.0f+col)/8),  //normal - not real normal calculation...
                    Vec2(0.0f, 0.0f)} ;        //texture coordinates
        }
    }

    // Calculate how may indicies the map needs:
    // each row = mapsize * 2
    // number of rows = mapSize -1
    // between rows we need 2 extra indicies for empty triangles
    indexCount = mapSize * 2 * (mapSize-1) + (mapSize-2) * 2;

    GLushort *indices = new GLushort[indexCount];
    int indexIndicies = 0;

    for(int row = 0; row < mapSize; row++)
    {
        //make coloumns
        for(int col = 0; col < (mapSize); col++)
        {
            indices[indexIndicies] = row * mapSize + col;
            indexIndicies++;
            indices[indexIndicies] = row * mapSize + col + mapSize;
            //         0, 4, 1, 5, 2, 6, 3, 7,       // 0, 0+size, 1, 1+size, etc.
            //         7, 4,   //degenerated, empty    // last of previous, first of comming
            //         4, 8, 5, 9, 6, 10, 7, 11,       // row*size+col, size*2+1, row*size+col, size*2+2, etc.
            //         11, 8,  //degenerated, empty    // last of previous, first of comming
            //         8, 12, 9, 13, 10, 14, 11, 15    // size*2, size*3+1, size*2+1, size*3+2, etc.
            indexIndicies++;
        }
        //make empty triangles before next row
        if (row < (mapSize-2))
        {
            indices[indexIndicies] = indices[indexIndicies-1];
            indexIndicies++;
            indices[indexIndicies] = (row+1) * mapSize;
            indexIndicies++;
        }
        if (indexIndicies == indexCount )
            break;

    }

    refreshVertices();

    // Transfer index data to VBO 1
    glGenBuffers(1, &mIndexBuffer);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, mIndexBuffer);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER, indexCount*sizeof(GLushort), indices, GL_STATIC_DRAW);

    lastColor1 = getP1(lastTriangle)->get_normal();
    lastColor2 = getP2(lastTriangle)->get_normal();
    lastColor3 = getP3(lastTriangle)->get_normal();

    return 0;
}

int Plane::getS1(int triangle)
{
    if((triangle + 1) % ((mapSize - 1) * 2) == 0)
    {
        return -1;
    }else
    {
        return triangle + 1;
    }
}

int Plane::getS2(int triangle)
{
    if(triangle % ((mapSize - 1) * 2) == 0)
    {
        return -1;
    }else
    {
        return triangle - 1;
    }
}

int Plane::getS3(int triangle)
{
    int row = triangle / ((mapSize - 1) * 2); // when converted to int, a number is rounded down

    if((row == 0 && triangle % 2 == 0) || (row == mapSize - 2 && triangle % 2 == 1))
    {
        return -1;
    }
    return triangle - ((mapSize - 1) * 2 - 1) + ((mapSize - 1) * 2 - 1) * (triangle % 2) * 2;
}

Vertex* Plane::getP1(int triangle)
{
    int row = triangle / ((mapSize - 1) * 2); // when converted to int, a number is rounded down
    return &vertices[triangle/2 + row + (triangle % 2) * mapSize];
}

Vertex* Plane::getP2(int triangle)
{
    int row = triangle / ((mapSize - 1) * 2); // when converted to int, a number is rounded down
    return &vertices[(triangle/2 + row + 1 + (triangle % 2) * mapSize)];
}

Vertex* Plane::getP3(int triangle)
{
    int row = triangle / ((mapSize - 1) * 2); // when converted to int, a number is rounded down
    return &vertices[triangle/2 + row + mapSize + (triangle % 2) * (1 - mapSize)];
}

void Plane::collide(GameObject *collider)
{
    int triangle = findTriangleUnder(collider->mTransform->getPosition());

    if(triangle != -1)
    {
        Vec3 ballToPoint = getP1(triangle)->get_xyz() - collider->mTransform->getPosition();

        Vec3 vector1 = getP1(triangle)->get_xyz() - getP2(triangle)->get_xyz();
        Vec3 vector2 = getP1(triangle)->get_xyz() - getP3(triangle)->get_xyz();
        Vec3 normal;

        if(triangle % 2 == 0)
        {
            normal = Vec3(vector2 ^ vector1).identity();
        }else
        {
            normal = Vec3(vector1 ^ vector2).identity();
        }

        if(abs(ballToPoint * normal) < collider->mTransform->getScale().x)
        {
            Vec3 velOntoNorm = normal * (collider->getVelocity() * normal);

            collider->addForce(normal * velOntoNorm.length());
        }
    }
}

void Plane::highlightPosition(Vec3 inPos)
{
    int foundTriangle = findTriangleUnder(inPos);
    if(foundTriangle != lastTriangle && foundTriangle != -1)
    {
        getP1(lastTriangle)->set_rgb(lastColor1.x, lastColor1.y, lastColor1.z);
        getP2(lastTriangle)->set_rgb(lastColor2.x, lastColor2.y, lastColor2.z);
        getP3(lastTriangle)->set_rgb(lastColor3.x, lastColor3.y, lastColor3.z);

        lastTriangle = foundTriangle;

        lastColor1 = getP1(lastTriangle)->get_normal();
        lastColor2 = getP2(lastTriangle)->get_normal();
        lastColor3 = getP3(lastTriangle)->get_normal();

        getP1(lastTriangle)->set_rgb(1.0f, 0.0f, 0.0f);
        getP2(lastTriangle)->set_rgb(1.0f, 0.0f, 0.0f);
        getP3(lastTriangle)->set_rgb(1.0f, 0.0f, 0.0f);
        refreshVertices();
    }
}

int Plane::findTriangleUnder(Vec3 inPos)
{
    Vec3 barCo = Vec2(inPos.x, inPos.z).getBarCo(getP1(lastTriangle)->get_xz(), getP2(lastTriangle)->get_xz(), getP3(lastTriangle)->get_xz());
    int triangle = lastTriangle;

    while((barCo.x < 0 || barCo.y < 0 || barCo.z < 0) && triangle != -1)
    {
        if(barCo.x < barCo.y && barCo.x < barCo.z)
        {
            triangle = getS1(triangle);
        }else if(barCo.y < barCo.x && barCo.y < barCo.z)
        {
            triangle = getS2(triangle);
        }else
        {
            triangle = getS3(triangle);
        }

        if(triangle != -1)
        {
            barCo = Vec2(inPos.x, inPos.z).getBarCo(getP1(triangle)->get_xz(), getP2(triangle)->get_xz(), getP3(triangle)->get_xz());
        }
    }

    return triangle;
}

void Plane::refreshVertices()
{
    // Transfer vertex data to VBO 0
    glGenBuffers(1, &mVertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, mVertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, mapSize*mapSize*sizeof(Vertex), vertices, GL_STATIC_DRAW);
}

void Plane::drawGeometry()
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
        glDrawElements(GL_TRIANGLE_STRIP, indexCount, GL_UNSIGNED_SHORT, 0);
    else
        glDrawElements(GL_LINE_STRIP, indexCount, GL_UNSIGNED_SHORT, 0);

    //Unbind buffers:
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);

    //Unbind shader
    glUseProgram(0);
}

void Plane::setRendermode(int mode)
{
    if (mode == 1)
        mWireFrame = true;
    else if (mode == 0)
        mWireFrame = false;
}

void Plane::setMaterial(Material *materialIn)
{
    mMaterial = materialIn;
}
