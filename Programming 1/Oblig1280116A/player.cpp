#include "player.h"
#include <iostream>
#include "gameobject.h"

using namespace std;

Player::Player()
{
    position.setY(0);
    position.setX(1);
}

void Player::move()
{

    cin >> input;
    if(input == 'w')
        position.setY(position.getY()-1);
    if(input == 'a')
        position.setX(position.getX()-1);
    if(input == 's')
        position.setY(position.getY()+1);
    if(input == 'd')
        position.setX(position.getX()+1);
    else
        cout << "input is invalid" << endl;
}

void Player::draw()
{
    position.getX();
    position.getY();
    cout << "P" ;
}

char Player::getSprite()
{
    return sprite;
}
