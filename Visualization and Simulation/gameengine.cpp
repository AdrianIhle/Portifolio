#include "gameengine.h"
#include "constants.h"
#include <QMouseEvent>
#include <QKeyEvent>
#include <QWheelEvent>
#include <QtWidgets>
#include <QColorDialog>
#include "sosiplane.h"
#include "vec3.h"
#include "smoothedlines.h"

#include <cmath>


GameEngine::GameEngine(QWidget *parent) : QOpenGLWidget(parent)
{
    //mGameEnginePointer = this;
}

GameEngine::~GameEngine()
{
    mRunning = false;
    mTimer.stop();
    cleanup();
}

void GameEngine::init()
{
    mRunning = true;

//    initializeOpenGLFunctions();

    //Must set this to get MouseMoveEvents without pressing a mouse key
    //this->setMouseTracking(true);

    // Enable depth buffer - must be done in GameEngine
    glEnable(GL_DEPTH_TEST);

    // Enable back face culling - must be done in GameEngine
    glEnable(GL_CULL_FACE);

    //Set up standard materials
    initMaterials();

    //Make and place camera
    mCamera = new Camera();
    mCamera->mTransform->setPosition(-3.0f, -2.0f, -20.0f);
    mCamera->setBackgroundColor(0.4f, 0.4f, 0.4f, 1.0f);

    tempGeometry = new BezierCurve(Vec3(1,-5,0), Vec3(2,-3,3), Vec3(4,5,-6), Vec3(6,-9,9));
    tempGeometry->setMaterial(mMaterials[0]);
    tempGeometry->mTransform->setPosition(0,0,0);
    mGeometry.push_back(tempGeometry);

    //player
    mPlayer = new InteractiveBall (2.0f,5.0f,2.0f,3, QString("player"));  //generates moveable ball
    mPlayer->setMaterial(mMaterials[0]);
    mGeometry.push_back(mPlayer);
    mColliders.push_back(mPlayer);

    //Get the clear color from camera - the same as background color
    glClearColor(mCamera->mBackgroundColor.x(),
                 mCamera->mBackgroundColor.y(),
                 mCamera->mBackgroundColor.z(),
                 mCamera->mBackgroundColor.w());

    //Quick hack to make lots of cubes
    //The square root trick is because I want same number of rows and columns
    //    int noOfObjects{4};
    //    double squareRoot = sqrt(noOfObjects);
    //    GameObject *tempGeometry;
    //    for (unsigned long noOfCubesX = 0; noOfCubesX < squareRoot; noOfCubesX++)
    //    {
    //        for (unsigned long noOfCubesZ = 0; noOfCubesZ < squareRoot; noOfCubesZ++)
    //        {
    //            tempGeometry = new Cube((-3.0f+noOfCubesX*3.0f), 0.0f, (0.0f+noOfCubesZ*3.0f), QString("Cube "+ QString::number(mGeometry.size()+1)));
    //            tempGeometry->setMaterial(mMaterials[0]);
    //            //            mGeometry.push_back(tempGeometry);
    //        }
    //    }

    //one textured cube:
    tempGeometry = new Cube(4.0f, 3.0f, -4.0f, QString("Cube 10"));
    tempGeometry->setMaterial(mMaterials[1]);
    tempGeometry->mTransform->setScale(2.0f, 2.0f, 2.0f);
    mGeometry.push_back(tempGeometry);
    mColliders.push_back(tempGeometry);

    //        tempGeometry = new SOSIplane("D\:testSOShoyde.txt",0.0f, 0.0f, 0.0f, "SOSIplane");
    //        tempGeometry->setMaterial(mMaterials[0]);
    //        mGeometry.push_back(tempGeometry);


    //    Sosi map test
//    tempGeometry = new SOSIplane("D\:testSOShoyde.txt", 0.00008f, 0.03f);
//    tempGeometry->setMaterial(mMaterials[0]);
//    tempGeometry->mTransform->setPosition(0.0f, 0.0f, 0.0f);
//    mGeometry.push_back(tempGeometry);


    mPlane = new Plane(1.0f, 1.0f, 0.0f, QString("Plane"));
    mPlane->setMaterial(mMaterials[0]);
    mGeometry.push_back(mPlane);

//    mTrianglePlane = new TrianglePlane(1.0f, 1.0f, 0.0f, QString("TriPlane"));
//    mTrianglePlane->setMaterial(mMaterials[0]);
//    mGeometry.push_back(mTrianglePlane);

    //circle-test:
    CircleSphere *tempCircle = new CircleSphere(4, -2.0f, 3.0f, -3.0f); //inferior stopped, signal from operating system, segmentation fault, error contiunes in new_allocator.h line 104 (return static cast)
    tempCircle->setMaterial(mMaterials[0]);
    mGeometry.push_back(tempCircle);

    // Axes - cross gizmo:
    axes = new AxesGizmo();
    axes->setMaterial(mMaterials[0]);


    skybox = new SkyBox();
    skybox->setMaterial(mMaterials[1]);
    skybox->mTransform->setScale(150.0f, 150.0f, 150.0f);
    mGeometry.push_back(skybox);


//    mSmoothLine = new SmoothedLines(Vec3(1,-5,0), Vec3(2,-3,3), Vec3(4,5,-6), Vec3(6,-9,9));
//    mSmoothLine->createNewCurve(Vec3(7,-10,3), Vec3(9,7,3), Vec3(11,-9,-6), Vec3(14,-9,9));
//    mSmoothLine->mTransform->setPosition(0,0,0);
//    mSmoothLine->initGeometry();
//    mSmoothLine->setMaterial(mMaterials[0]);
//    mGeometry.push_back(mSmoothLine);
//    qDebug() << "smooth line "<< mSmoothLine->bezList.size() <<endl;

    // Starts the Game Loop
    // Use QBasicTimer because its faster than QTimer
    mTimer.start(16, this);

    //send signal to Hierarcy in GUI
    initHierarchy(mGeometry);


}

void GameEngine::setCameraColor()
{
    QColor color = QColor(static_cast<int>(mCamera->mBackgroundColor.x()*255),
                          static_cast<int>(mCamera->mBackgroundColor.y()*255),
                          static_cast<int>(mCamera->mBackgroundColor.z()*255),
                          static_cast<int>(mCamera->mBackgroundColor.w()*255));

    QString title = QString("Select Background color");
    color = QColorDialog::getColor(color, this, title);

    if (color.isValid())
    {
        mCamera->setBackgroundColor(color.redF(), color.greenF(), color.blueF(), color.alphaF());

        glClearColor(mCamera->mBackgroundColor.x(),
                     mCamera->mBackgroundColor.y(),
                     mCamera->mBackgroundColor.z(),
                     mCamera->mBackgroundColor.w());
    }
}

void GameEngine::initMaterials()
{
    // Makes 4 default materials
    // 0.UnlitColor  1.UnlitTexture 2.LitColors 3.LitTexture
    // Only UnlitColor and UnlitTexture is implemented for now

    for (int no = 0; no < 4; no++)
    {
        mMaterials[no] = new Material(no);
    }
}

void GameEngine::cleanup()
{
    //Delete what we made in init()
    //    qDebug() << "Cleanup!";
    //    qDebug() << "Deleting" << mGeometry.size() << "objects";

    for (unsigned long noOfObjects = 0; noOfObjects < mGeometry.size(); ++noOfObjects)
    {
        delete mGeometry.at(noOfObjects);
        delete mColliders.at(noOfObjects);

        //The mGeometry vector deletes itself when going out of scope
    }
    mGeometry.clear();
    mColliders.clear();
    //    qDebug() << "mGeometry is now " << mGeometry.size() << "objects";

    if (axes)
    {
        delete axes;
        axes = nullptr;
        //        qDebug() << "Axes deleted";
    }
    for (int no = 0; no < 4; no++)
    {
        delete mMaterials[no];
        mMaterials[no] = nullptr;
        //        qDebug() << "Material" << no << "deleted";
    }

    if(mCamera)
    {
        delete mCamera;
        mCamera = nullptr;
        //        qDebug() << "Camera deleted";
    }
}

//This function is called from the Qt framework
void GameEngine::initializeGL()
{
    initializeOpenGLFunctions();
    init();
}

void GameEngine::resizeGL(int w, int h)
{
    //This function is called from Qt
    //Maybe before the camera is made!

    //The following is sometimes needed for retina displays
    //    const qreal retinaScale = devicePixelRatio();
    //    qDebug() << "Retina " << retinaScale;

    mCamera->setAspectRatio(w, h);
}

void GameEngine::paintGL()
{
    //paintGL is the Qt function called from the internal Qt loop

    // Clear color and depth buffer
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glClearColor(mCamera->mBackgroundColor.x(),
                 mCamera->mBackgroundColor.y(),
                 mCamera->mBackgroundColor.z(),
                 mCamera->mBackgroundColor.w());

    // Calculate view transformation
    if (!mCamera)
        qDebug() << "Rendering without camera!";

    // cameras viewMatrix - same for all objects
    viewMatrix = mCamera->getMatrix();
    // cameras projectionMatrix - same for all objects
    projectionMatrix = mCamera->getPerspectiveMatrix();

    //set position of skybox to that of camera
    //Not 100% correct yet.
    Vec3 temp = mCamera->mTransform->getPosition();
    temp.z = -temp.z;
    temp.x = -temp.x;
    skybox->mTransform->setPosition(temp);



    //Draw all geometry in mGeometry vector:
    GameObject *tempGeometry;

    foreach (auto &tempGameObject, mGeometry) {
        tempGeometry = tempGameObject;
        tempGeometry->setViewMatrix(viewMatrix);
        tempGeometry->setprojectionMatrix(projectionMatrix);
        tempGeometry->drawGeometry();
    }

    //if Axis editor button is on:
    if (axisOn)
    {
        axes->setViewMatrix(viewMatrix);
        axes->setprojectionMatrix(projectionMatrix);
        axes->drawGeometry();
    }


}

void GameEngine::axisOnOff()
{
    // qDebug() << "Axis on/off";
    axisOn = !axisOn;
}

void GameEngine::orthographicOnOff()
{
    ortho = !ortho;
    if (ortho)
        mCamera->setAspectRatio(1280, 720, true);
    else
        mCamera->setAspectRatio(1280, 720);
}

void GameEngine::wireFrameOnOff()
{
    //qDebug() << "Wireframe on/off";
    wireFrame = !wireFrame;
    GameObject *tempGeometry;
    foreach (auto &tempGameObject, mGeometry) {
        tempGeometry = tempGameObject;
        tempGeometry->setRendermode(wireFrame);
    }
}

void GameEngine::timerEvent(QTimerEvent *e)
{

    for(unsigned int T = 0; T < mColliders.size(); T++)
    {
        mColliders[T]->move();
        mColliders[T]->addForce(Vec3(0.0f, -0.002f, 0.0f));

        mPlane->collide(mColliders[T]);
//                mTrianglePlane->collide(mColliders[T]);
    }
    mPlane->highlightPosition(mPlayer->mTransform->getPosition());
    //    mTrianglePlane->highlightPosition(mPlayer->mTransform->getPosition());
    //just to silence warnings:
    //should be fixed - now just using time for nothing
    if(false)
        qDebug() << e;

    handleKeys();

    // Request an update for the QOpenGL widget
    update();
}

void GameEngine::mouseMoveEvent(QMouseEvent *event)
{
    //using mouseXYlast as deltaXY so we don't need extra variables
    mouseXlast = event->pos().x() - mouseXlast;
    mouseYlast = event->pos().y() - mouseYlast;

    //if delta is to big the movement will be jerky
    //Happens if mouse is moved much between presses.
    if (mouseXlast > 40 || mouseYlast > 40 || mouseXlast < -40 || mouseYlast < -40)
    {
        mouseXlast = 0;
        mouseYlast = 0;
    }

    //qDebug() << "dX: "<< mouseXlast << ", dY: "<< mouseYlast;
    mCamera->mTransform->rotate(0.0f,cameraSpeed*mouseXlast,0.0f);
    mCamera->mTransform->rotate(cameraSpeed*mouseYlast,0.0f,0.0f);

    mouseXlast = event->pos().x();
    mouseYlast = event->pos().y();
}

void GameEngine::keyPressEvent(QKeyEvent *event)
{
    //move camera
    if(event->key() == Qt::Key_A)
    {
        mLeft = true;
    }
    if(event->key() == Qt::Key_D)
    {
        mRight  = true;
    }
    if(event->key() == Qt::Key_W)
    {
        mUp = true;
    }
    if(event->key() == Qt::Key_S)
    {
        mDown = true;
    }
//    if(event->key() == Qt::Key_Z)
//    {
//            dynamic_cast<BezierCurve*>(mGeometry[0])->setControlPoints(Vec3(0,0,0),Vec3(2,3,0),Vec3(4,5,0),Vec3(6,0,0));
//    }

    //    moves player based on input, moves in world space, not local
    switch (event->key()) {
    case Qt::Key_Up:
        //        m_camera->MoveCam(camMove, 0.017f);
        mPlayer->mTransform->translate(0.0f, 0.0f, -0.2f);

        break;
    case Qt::Key_Left:
        //        camMove.x -= 58;
        //        m_camera->MoveCam(camMove, 0.017f);
        mPlayer->mTransform->translate(-0.2f, 0.0f, 0.0f);
        break;
    case Qt::Key_Down:
        //        camMove.z += 58;
        //        m_camera->MoveCam(camMove, 0.017f);
        mPlayer->mTransform->translate(0.0f, 0.0f, 0.2f);
        break;
    case Qt::Key_Right:
        //        camMove.x += 58;

        //        m_camera->MoveCam(camMove, 0.017f);
        mPlayer->mTransform->translate(0.2f, 0.0f, 0.0f);
        break;
    case Qt::Key_1:
        //        dynamic_cast<player*>(m_player)->getV()->m_degrees += 5.0;
        break;
    default:
        break;
    }
}

void GameEngine::keyReleaseEvent(QKeyEvent *event)
{
    //move camera
    if(event->key() == Qt::Key_A)
    {
        mLeft = false;
    }
    if(event->key() == Qt::Key_D)
    {
        mRight  = false;
    }
    if(event->key() == Qt::Key_W)
    {
        mUp = false;
    }
    if(event->key() == Qt::Key_S)
    {
        mDown = false;
    }
}

void GameEngine::wheelEvent(QWheelEvent* event)
{
    //http://doc.qt.io/qt-4.8/qwheelevent.html
    int numDegrees = event->delta() / 8;
    float numSteps = numDegrees / 15;

    if (event->orientation() == Qt::Horizontal) {
        mCamera->mTransform->translate(numSteps, 0.0, 0.0);
    } else {
        mCamera->mTransform->translate(0.0, 0.0, numSteps);
    }
    event->accept();
}

void GameEngine::handleKeys()
{
    //move camera
    if(mLeft)
    {
        mCamera->mTransform->translate(0.2f, 0.0, 0.0);

    }
    if(mRight)
    {
        mCamera->mTransform->translate(-0.2f, 0.0, 0.0);
    }
    if(mUp)
    {
        mCamera->mTransform->translate(0.0, 0.0, 0.2f);
    }
    if(mDown)
    {
        mCamera->mTransform->translate(0.0, 0.0, -0.2f);
    }
}
