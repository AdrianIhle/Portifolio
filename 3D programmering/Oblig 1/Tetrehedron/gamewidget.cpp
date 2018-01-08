/**
 * @file glwidget.cpp
 * @author Dag Nylund
 * @date 16.04.2013
 *
 *
 */
#include <QStatusBar>
#include <QMainWindow>
#include <QtGui/QOpenGLFunctions>
#include <QTimer>
#include <ctime>
#include <QPushButton>
#include "gamewidget.h"
#include "mainWindow.h"
#include "gameobject.h"
#include "tetraeder.h"
#include "xyz.h"
#include "shaderprogram.h"
#include "Texture.h"
int GameWidget::m_frame0 = 0;
int GameWidget::m_tid0 = 0;

/**
 * @brief GameWidget::GameWidget.
 * @param parent Peker til mainWindow
 *
 * Konstruktør som initierer @var m_parent og oppretter en timer
 */
GameWidget::GameWidget(MainWindow *parent) : QOpenGLWidget( parent),
    m_parent(parent),  m_frame(0), m_shaderProgramObjekt(0), QOpenGLFunctions()//, m_lightPosition(-5.0, -3.0, -3.0)
{
    m_timer = new QTimer();
    connect(m_timer, SIGNAL(timeout()), this, SLOT(update()));

    m_tetraeder = new Tetraeder();
    m_context = 0;
    m_xyz = new XYZ();
    m_tid = new QTime(QTime::currentTime());
    m_tid->start();
}

// Dette er protected i QWidget
void GameWidget::update()
{
    QWidget::update();

    //Viser tiden
    //m_parent->statusBar()->showMessage(m_tid->currentTime().toString());

    // Beregner fps på en enkel måte.
    // m_tid er en klokke som startes i konstruktøren og går
    // m_frame telles i paintGL()
    int millisekunder = m_tid->elapsed();
    if (millisekunder % 1000 < 10) {
        m_frame0 = m_frame - m_frame0;
        m_tid0 = millisekunder - m_tid0;
        float fps = 1000 * m_frame0/m_tid0;
        QStatusBar* sb = m_parent->statusBar();
        sb->showMessage(m_message + QString::number(fps));
    }
}
void GameWidget::repaint()
{
    //QWidget::repaint();
    qDebug() << "repaint";// << sender();
}

GameWidget::~GameWidget()
{
    delete m_shaderProgramObjekt;
    delete m_tetraeder;
    delete m_xyz;
    delete m_timer;
    delete m_context;
    delete m_tid;
}

/// property i QWidget klassen
QSize GameWidget::sizeHint() const
{
    //return QSize(640, 480);
    return QSize(1024, 768);
}

void GameWidget::initializeGL()
{
    initializeOpenGLFunctions();

    m_shaderProgramObjekt = new ShaderProgramObjekt();
    m_shaderProgramObjekt->initShader(m_parent->hentVertexShaderKode(), m_parent->hentFragmentShaderKode());
    m_shaderProgramObjekt->useProgram();

    glEnable(GL_TEXTURE_2D);
    glEnable(GL_SAMPLER_2D);

    m_texture = new Texture("d:/h2016/vsim/GLSL/hund2.bmp");
    m_positionAttribute = m_shaderProgramObjekt->getAttribLocation("aVertexPosition");
    m_colorAttribute = m_shaderProgramObjekt->getAttribLocation("aVertexColor");
    m_textureAttribute = m_shaderProgramObjekt->getAttribLocation("aTextureCoordinates");

    m_uniformMVMatrix = m_shaderProgramObjekt->getUniformLocation("uMVMatrix");
    m_uniformPMatrix = m_shaderProgramObjekt->getUniformLocation("uPMatrix");
    m_uniformSampler = m_shaderProgramObjekt->getUniformLocation("uSampler");

    qDebug() << "GameWidget init " << m_positionAttribute  << m_colorAttribute << m_textureAttribute;

    QString p; p.setNum(m_positionAttribute);
    QString c; c.setNum(m_colorAttribute);
    QString t; t.setNum(m_textureAttribute);
    QString s; s.setNum(m_uniformSampler);
    m_message = "aVertexPosition " + p
            + ", aVertexColor " + c
            + ", aTextureCoordinates " + t
            + ", uSampler " + s + ", ";


    m_tetraeder->initVertexBufferObjects();
    m_tetraeder->setTexture(m_texture->id());;


    m_xyz->initVertexBufferObjects();

    glEnableVertexAttribArray(m_positionAttribute);
    glEnableVertexAttribArray(m_colorAttribute);
    glEnableVertexAttribArray(m_textureAttribute);

    glClearColor(0.3f, 0.3f, 0.3f, 0.0f);

    glEnable(GL_DEPTH_TEST);

    qDebug() << "GameWidget::initializeGL() utført" ;
}


// Felles slot for alle pushbuttons i mainWindow
void GameWidget::klikket()
{
    //initializeOpenGLFunctions();
    QString navn = sender()->objectName();
    qDebug() << navn;
    if (navn == "start")
    {
        m_timer->start(17);
        sender()->setObjectName("stopp");
        QPushButton* qpb = dynamic_cast<QPushButton*>(sender());
        qpb->setText("stopp");
    }
    if (navn == "stopp")
    {
        m_timer->stop();
        sender()->setObjectName("start");
        QPushButton* qpb = dynamic_cast<QPushButton*>(sender());
        qpb->setText("start");
    }
    if (navn == "1")
    {
        m_uniformMVMatrix = m_shaderProgramObjekt->getUniformLocation("uMVMatrix");
        m_uniformPMatrix = m_shaderProgramObjekt->getUniformLocation("uPMatrix");
        qDebug() << "uniforms m_uniformMVMatrix " << m_uniformMVMatrix;
        qDebug() << "uniforms m_uniformPMatrix " << m_uniformPMatrix;
    }
}

/**
 * @brief GameWidget::redigert()
 *
 * slot som fanger opp endringer i shadersource fra parent (main window)
 * Det er nødvendig å bruke makeCurrent() og doneCurrent() her for å
 * sette GameWidget til current context. Utelates disse to kallene, oppfattes hele
 * vinduet som context og mainwindow delene blir overskrevet.
 *
 * Eksisterende shaderProgramObjekt blir slettet (også på GPU) og nytt
 * shaderProgramObjekt blir opprettet i initializeGL()
 */
void GameWidget::redigert()
{
    makeCurrent();  // 151001 DN nødvendig i Windows 10
    bool timerActive=false;
    qDebug() << "redigert";

    if (m_timer->isActive())
    {
        m_timer->stop();
        timerActive = true;
    }

    m_shaderProgramObjekt->deleteProgram();
    delete m_shaderProgramObjekt;

    //init();
    initializeGL();

    if (timerActive)
        m_timer->start(17);
    doneCurrent();
}

void GameWidget::paintGL()
{
    // MouseMove i MainWindow genererer events som får paintGL() til
    // å utføres. Hindrer dette ved å teste om timeren går.

    if (!m_timer->isActive())
    {
        //qDebug() << "paintGL() timer inaktiv";
        return;
    }
    m_shaderProgramObjekt->useProgram();

    glViewport(0, 0, width(), height());

    // Blanker skjermen og nullstiller matrisene for hver ny rendring
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

    m_PMatrix.setToIdentity();
    m_PMatrix.perspective(60, 4.0/3.0, 0.1, 100.0);
    m_shaderProgramObjekt->setUniformMatrix(m_uniformPMatrix, 1, GL_FALSE, m_PMatrix.constData());

    m_MVMatrix.setToIdentity();

    // Flytter kamera
    m_MVMatrix.translate(0, -1, -10);

    // m er ordnet radvis, constData() returnerer kolonnevis
    // Vi må likevel sette transpose parameteren til GL_FALSE
    m_shaderProgramObjekt->setUniformMatrix(m_uniformMVMatrix, 1, GL_FALSE, m_MVMatrix.constData());

    // Tegner ett objekt
    m_xyz->draw(m_positionAttribute, m_colorAttribute);

    // For tekstur
    glEnable(GL_TEXTURE_2D);
    glActiveTexture(GL_TEXTURE0);
    glUniform1i(m_uniformSampler, 0);

    // Roterer. Hva?
    m_MVMatrix.rotate(100.0f * m_frame / 60, 1, 1, 1);
    m_shaderProgramObjekt->setUniformMatrix(m_uniformMVMatrix, 1, GL_FALSE, m_MVMatrix.constData());

    // Dette objektet blir påvirket av rotasjonen
    m_tetraeder->draw(m_positionAttribute, m_colorAttribute, m_textureAttribute);

    ++m_frame; // brukes i update til å telle fps
    //qDebug() << "m_textureAttribute " << m_textureAttribute;
}

void GameWidget::resizeGL(int width, int height)
{
    if (height == 0) height = 1;

    glViewport(0, 0, width, height);
}


