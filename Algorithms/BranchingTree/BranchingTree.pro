TEMPLATE = app
CONFIG += console c++11
CONFIG -= app_bundle
CONFIG -= qt

SOURCES += main.cpp \
    treelist.cpp \
    treenode.cpp \
    myiterator.cpp \
    listofchildren.cpp

HEADERS += \
    treelist.h \
    treenode.h \
    myiterator.h \
    listofchildren.h

