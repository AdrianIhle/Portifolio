TEMPLATE = app
CONFIG += console c++11
CONFIG -= app_bundle
CONFIG -= qt

SOURCES += \
    ball.cpp \
    camera.cpp \
    gameobject.cpp \
    gamewidget.cpp \
    gulv.cpp \
    hjul.cpp \
    main.cpp \
    mainwindow.cpp \
    shaderprogram.cpp \
    terning.cpp \
    tetraeder.cpp \
    texture.cpp \
    vertex.cpp \
    xyz.cpp

HEADERS += \
    ball.h \
    camera.h \
    gameobject.h \
    gamewidget.h \
    gulv.h \
    hjul.h \
    mainWindow.h \
    qopenglfunctions.h \
    shaderprogram.h \
    terning.h \
    tetraeder.h \
    texture.h \
    vec3.h \
    vertex.h \
    xyz.h

RESOURCES += \
    shadere.qrc

DISTFILES += \
    fragmentshader.glsl \
    vertexshader.glsl \
    Hund2.bmp \
    .qmake.stash
