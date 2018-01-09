#include "point2.h"

Point2::Point2()
{

}

void Point2::setX(int xIn)
{
    if(x <= 9 && x >= 0)
        x = xIn;
}

void Point2::setY(int yIn)
{
    if(y <= 9 && y >= 0)
    y = yIn;
}

int Point2::getX()
{
    return x;
}

int Point2::getY()
{
    return y;
}
