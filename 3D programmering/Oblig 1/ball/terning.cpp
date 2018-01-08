#include <QDebug>
#include "terning.h"
#include "vertex.h"

terning::terning() : GameObject()
{

}
terning::~terning()
{

}

void terning::initVertexBufferObjects()
{
    Vertex vertices[36];
    //firkant 1 trekant nr 1
    vertices[0].set_xyz(1,1,1);
    vertices[1].set_xyz(-1,1,1);
    vertices[2].set_xyz(-1,-1,1);

    vertices[0].set_rgb(1.0,0.0,0.0);
    vertices[1].set_rgb(0.0,1.0,0.0);
    vertices[2].set_rgb(0.0,0.0,1.0);

    //firkant 1 trekant nr 2
    vertices[3].set_xyz(1,1,1);
    vertices[4].set_xyz(1,-1,1);
    vertices[5].set_xyz(-1,-1,1);

    vertices[3].set_rgb(1.0,0.0,0.0);
    vertices[4].set_rgb(0.0,2.0,0.0);
    vertices[5].set_rgb(0.0,0.0,2.0);

    //firkant 2 trekant nr 1
    vertices[6].set_xyz(1,1,-1);
    vertices[7].set_xyz(-1,1,-1);
    vertices[8].set_xyz(-1,-1,-1);

    vertices[6].set_rgb(1.0,0.0,0.0);
    vertices[7].set_rgb(0.0,2.0,0.0);
    vertices[8].set_rgb(0.0,0.0,3.0);

// // firkant 2 trekant nr 2
    vertices[9].set_xyz(1,1,-1);
    vertices[10].set_xyz(1,-1,-1);
    vertices[11].set_xyz(-1,-1,-1);

    vertices[9].set_rgb(2.0,0.0,0.0);
    vertices[10].set_rgb(0.0,3.0,0.0);
    vertices[11].set_rgb(0.0,0.0,3.0);

    //firkant 3 trekant nr 1
    vertices[12].set_xyz(1,1,1);
    vertices[13].set_xyz(1,-1,1);
    vertices[14].set_xyz(1,1,-1);

    vertices[12].set_rgb(1.0,0.0,0.0);
    vertices[13].set_rgb(0.0,2.0,0.0);
    vertices[14].set_rgb(0.0,0.0,3.0);

// // firkant 3 trekant nr 2
    vertices[15].set_xyz(1,1,-1);
    vertices[16].set_xyz(1,-1,1);
    vertices[17].set_xyz(1,-1,-1);

    vertices[15].set_rgb(2.0,0.0,0.0);
    vertices[16].set_rgb(0.0,3.0,0.0);
    vertices[17].set_rgb(0.0,0.0,3.0);

    //firkant 4 trekant nr 1
    vertices[18].set_xyz(-1,1,1);
    vertices[19].set_xyz(-1,-1,-1);
    vertices[20].set_xyz(-1,1,-1);

    vertices[18].set_rgb(1.0,0.0,0.0);
    vertices[19].set_rgb(0.0,2.0,0.0);
    vertices[20].set_rgb(0.0,0.0,3.0);

// // firkant 4 trekant nr 2
    vertices[21].set_xyz(-1,1,1);
    vertices[22].set_xyz(-1,-1,1);
    vertices[23].set_xyz(-1,-1,-1);

    vertices[21].set_rgb(2.0,0.0,0.0);
    vertices[22].set_rgb(0.0,3.0,0.0);
    vertices[23].set_rgb(0.0,0.0,3.0);

    //firkant 5 trekant nr 1
    vertices[24].set_xyz(-1,-1,1);
    vertices[25].set_xyz(1,-1,-1);
    vertices[26].set_xyz(-1,-1,-1);

    vertices[24].set_rgb(1.0,0.0,0.0);
    vertices[25].set_rgb(0.0,2.0,0.0);
    vertices[26].set_rgb(0.0,0.0,3.0);

// // firkant 5 trekant nr 2
    vertices[27].set_xyz(-1,-1,1);
    vertices[28].set_xyz(1,-1,1);
    vertices[29].set_xyz(1,-1,-1);

    vertices[27].set_rgb(2.0,0.0,0.0);
    vertices[28].set_rgb(0.0,3.0,0.0);
    vertices[29].set_rgb(0.0,0.0,3.0);

    //firkant 6 trekant nr 1
    vertices[30].set_xyz(-1,1,1);
    vertices[31].set_xyz(-1,1,-1);
    vertices[32].set_xyz(1,1,-1);

    vertices[30].set_rgb(1.0,0.0,0.0);
    vertices[31].set_rgb(0.0,2.0,0.0);
    vertices[32].set_rgb(0.0,0.0,3.0);

// // firkant 6 trekant nr 2
    vertices[33].set_xyz(1,1,-1);
    vertices[34].set_xyz(1,1,1);
    vertices[35].set_xyz(-1,1,1);

    vertices[33].set_rgb(2.0,0.0,0.0);
    vertices[34].set_rgb(0.0,3.0,0.0);
    vertices[35].set_rgb(0.0,0.0,3.0);


    initializeOpenGLFunctions();

    // Skal nå sende all vertex og color data til ett buffer
    glGenBuffers(1, &m_vertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, 36*sizeof(Vertex), vertices, GL_STATIC_DRAW);
}

void terning::draw(GLint positionAttribute, GLint colorAttribute, GLint textureAttribute)
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

    glDrawArrays(GL_TRIANGLES, 0, 36); // Nytt
}
