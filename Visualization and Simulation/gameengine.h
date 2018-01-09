#ifndef GAMEENGINE_H
#define GAMEENGINE_H

#include <QOpenGLWidget>
#include <QOpenGLFunctions>
#include <QMatrix4x4>
#include <QBasicTimer>

#include <QOpenGLShaderProgram>
#include <QOpenGLTexture>

#include <vector>

#include "camera.h"
#include "axesgizmo.h"
#include "skybox.h"
#include "cube.h"
#include "circlesphere.h"
#include "shaderprogram.h"
#include "plane.h"
#include "interactiveball.h"
#include "ball.h"
#include "triangleplane.h"
#include "beziercurve.h"
#include "smoothedlines.h"

class GameEngine : public QOpenGLWidget, protected QOpenGLFunctions
{
    Q_OBJECT

public:
    explicit GameEngine(QWidget *parent = 0);
    ~GameEngine();

    void init();
    void initMaterials();
    //void initTextures();
    void cleanup();

    bool running() { return mRunning; }
    void quit() { mRunning = false; }


signals:
    void initHierarchy(std::vector<GameObject*> &mGeometry);

public slots:
    void axisOnOff();
    void wireFrameOnOff();
    void setCameraColor();
    void orthographicOnOff();

protected:
    //This is the "handleEvents" part:
    void mouseMoveEvent(QMouseEvent *event) Q_DECL_OVERRIDE;
    void keyPressEvent(QKeyEvent *event) Q_DECL_OVERRIDE;
    void keyReleaseEvent(QKeyEvent *event) Q_DECL_OVERRIDE;
    void wheelEvent(QWheelEvent *event) Q_DECL_OVERRIDE;

    void handleKeys();

    void timerEvent(QTimerEvent *e) Q_DECL_OVERRIDE;

    void initializeGL() Q_DECL_OVERRIDE;
    void resizeGL(int w, int h) Q_DECL_OVERRIDE;
    void paintGL() Q_DECL_OVERRIDE;

    Plane* mPlane;
    TrianglePlane* mTrianglePlane;
    GameObject *mPlayer;
    GameObject* mGravBall;
    BezierCurve* mBCurve;
    SmoothedLines* mSmoothLine;
private:
    QBasicTimer mTimer;

    Material *mMaterials[4];

    Camera *mCamera;

    QMatrix4x4 viewMatrix;
    QMatrix4x4 projectionMatrix;

    std::vector<GameObject*> mGeometry;
    std::vector<GameObject*> mColliders;

    GameObject *axes;
    GameObject *skybox;
    GameObject* tempGeometry;
    GameObject *mSosi;

    QString* fragmentShaderFileName;
    QString* vertexShaderFileName;

    bool mRunning;

    bool axisOn = true;
    bool wireFrame = false;
    bool ortho = false;

    int mouseXlast{};
    int mouseYlast{};
    float cameraSpeed = 0.2f;

    //This really! should be made anoter way!
    //Quick hack ahead:
    bool mW = false;
    bool mA = false;
    bool mS = false;
    bool mD = false;
    bool mUp = false;
    bool mDown = false;
    bool mLeft = false;
    bool mRight = false;
    bool mQ = false;
    bool mE = false;

};

#endif // GAMEENGINE_H
