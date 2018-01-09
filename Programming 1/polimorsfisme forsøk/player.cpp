#include "player.h"
#include <iostream>
#include "gameobject.h"

using namespace std;

Player::Player()
{
    sprite = 'P';
    position.setY(1);
    position.setX(1);
}

void Player::move()
{
    cout << "please move with WASD (press enter after each)" << endl;
    bool validInput = false;
    while(validInput == false)
    {

        char input;
        cin >> input;
        if(input == 'w')
        {position.setX(position.getX()-1); validInput = true;}
        else if(input == 'a')
        {position.setY(position.getY()-1); validInput = true;}
        else if(input == 'd')
        {position.setY(position.getY()+1); validInput = true;}
        else if(input == 's')
        {position.setX(position.getX()+1); validInput = true;}
        else
        {cout << "input is invalid" << endl; validInput = false;}

    }
}

//void Player::draw()
//{
//    position.getX();
//    position.getY();
//    cout << "P" ;
//}

char Player::getSprite()
{
    return sprite;
}
