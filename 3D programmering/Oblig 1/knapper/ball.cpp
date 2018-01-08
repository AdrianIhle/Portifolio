#include "ball.h"

// OktaederBall
// Approksimasjon av kule med rekursiv oktaeder subdivisjon
#include <iostream>
#include <sstream>
#include "vertex.h"


ball::ball(int n) : m_rekursjoner(n), m_indeks(0), GameObject()
{
    m_antallVertices = 3 * 8 * pow(4, m_rekursjoner);
    m_vertices = new Vertex[m_antallVertices];
    oktaederUnitBall();
}

//!
//! \brief OktaederBall::~OktaederBall() virtual destructor
//!
ball::~ball()
{
    delete [] m_vertices;
}

// Parametre inn: xyz koordinatene til et triangle v1, v2, v3 ccw
// Bevarer orienteringen av hjørnene
//!
//! \brief OktaederBall::lagTriangel()
//! \param v1 - position on the unit ball for vertex 1
//! \param v2 - position on the unit ball for vertex 2
//! \param v3 - position on the unit ball for vertex 3
//!
//! lagTriangel() creates vertex data for a triangle's 3 vertices. This is done in the
//! final step of recursion.
//!
void ball::lagTriangel(const Vec3& v1, const Vec3& v2, const Vec3& v3)
{
    m_vertices[m_indeks].set_xyz(v1.x, v1.y, v1.z);
    m_vertices[m_indeks].set_normal(v1.x, v1.y, v1.z);
    m_vertices[m_indeks++].set_st(0.0f, 0.0f);
    m_vertices[m_indeks].set_xyz(v2.x, v2.y, v2.z);
    m_vertices[m_indeks].set_normal(v2.x, v2.y, v2.z);
    m_vertices[m_indeks++].set_st(1.0f, 0.0f);
    m_vertices[m_indeks].set_xyz(v3.x, v3.y, v3.z);
    m_vertices[m_indeks].set_normal(v3.x, v3.y, v3.z);
    m_vertices[m_indeks++].set_st(0.5f, 1.0f);
}

// Rekursiv subdivisjon av triangel
//!
//! \brief OktaederBall::subDivide() recursive subdivision of a triangel
//! \param a coordinates for vertex a
//! \param b coordinates for vertex b
//! \param c coordinates for vertex c
//! \param n level of recursion
//!
//! The function tests
//! (if n>0)
//! - three new edge midpoints are computed and normalized,
//! - four new calls to subDivide() is done - one for each new triangle, preserving orientation
//! and with decreased parameter n
//! else
//! - call lagTriangel(a, b, c)
//!
void ball::subDivide(const Vec3& a, const Vec3& b, const Vec3& c, int n)
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

//!
//! \brief OktaederBall::oktaederUnitBall() creates 8 unit ball vertices and call subDivide()
//!
//! If the parameter n of the construktor OktaederBall() is zero, the result will be the
//! original octahedron consisting of 8 triangles with duplicated vertices.
//!
void ball::oktaederUnitBall()
{
    Vec3 v0(0, 0, 1);
    Vec3 v1(1, 0, 0);
    Vec3 v2(0, 1, 0);
    Vec3 v3(-1, 0, 0);
    Vec3 v4(0, -1, 0);
    Vec3 v5(0, 0, -1);

    subDivide(v0, v1, v2, m_rekursjoner);
    subDivide(v0, v2, v3, m_rekursjoner);
    subDivide(v0, v3, v4, m_rekursjoner);
    subDivide(v0, v4, v1, m_rekursjoner);
    subDivide(v5, v2, v1, m_rekursjoner);
    subDivide(v5, v3, v2, m_rekursjoner);
    subDivide(v5, v4, v3, m_rekursjoner);
    subDivide(v5, v1, v4, m_rekursjoner);
}

//!
//! \brief OktaederBall::initVertexBufferObjects() calls glGenBuffers(), glBindBuffer() and glBufferdata()
//! for using later use of glDrawArrays()
//!
void ball::initVertexBufferObjects()
{
    initializeOpenGLFunctions();

    glGenBuffers(1, &m_vertexBuffer);
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glBufferData(GL_ARRAY_BUFFER, m_antallVertices*sizeof(Vertex),m_vertices, GL_STATIC_DRAW);
}

//!
//! \brief OktaederBall::draw() draws a ball using glDrawArrays()
//! \param positionAttribute    vertex shader variable for position
//! \param normalAttribute      vertex shader variable for normal or color
//! \param textureAttribute     vertex shader variable for texture coordinates (optional)
//!
//! draw()
//! - glBindBuffer()
//! - glVertexAttribPointer()
//! - glBindTexture()
//! - glVertexAttribPointer()
//! - glDrawArrays() with GL_TRIANGLES
//!
void ball::draw(GLint positionAttribute, GLint normalAttribute, GLint textureAttribute)
{
    int offset = 0;
    glBindBuffer(GL_ARRAY_BUFFER, m_vertexBuffer);
    glVertexAttribPointer(positionAttribute, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*> (offset)); /// stride 3*sizeof(GL_FLOAT) går også bra!?
    offset = 3*sizeof(GLfloat);

    glVertexAttribPointer(normalAttribute, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*> (offset)); /// stride 3*sizeof(GL_FLOAT) går også bra!?

    // For senere teksturering
    glBindTexture(GL_TEXTURE_2D, m_texture);
    if (textureAttribute != -1)
    {
        offset = 6*sizeof(GLfloat);
        glVertexAttribPointer(textureAttribute, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), reinterpret_cast<const void*> (offset));
    }
    glDrawArrays(GL_TRIANGLES, 0, m_antallVertices);
}
