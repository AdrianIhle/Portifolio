#include <iostream>
#include "treenode.h"
#include "treelist.h"
#include "myiterator.h"

using namespace std;

TreeList* BranchingTree = new TreeList();
TreeNode* currentNode = new TreeNode();
bool programRunning = true;
void userChoices();


int main()
{


//    while(programRunning)                                                             //så lenge bruker vil det så kan den kjøre gjennom bruker valgene sine
//        brukerValg();


    //disse har en tendens til å krasje programmet, antagligvis grunnet en peker som peker ut in intet
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree),"Table");
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree),"Cup");
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree),"Coffee");
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree)->ChildList->getStart(),"Sugar");
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree)->ChildList->getStart(),"Spoon");
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree)->ChildList->getStart()->Next,"Spice");
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree)->ChildList->getStart()->Next->ChildList->getStart(),"Cinnimon");
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree)->ChildList->getStart()->Next->ChildList->getEnd(),"Nutmeg");
    BranchingTree->addNode(BranchingTree->getRoot(BranchingTree)->ChildList->getEnd(),"Cream");

    BranchingTree->printTree(BranchingTree->getRoot(BranchingTree));
      BranchingTree->printTree(BranchingTree->getRoot(BranchingTree));                  //skriver ut root

    while(programRunning)
    {
        userChoices();
    }
}

void userChoices()
{
    int UserOption;                                                                  //vil lagre brukers input for valg av videre handling
    string elementName;                                                                 //vil inneholde det en ny node vil inneholde
    string lookFor;                                                                    //vil inneholde søke parameter for søke funskjon
    string elementToDelete;                                                          //vil inneholde søkeparameter for data delen til node som skal sletts

    //instruksjoner til bruker
    cout << "hva vil du gjore? \npress 1 for innsetting av nytt element(kun til rot)" << endl;
    cout << "press 2 for a soke etter et element" << endl;
    cout << "press 3 for a skrive ut treet" << endl;
//    cout << "press 4 for a skirve ut listen forlengs" << endl;
//    cout << "press 5 for a skrive ut listen baklengs" << endl;
    cout << "press 6 for a avslutte\n" << endl;

    cin >> UserOption;                                                              //mottar input fra bruker
    cout << "\n";

    switch(UserOption)                                                               //leser av spiller input og enten utfører handlingen eller ber om videre data så utfører handlingen
    {
    case 1:

        cout << "you wanted to add something, what will you name it?\n" << endl;
        cin >> elementName;                                                             //mottar data delen til den nye noden
        BranchingTree->addNode(BranchingTree->getRoot(BranchingTree),elementName);                                                    //legger til ny node med det nye data
        cout<< "\n";
        break;
    case 2:
        cout << "you wanted to navigate to a new node, what is its name? \n"<<endl;
        cin >> lookFor;                                                                //mottar søke parameter
        cout<< "\n";
        currentNode = BranchingTree->search(lookFor, BranchingTree->getRoot(BranchingTree));                             //starter søking på første node tter hode og søker etter søkeparmeter gitt av bruker

        cout<< "\n";
        break;
    case 3:
        BranchingTree->printTree(BranchingTree->getRoot(BranchingTree));
        cout << " \n";
        break;
//    case 4:
//        liste->skrivUt();                                                               //skriver ut listen
//        cout<< "\n";
//        break;
//    case 4:
//            BranchingTree->printTree(BranchingTree->getRoot(BranchingTree));
    case 6:
        programRunning = false;                                                       //setter boolen til usann slik at prgrommet avsluttes
        break;
    default:
        cout << "dette er ikke et mulig valg"<< endl;
    }
}






