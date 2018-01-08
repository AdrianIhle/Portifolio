#include <QDebug>
#include "tetraeder.h"
#include "vertex.h"

Tetraeder::Tetraeder() : GameObject()
{
}

Tetraeder::~Tetraeder()
{
    //
}
void Tetraeder::initVertexBufferObjects()
{
    Vertex vertices[12];
    //trekant nr 1
    vertices[0].set_xyz(-1.0,0.0,0.0);
    vertices[1].set_xyz(1,0,0);
    vertices[2].set_xyz(0,1,0);

    vertices[0].set_rgb(1.0,0.0,0.0);
    vertices[1].set_rgb(0.0,1.0,0.0);
    vertices[2].set_rgb(0.0,0.0,1.0);

    //trekant nr 2
    vertices[3].set_xyz(1,0,0);
    vertices[4].set_xyz(-1,0,0);
    vertices[5].set_xyz(0,0,1);

    vertices[3].set_rgb(1.0,0.0,0.0);
    vertices[4].set_rgb(0.0,2.0,0.0);
    vertices[5].set_rgb(0.0,0.0,2.0);

    //trekant nr 3
    vertices[6].set_xyz(-1,0,0);
    vertices[7].set_xyz(0,1,0);     //connects to triangel 1 last vertex
    vertices[8].set_xyz(0,0,1);     //connects to triangle 2 last vertex

    vertices[6].set_rgb(1.0,0.0,0.0);
    vertices[7].set_rgb(0.0,2.0,0.0);
    vertices[8].set_rgb(0.0,0.0,3.0);

// //trekant nr 4
    vertices[9].set_xyz(1,0,0);
    vertices[10].set_xyz(0,1,0);
    vertices[11].set_xyz(0,0,1);

    vertices[9].set_rgb(2.0,0.0,0.0);
    vertices[10].set_rgb(0.0,3.0,0.0);
    vertices[11].set_rgb(0.0,0.0,3.0);



    initializeOpenGLFunctions();

    // Skal nå sende all vertex og color data til ett buffer
    glGenBuffers(1, &m_vertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, 12*sizeof(Vertex), vertices, GL_STATIC_DRAW);
}

void Tetraeder::draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute)
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
