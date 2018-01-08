#ifndef TEXTURE_H
#define TEXTURE_H

#include <iostream>
#include <fstream>
#include <string>
#include <QOpenGLFunctions>

//! \brief Simple class for creating textures from a bitmap file.

//! //! \author Dag Nylund
//! \date 16/02/05
//!

class Texture : protected QOpenGLFunctions
{
private:
    GLubyte pixels[12];
    GLuint m_id;
    unsigned char *m_bitmap;
    int m_kolonner;
    int m_rader;
    int m_nByte;
    void lesBitmap(const std::string& filnavn);
    void settTekstur();
public:
    Texture();
    Texture(const QString& filnavn);
    GLuint id() const;
};

#endif // TEXTURE_H
