QT       += core gui widgets opengl

TARGET = ORF_2017
TEMPLATE = app

#If Qt 5.3 and 5.4 use this
equals(QT_MINOR_VERSION, 3): QMAKE_CXXFLAGS += -std=c++11
equals(QT_MINOR_VERSION, 4): QMAKE_CXXFLAGS += -std=c++11
#If Qt 5.5 use this:
greaterThan(QT_MINOR_VERSION, 4): CONFIG += c++11

SOURCES += main.cpp \
    camera.cpp \
    cube.cpp \
    gameobject.cpp\
    gameengine.cpp \
    axesgizmo.cpp \
    shaderprogram.cpp \
    editorwindow.cpp \
    material.cpp \
    circlesphere.cpp \
    transform.cpp \
    skybox.cpp \
    vertex.cpp \
    plane.cpp \
    interactiveball.cpp \
    ball.cpp \
    sosiplane.cpp \
    triangleplane.cpp \
    beziercurve.cpp \
    smoothedlines.cpp

HEADERS += \
    transform.h \
    camera.h \
    cube.h \
    gameobject.h \
    gameengine.h \
    axesgizmo.h \
    shaderprogram.h \
    editorwindow.h \
    material.h \
    circlesphere.h \
    constants.h \
    skybox.h \
    vec3.h \
    vertex.h \
    vec2.h \
    plane.h \
    interactiveball.h \
    ball.h \
    sosiplane.h \
    triangleplane.h \
    beziercurve.h \
    smoothedlines.h

FORMS += \
    EditorWindow.ui
