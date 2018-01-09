#include <iostream>
#include "chrono.h"
#include "priqueue.h"
#include <ctime>
#include "thread"
using namespace std;


/*this function is called in randomTime and uses randomTime's variable timeJump to know how often it is tu run accordingly to random time
waiting the given amount of time it then prints out the name of the element it is to remove then removes it, and prints the tree again*/
void givenTimeFunction(int timeJump, Chrono timer, PriQueue *SecurePri);

/*this function is given a time in milliseconds between 0 and 3000 (spsudorandom time). according to how much time has is to pass the function calls
 givenTimeFunction at appropriate times giving it the numbers it need to run each second*/
void randomTime();

/*this function calls randomTime a set number of times to stress test */
void stressTest(int nrTest, PriQueue *SecurePri, Chrono timer);


void userChoices(PriQueue *SecurePri, bool programmRunning, Chrono timer);

int main()
{
    Chrono timer;
    PriQueue* SecurePri = new PriQueue;
    bool programRunning = true;

    cout << "Security Priority List" << "\n" << endl;
    SecurePri->insert(1, "president");
    SecurePri->insert(2, "vicePresident");
    SecurePri->insert(3, "StateSec");
    SecurePri->insert(4, "DefenceMinister");
    SecurePri->insert(4, "MajorGeneral");
    SecurePri->insert(5, "PresFamily");
    SecurePri->insert(5, "StaffLeaders");
    SecurePri->insert(6, "StaffUnderlings");
    SecurePri->insert(6, "PressCorp");
    SecurePri->insert(7, "CriticalInfo");
    SecurePri->insert(7, "LessCriticalInfo");
    SecurePri->insert(8, "FirstLadyWardrobe");
    SecurePri->insert(8, "Vases");
    SecurePri->insert(8, "Area51Manifest");
    SecurePri->insert(8, "BeefJerky");
    SecurePri->insert(8, "NewsPaper");


    SecurePri->print();

    cout << "Extracting the Top Priority Asset \n" << endl;
    SecurePri->removeTopPri();
    SecurePri->print();

    while(programRunning)
    {
        cout <<"\n";
        userChoices(SecurePri, programRunning, timer);
    }
 return 0;
}

void givenTimeFunction(int timeJump,Chrono timer, PriQueue* SecurePri)
{
    timer.wait(timeJump);
    cout<< (*SecurePri->HP.root())->elem <<" was removed from site "<< endl;
    SecurePri->removeTopPri();
    SecurePri->print();
}
void randomTime(Chrono timer, PriQueue* SecurePri)
{
    int timeSpace = rand()%3000;
    int timeJump;

    if(timeSpace < 1000)
    {
        timer.wait(timeSpace);
        cout << "waited " << timeSpace << endl;
        timeJump = 1000- timeSpace;
    }
    else if( timeSpace > 1000 && timeSpace < 2000)
    {
        givenTimeFunction(0,timer, SecurePri);
        timer.wait(timeSpace -1000);
        cout << "waited " << timeSpace - 1000<< endl;
        timeJump = 2000 - timeSpace;
    }
    else
    {
        givenTimeFunction(0, timer, SecurePri);
        givenTimeFunction(0,timer, SecurePri);
        timer.wait(timeSpace-2000);
        cout << "waited " << timeSpace -2000 << endl;

    }
    SecurePri->insert(rand()%8, "Object #3");
    SecurePri->print();
    givenTimeFunction(timeJump, timer, SecurePri);

}

void stressTest(int nrTest,PriQueue* SecurePri, Chrono timer)
{
    bool stressTesting = true;
    cout<< "stress test initiating..." << "\n" << endl;
    while(stressTesting)
    {

        for(int i = 0; i < nrTest; i++){
            if(!SecurePri->HP.heapVector.empty())
            {
                randomTime(timer, SecurePri);

            }
            else
                break;
        }
        stressTesting = false;
    }
}

void userChoices(PriQueue* SecurePri, bool programRunning, Chrono timer)
{
    int UserOption;                                                                  //Stores user choice
    string elementName;                                                              //stores name of for a node
    int priority;                                                                    //stores the priority for a node
    int numberInput;
    //instruksjoner til bruker
    cout << "What do you want to do?" << endl;
    cout << "Press 1  to add to the queue" << endl;
    cout << "press 2 to print the list" << endl;
    cout << "press 3 to remove top Priority" <<endl;
    cout << "press 4 to stress test the list function" << endl;
    cout << "press 5 to end \n" << endl;

    cin >> UserOption;                                                              //mottar input fra bruker
    cout << "\n";

    switch(UserOption)                                                               //leser av spiller input og enten utfører handlingen eller ber om videre data så utfører handlingen
    {
    case 1:

        cout << "you wanted to add something, what will you name it?\n" << endl;
        cin >> elementName;                                                             //recieves the name of the new node
        cout << "what priority shall it have? " << endl;
        cin >> priority;
        SecurePri->insert(priority, elementName);                                                    //adds new node with user given data
        cout<< "\n";
        break;
    case 2:
        SecurePri->print();
        cout<< "\n";
        break;
    case 3:
        SecurePri->removeTopPri();
        cout << " \n";
        break;
    case 4:
        cout<< "how many tests do you want?" << endl;
        cin >> numberInput;
        stressTest(numberInput, SecurePri, timer);
        cout<< "\n";
        break;
    case 5:
        programRunning = false;                                                       //setter boolen til usann slik at prgrommet avsluttes
        break;
    default:
        cout << "dette er ikke et mulig valg"<< endl;
    }
}
