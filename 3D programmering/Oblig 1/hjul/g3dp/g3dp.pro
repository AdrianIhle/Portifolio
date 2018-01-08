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
    ../terning.h \
    ../gulv.h \
    ../hjul.h

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
    ../terning.cpp \
    ../gulv.cpp \
    ../hjul.cpp

QT += opengl
