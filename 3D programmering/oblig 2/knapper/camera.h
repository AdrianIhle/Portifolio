#ifndef CAMERA_H
#define CAMERA_H
#include <QtGui/QMatrix4x4>
#include "vec3.h"
class Camera
{
private:
 // Vi trenger "view-delen" av modelviewmatrisen
 // og lar navnet reflektere dette
 QMatrix4x4 m_viewMatrix;
 QMatrix4x4 m_projectionMatrix;
 Vec3 m_position;
public:
 Camera();
 ~Camera();
 QMatrix4x4 getViewMatrix();
 QMatrix4x4 getProjectionMatrix();
 void setToIdentity();
 void perspective(float verticalAngle, float aspectRatio, float nearPlane,
 float farPlane);
 void setPosition(float x, float y, float z);
 Vec3 getPosition();
 void view();
};
#endif // CAMERA_H
