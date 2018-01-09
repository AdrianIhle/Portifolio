#include <iostream>
#include "board.h"
#include "player.h"
#include "npc.h"

using namespace std;



int main()
{
    Board mBoard;
    Player mPlayer;
    NPC nNPC;
    NPC mNPC;
            mNPC.position.setX(4);                                                                  //sets second npc position differently
    while(nNPC.stillPlaying == true)
    {
        mBoard.clearBoard();                                                                        //clears the active board
        mBoard.putCharacter(mPlayer.getSprite(), mPlayer.position.getX(), mPlayer.position.getY()); //inserts the player
        mBoard.putCharacter(nNPC.getSprite(),nNPC.position.getX(),nNPC.getPosition().getY());       //inserts an NPC
        mBoard.putCharacter(mNPC.getSprite(),mNPC.position.getX(),mNPC.getPosition().getY());
        mBoard.drawBoard();
        cout << "X = " << mPlayer.position.getX() << " Y = " << mPlayer.position.getY() << endl;    //prints out player location
        nNPC.move(mPlayer.position);                                                                //moves the NPC accordig to player location
        mNPC.move(mPlayer.position);
        mPlayer.move();                                                                             //take the input fo the player, processes it and moves the player

    }



    return 0;


}

