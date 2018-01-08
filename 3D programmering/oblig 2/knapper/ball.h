#ifndef BALL_H
#define BALL_H

#include <cmath>
#include <string>
#include "gameobject.h"
#include "vec3.h"

class Vertex;

//!
//! \brief The OktaederBall class implements recursive subdivision of an Octahedron
//!
//! The class implements recursive subdivision of an regular Octahedron to visualize a ball with
//! glDrawArrays() and GL_TRIANGLES
//!
//! The original Octahedron has 6 vertices on the unit ball:
//! - top (0, 0, 1)
//! - bottom (0, 0, -1)
//! - four equidistant vertices in the xy-plane
//! This 6 vertices defines 8 triangles
class ball : public GameObject
{
private:
    int m_rekursjoner;          //
    int m_indeks;               // brukes i rekursjon, til å bygge m_vertices

    void lagTriangel(const Vec3& v1, const Vec3& v2, const Vec3& v3);
    void subDivide(const Vec3& a, const Vec3& b, const Vec3& c, int n);
    void oktaederUnitBall();
public:
    ball(int n=0);
    ~ball();
    void initVertexBufferObjects();
    void draw(GLint positionAttribute, GLint normalAttribute, GLint textureAttribute=-1);
};


#endif // BALL_H
