#include "quest.h"

Quest::Quest(string name, int reward, int xp)
    :Name(name), Reward(reward), XP(xp)
{

}

void Quest::print()
{
    cout << "Name: " << Name

         << endl;
}
