TEMPLATE = app
CONFIG += console c++11
CONFIG -= app_bundle
CONFIG -= qt

SOURCES += main.cpp \
    board.cpp \
    gameobject.cpp \
    player.cpp \
    point2.cpp \
    npc.cpp

HEADERS += \
    board.h \
    gameobject.h \
    player.h \
    point2.h \
    npc.h

