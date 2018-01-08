    #ifndef GLWIDGET_H
#define GLWIDGET_H

#include <QOpenGLWidget>
#include <QtGui/QOpenGLShaderProgram>
#include <QtGui/QMatrix4x4>
#include <QtGui/QScreen>
#include <QOpenGLFunctions>
#include <QTime>
#include "vec3.h"
#include "camera.h"

class MainWindow;
class GameObject;
class ShaderProgramObjekt;
class Texture;

class GameWidget : public QOpenGLWidget, protected QOpenGLFunctions
{
    Q_OBJECT
public:
    explicit GameWidget(MainWindow *parent = 0);
    ~GameWidget();

signals:

public slots:

    void klikket();
    void redigert();
    //ikke lag eget slot her - det er protected i QWidget
    void update();
    void repaint();
    //void initializeShader();

protected:
    void initializeGL();
    void paintGL();
    void resizeGL(int width, int height);

private:
    QSize sizeHint() const;

    void setWallsAndFloor();

    ShaderProgramObjekt* m_shaderProgramObjekt; // Erstatter QOpenGLShaderProgram* m_program;

    // Variabler til å lagre referanser for shadervariabler
    // Disse hentes ut fra shaderen
    QMatrix4x4 m_MVMatrix;
    QMatrix4x4 m_PMatrix;

    GLuint m_positionAttribute;
    GLuint m_colorAttribute;
    GLuint m_uniformPMatrix;
    GLuint m_uniformMVMatrix;

    // Tekstur tillegg
    GLuint m_textureAttribute;
    GLuint m_uniformSampler;
    //GLuint m_uniformLightPosition;
    Texture* m_texture;

    int m_frame;
    QTimer* m_timer;
    static int m_frame0;    // 160105
    static int m_tid0;      //

    MainWindow* m_parent;
    GameObject* m_tetraeder;
    GameObject* m_terning;

    GameObject* vegg1;
    GameObject* vegg2;
    GameObject* vegg3;
    GameObject* vegg4;

    GameObject* Husvegg1;
    GameObject* Husvegg2;
    GameObject* Husvegg3;
    GameObject* Husvegg4;
    GameObject* Husvegg5;
    GameObject* tak;
    GameObject* door1;
    GameObject* door2;


    GameObject* m_gulv;

    GameObject* m_hjul;
    GameObject* m_hjul2;

    GameObject* m_xyz;
    GameObject* m_ball;
    GameObject* objectList[40];
    Camera* m_camera;

    QOpenGLContext* m_context;
    QTime* m_tid;
    QString m_message;      // 160914

};

#endif // GAMEWIDGET_H
