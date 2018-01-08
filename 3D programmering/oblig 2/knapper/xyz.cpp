#include "xyz.h"
#include "vertex.h"

XYZ::XYZ() : GameObject()
{
}

XYZ::~XYZ()
{
    //
}

void XYZ::initVertexBufferObjects()
{
    initializeOpenGLFunctions();

    // Lager en array på stakk i stedet for å bruke m_vertices fra gameobject klassen med new
    // Hvert array ser da slik ut: xyzrgbst
    //                             pos   tekstur (trengs ikke her og nå)
    Vertex vertices[6];
    vertices[0].set_xyz(0.0, 0.0, 0.0);
    vertices[1].set_xyz(1.0, 0.0, 0.0);
    vertices[2].set_xyz(0.0, 0.0, 0.0);
    vertices[3].set_xyz(0.0, 1.0, 0.0);
    vertices[4].set_xyz(0.0, 0.0, 0.0);
    vertices[5].set_xyz(0.0, 0.0, 1.0);
    vertices[0].set_rgb(1.0, 0.0, 0.0);
    vertices[1].set_rgb(1.0, 0.0, 0.0);
    vertices[2].set_rgb(0.0, 1.0, 0.0);
    vertices[3].set_rgb(0.0, 1.0, 0.0);
    vertices[4].set_rgb(0.0, 0.0, 1.0);
    vertices[5].set_rgb(0.0, 0.0, 1.0);


    glGenBuffers(1, &m_vertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, 6*sizeof(Vertex), vertices, GL_STATIC_DRAW);
}

void XYZ::draw(GLint positionAttribute, GLint colorAttribute, GLint /*textureAttribute*/)
{
    int offset=0;

    // 0-------1-------2
    // xyzrbgstxyzrgbstxyzrbgstxyzrgbstxyzrbgstxyzrgbst
    // ---0-------1-------2 starter her på offset 3 for å hente fargene til vertex 0
    // xyzrbgstxyzrgbstxyzrbgstxyzrgbstxyzrbgstxyzrgbst
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glVertexAttribPointer(positionAttribute, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*> (offset));

    offset = 3*sizeof(float);
    //glBindBuffer(GL_ARRAY_BUFFER, m_colorBuffer);
    glVertexAttribPointer(colorAttribute, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*> (offset));

    // Tegner nå fra det bufferet vi har satt opp i initVertexBufferObjects
    // arrayen vertices er i sin helhet sendt inn til GPU
    // GL_LINES - hva vi skal tegne
    // 0 - hvor vi skal starte
    // 6 - hvor mange vertices vi skal benytte
    glDrawArrays(GL_LINES, 0, 6);
}
