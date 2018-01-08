#include "hjul.h"
#include"vertex.h"
#include <QDebug>
#include <cmath>
#include "math.h"
#define _USE_MATH_DEFINES

hjul::hjul() :GameObject()
{
}

void hjul::initVertexBufferObjects()
{


    float sector = M_PI/12;
            Vertex vertices[26];


    for(float rad = 0.0f; rad <2*M_PI; rad += sector){


        for(int i= 1; i <26; i++)
        {
            rad = i *sector;
            float x = cos(rad);
            float y = sin(rad);
            vertices[i].set_xyz(x,y,0);
            vertices[i].set_rgb(1,0,0);
        }
        vertices[0].set_xyz(0,0,0);

    }
    GLubyte indices[] =
    {
       0,1,2,
       0,2,3,
       0,3,4,
       0,4,5,
       0,5,6,
       0,6,7,
       0,7,8,
       0,8,9,
       0,9,10,
       0,10,11,
       0,11,12,
       0,12,13,
       0,13,14,
       0,14,15,
       0,15,16,
       0,16,17,
       0,17,18,
       0,18,19,
       0,19,20,
       0,20,21,
       0,21,22,
       0,22,23,
       0,23,24,
       0,24,25,
       0,25,26,
       0,26,1
    };


    initializeOpenGLFunctions();

    // Skal nå sende all vertex og color data til ett buffer
    glGenBuffers(1, &m_vertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, 26*sizeof(Vertex), vertices, GL_STATIC_DRAW);

    glGenBuffers(1, &m_indexBuffer);
     glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, m_indexBuffer);
     glBufferData(GL_ELEMENT_ARRAY_BUFFER, 75*sizeof(GLubyte), indices,
     GL_STATIC_DRAW);

}

void hjul::draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute)
{
    initializeOpenGLFunctions();
    // Har en array av strukturer (4 Vertex objekter) som skal splittes på to
    // attributter i vertex shader. stride blir her størrelsen av hver struktur
    // Må bruke offset for start
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glVertexAttribPointer(positionAttribute, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), 0); /// stride 3*sizeof(GL_FLOAT) går også bra!?

    /// Peker til color
    int offset = 3*sizeof(GLfloat);
    glVertexAttribPointer(colorAttribute, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*> (offset)); /// stride 4*sizeof(GL_FLOAT) går også bra!?

    offset = 0*sizeof(GLubyte);
     const void* castedOffset = reinterpret_cast<const void*>(offset);
     glDrawElements(GL_TRIANGLES, 75, GL_UNSIGNED_BYTE, castedOffset);


//    glDrawArrays(GL_TRIANGLES, 0, 26); // Nytt
}


