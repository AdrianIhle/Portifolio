#include "gulv.h"
#include "vertex.h"
#include <QDebug>

gulv::gulv() : GameObject()
{

}

void gulv::initVertexBufferObjects()
{
            m_vertices [6];
    //gulv
    //firkant 1 trekant nr 1

    m_vertices[0].set_rgb(40.0,40.0,40.0);
    m_vertices[1].set_rgb(40.0,40.0,40.0);
    m_vertices[2].set_rgb(40.0,40.0,40.0);

    //firkant 1 trekant nr 2

    m_vertices[3].set_rgb(40.0,40.0,40.0);
    m_vertices[4].set_rgb(40.0,40.0,40.0);
    m_vertices[5].set_rgb(40.0,40.0,40.0);







    initializeOpenGLFunctions();

    // Skal nå sende all vertex og color data til ett buffer
    glGenBuffers(1, &m_vertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, 12*sizeof(Vertex), m_vertices, GL_STATIC_DRAW);
}



void gulv::draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute)
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

    glDrawArrays(GL_TRIANGLES, 0, 12); // Nytt
}

