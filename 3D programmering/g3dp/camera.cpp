#include "camera.h"
Camera::Camera()
{
 m_projectionMatrix.setToIdentity();
 m_viewMatrix.setToIdentity();
}
Camera::~Camera() { }
QMatrix4x4 Camera::getViewMatrix() { return m_viewMatrix; }
QMatrix4x4 Camera::getProjectionMatrix() { return m_projectionMatrix; }

void Camera::setPosition(float x, float y, float z)
{
 m_position.x = x;
 m_position.y = y;
 m_position.z = z;
}
Vec3 Camera::getPosition()
{
 return m_position;
}
void Camera::view()
{
 m_viewMatrix.translate(m_position.x, m_position.y, m_position.z);
}
void Camera::setToIdentity()
{
 m_viewMatrix.setToIdentity();
 m_projectionMatrix.setToIdentity();
}
void Camera::perspective(float verticalAngle, float aspectRatio, float
 nearPlane, float farPlane)
{
 m_projectionMatrix.perspective(verticalAngle, aspectRatio, nearPlane,
 farPlane);
}

