#include <iostream>
#include "Liste.h"
#include "Node.h"


using namespace std;

Liste <string>* liste = new Liste<string>();                                            //lager en ny klasse (i dette tilfelle en string)
bool programSkalKjore = true;                                                           //forblir sann (dermed kjører prgrammet) så lenge bruker vil.

void brukerValg()
{
    int valgtMulighet;                                                                  //vil lagre brukers input for valg av videre handling
    string elementNavn;                                                                 //vil inneholde det en ny node vil inneholde
    string letEtter;                                                                    //vil inneholde søke parameter for søke funskjon
    string elementForSletting;                                                          //vil inneholde søkeparameter for data delen til node som skal sletts

    //instruksjoner til bruker
    cout << "hva vil du gjore? \npress 1 for innsetting av nytt element" << endl;
    cout << "press 2 for a soke etter et element" << endl;
    cout << "press 3 for a slette et element" << endl;
    cout << "press 4 for a skirve ut listen forlengs" << endl;
    cout << "press 5 for a skrive ut listen baklengs" << endl;
    cout << "press 6 for a avslutte\n" << endl;

    cin >> valgtMulighet;                                                              //mottar input fra bruker
    cout << "\n";

    switch(valgtMulighet)                                                               //leser av spiller input og enten utfører handlingen eller ber om videre data så utfører handlingen
    {
    case 1:

        cout << "du vil legge til et nytt element, hva vil du kalle det?\n" << endl;
        cin >> elementNavn;                                                             //mottar data delen til den nye noden
        liste->leggTil(elementNavn);                                                    //legger til ny node med det nye data
        cout<< "\n";
        break;
    case 2:
        cout << "du vil lete etter et element, hva vil du lete etter?\n"<<endl;
        cin >> letEtter;                                                                //mottar søke parameter
        cout<< "\n";
        liste->recursiveSearch(liste->start(), letEtter);                               //starter søking på første node tter hode og søker etter søkeparmeter gitt av bruker
        cout<< "\n";
        break;
    case 3:
        cout<< "du har valgt a slette et element, hva vil du slette?\n" << endl;
        cin >> elementForSletting;                                                      //søkeparameter for sletting
        cout<< "\n";
        liste->slettNode(liste->start(),elementForSletting);                            //starter søk ved noden etter hode og søker etter og sletter noden søkt etter om den finnes
        //søk og slett
        break;
    case 4:
        liste->skrivUt();                                                               //skriver ut listen
        cout<< "\n";
        break;
    case 5:
        liste->skrivUtBaklengs();                                                       //skriver ut liste i bakvendt rekkefølge
        cout<< "\n";
        break;
    case 6:
        programSkalKjore = false;                                                       //setter boolen til usann slik at prgrommet avsluttes
        break;
    default:
        cout << "dette er ikke et mulig valg"<< endl;
    }
}


int main()
{

    liste->leggTil("a");                                                                //konstruerer 3 noder i listen for test grunner
    liste->leggTil("b");
    liste->leggTil("c");

    liste->skrivUt();                                                                   //skriver ut lsiten en gang

    while(programSkalKjore)                                                             //så lenge bruker vil det så kan den kjøre gjennom bruker valgene sine
        brukerValg();
}






