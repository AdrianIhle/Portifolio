#include "npc.h"
#include "gameobject.h"
#include "player.h"
#include "board.h"
#include <iostream>
using namespace std;

NPC::NPC()
{
    sprite = 'N';
    position.setY(5);
    position.setX(5);
}

void NPC::draw()
{

}


bool NPC::move(Point2 positionIn)
{

    //    teachers code
    int xDistance = (position.getX()-positionIn.getX());    //calculates difference in X positions
    int yDistance = (position.getY()-positionIn.getY());    //calculates difference in Y positions


     if(xDistance < 0 && xDistance != 'N')
        position.setX(position.getX()+1);
    else if(xDistance > 0 && xDistance != 'N')
        position.setX(position.getX()-1);
    else if(yDistance < 0 && yDistance != 'N')
        position.setY(position.getY()+1);
    else if(yDistance > 0 && yDistance != 'N')
        position.setY(position.getY()-1);
    else if (xDistance == 0 && yDistance == 0)                   //PROBLEM CODE! should be checking whether the npc and player is on the same spot
        {
            cout << "GAME OVER" << endl;                        //if actuvated should print GAMEOVER
            stillPlaying = false;
            return false;
        }
}

char NPC::getSprite()
{
    return sprite;
}



//void NPC::move(Point2 positionIn)
//{
//    Player *mPlayer;
//    if(position.getX() != mPlayer->position.getX())
//    {
//        if(position.getY() != mPlayer->position.getY())
//        {
//            position.setX(mPlayer->position.getX()-1);
//            position.setX(mPlayer->position.getY()-1);
//        }
//    }

//}
