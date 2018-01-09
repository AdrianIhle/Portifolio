#include "Point2.h"
#include <iostream>

using namespace std;

Point2::Point2()
{

}

void Point2::setX(int xIn)
{
    x = xIn;

    if (x < 0)
    { x = 0;}
    if (x > 9)
    {x = 9;}
}

void Point2::setY(int yIn)
{
    y = yIn;

    if (y < 0)
    {y = 0;}
    if (y > 9)
    {y = 9;}
}

int Point2::getX()
{
    return x;
}

int Point2::getY()
{
    return y;
}

