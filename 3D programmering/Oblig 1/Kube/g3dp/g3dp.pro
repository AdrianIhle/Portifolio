RESOURCES += \
    ../shadere.qrc

DISTFILES += \
    ../fragmentshader.glsl \
    ../vertexshader.glsl \
    ../Hund2.bmp

HEADERS += \
    ../gameobject.h \
    ../gamewidget.h \
    ../mainWindow.h \
    ../qopenglfunctions.h \
    ../shaderprogram.h \
    ../tetraeder.h \
    ../texture.h \
    ../vec3.h \
    ../vertex.h \
    ../xyz.h \
    ../terning.h

SOURCES += \
    ../gameobject.cpp \
    ../gamewidget.cpp \
    ../main.cpp \
    ../mainwindow.cpp \
    ../shaderprogram.cpp \
    ../tetraeder.cpp \
    ../texture.cpp \
    ../vertex.cpp \
    ../xyz.cpp \
    ../terning.cpp

QT += opengl
