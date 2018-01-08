#include "gameobject.h"
#include "vertex.h"

//! \brief Default constructor which ony initializes everything to zero.
GameObject::GameObject() : QOpenGLFunctions(),//QOpenGAmeWidget(), QOpenGLFunctions()
    m_vertexBuffer(0), m_vertices(0), m_antallVertices(0), m_texture(0)
{

}

GameObject::~GameObject()
{
    glDeleteBuffers(1, &m_vertexBuffer);
    glDeleteBuffers(1, &m_indexBuffer);

    qDebug() << "DisplayObject::~DisplayObject()";
}

void GameObject::setTexture(GLuint texture)
{
    m_texture = texture;
}
