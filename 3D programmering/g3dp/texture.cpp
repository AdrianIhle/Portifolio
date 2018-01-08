
#include <QDebug>
#include <QImage>
#include <QBuffer>
#include <QByteArray>
//#include <windows.h>
#include "texture.h"


//Dette er gjort som en rask fiks for å bli uavhengig av windows.h
//og BITMAPINFOHEADER og BITMAPFILEHEADER som ligger i den.
typedef unsigned short int OWORD;    //Skal være 16 bit
typedef unsigned int ODWORD;         //Skal være 32 bit
typedef int OLONG;                   //Skal være 32 bit

struct OBITMAPINFOHEADER {
  ODWORD biSize;
  OLONG  biWidth;
  OLONG  biHeight;
  OWORD  biPlanes;
  OWORD  biBitCount;
  ODWORD biCompression;
  ODWORD biSizeImage;
  OLONG  biXPelsPerMeter;
  OLONG  biYPelsPerMeter;
  ODWORD biClrUsed;
  ODWORD biClrImportant;
};

struct OBITMAPFILEHEADER {
  OWORD  bfType;
  ODWORD bfSize;
  OWORD  bfReserved1;
  OWORD  bfReserved2;
  ODWORD bfOffBits;
};

Texture::Texture() : QOpenGLFunctions()
{
    for (int i=0; i<11; i++)
        pixels[i] = 0;
    pixels[0] = 255;
    pixels[4] = 255;
    pixels[8] = 255;
    pixels[9] = 255;
    pixels[10] = 255;

    glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
    //glEnable(GL_TEXTURE_2D);

    /// Må gjøres etter at GL er initialisert
    glGenTextures(1, &m_id);
    glBindTexture(GL_TEXTURE_2D, m_id);
    qDebug() << "Texture::Texture() id = " << m_id;
    glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, 2, 2, 0, GL_RGB, GL_UNSIGNED_BYTE,
                 reinterpret_cast<const GLvoid*>(pixels));
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
}

//!
//! \brief Texture::Texture() Read a bitmap file and create a texture with standard parameters
//! \param filnavn The name of the bmp file containing a texture
//! First one 2D texture is generated from
//! - glGenTextures()
//! Then the OpenGL functions
//! - glBindTexture()
//! - glTexParameteri()
//! - glTexImage2D()
//! are used. The texture can be retrieved later by using the function id()
Texture::Texture(const QString& filnavn): QOpenGLFunctions()
{
    initializeOpenGLFunctions();
    lesBitmap(filnavn.toStdString());
    settTekstur();
}

//!
//! \brief Texture::id() Return the id of a previously generated texture object
//! \return The id of a previously generated texture object
//!
GLuint Texture::id() const
{
    //if (glIsTexture(m_id)) qDebug() << "Texture " << m_id << "is texture";
    return m_id;
}

void Texture::lesBitmap(const std::string &filnavn)
{

    OBITMAPFILEHEADER bmFileHeader;
    OBITMAPINFOHEADER bmInfoHeader;

    std::fstream fil(filnavn.c_str(), std::ios::in | std::ios::binary); // FILE* fp = fopen(bildefil.c_str(),"rb");
    if (fil.is_open()) //if (fp)
    {
        fil.read((char *) &bmFileHeader, 14); //fread(&bmFileHeader, 14, 1, fp);

        fil.read((char *) &bmInfoHeader, sizeof(OBITMAPINFOHEADER));	//fread(&bmInfoHeader, sizeof(BITMAPINFOHEADER), 1, fp);
        m_kolonner = bmInfoHeader.biWidth;
        m_rader = bmInfoHeader.biHeight;
        m_nByte = bmInfoHeader.biBitCount / 8;

        m_bitmap = new unsigned char[m_kolonner * m_rader * m_nByte];
        fil.read((char *) m_bitmap, m_kolonner * m_rader * m_nByte); //fread(bitmap,kolonner * rader * nByte,1,fp);
        fil.close(); //fclose(fp);
    }
    unsigned char tmp;
    // må bytte rød og blå
    for (int k = 0; k < m_kolonner * m_rader * m_nByte; k += m_nByte) {
        tmp = m_bitmap[k];
        m_bitmap[k] = m_bitmap[k + 2];
        m_bitmap[k + 2] = tmp;
    }
}

void Texture::settTekstur()
{
    glGenTextures(1, &m_id);
    glBindTexture(GL_TEXTURE_2D, m_id);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
    glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
    glTexImage2D(
                GL_TEXTURE_2D,
                0,
                GL_RGB,
                m_kolonner,
                m_rader,
                0,
                GL_RGB,
                GL_UNSIGNED_BYTE,
                m_bitmap);
}
