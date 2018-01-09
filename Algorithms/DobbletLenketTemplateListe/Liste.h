#ifndef LISTE_H
#define LISTE_H
#include "Node.h"

using namespace std;

template <typename T>
class Liste
{
public:
    Liste();
    ~Liste();
    bool tom();
    Node<T>* start();
    Node<T>* slutt();
    void leggTil(const T& data);
    void fjernStart();
    void fjernSlutt();
    void skrivUt();
    void skrivUtBaklengs();
    void recursiveSearch(Node<T>* ptr, T Querry);
    void slettNode(Node<T>* ptr, T querry);
private:
    Node<T>* hode;
    Node<T>* hale;
    bool nySlettet;

protected:
    void fjernNode(Node<T>* gitt);
};

//Template Implementering

template <typename T>
Liste<T>::Liste()
{
    hode = new Node<T>;                                             //hode er en ny tom node på starten av listen som en sentinel node for å brukes som listens grense
    hale = new Node<T>;                                             //samme som hode men på enden av listen i steden for starten,
    hode->m_neste = hale;                                           //når listen blir laget starter hale som den neste på lista i forhold til hode
    hale->m_forrige = hode;                                         //på samme måte er hode hale sin forrige,
}                                                                   // viktig og notere de bare har en peker hver for å forsikre at ingenting skal gå forbi de siden vi ikke kan forandre pekere som ikke ekisterer
template <typename T>                                               //dette tillater oss å i hvert tilfelle av liste definere typen den inneholder (samme for alle slike tilfeller av variabler og slikt senere)
Liste<T>::~Liste()
{
    while (!tom())                                                   //destruktoren vil nå kontinuerlig slette den første noden i listen til den er tom
        fjernStart();
    delete hode;                                                     //setter så start og slutt sentienel values, i effekt ekisterer nå ikke listen mer
    delete hale;
}

template <typename T>
bool Liste<T>::tom() {return (hode->m_neste == hale);}              //skjekker om listen er tom ved at den ser om hode og hale er direkte koblet sammen

template <typename T>
Node<T> *Liste<T>::start() {return hode->m_neste;}                  //returnerer starten av listen ved og gi noden rett etter hode.

template <typename T>                                               //returnerer sluttn av listen ved å gi noden rett før hale
Node<T> *Liste<T>::slutt() {return hale->m_forrige;}

template <typename T>
void Liste<T>::leggTil(const T &data)                               //kalles opp når man skal skape og plassere en ny node i listen
{
    Node<T>* ny = new Node<T>;                                      //lager den nye noden
    ny->elem = data;                                                //gir den nye noden et data element
    Node<T>* gitt = hode->m_neste;                                  //definerer gittNoden som den første noden i listen



    while (gitt->elem < ny->elem && gitt != hale)                   //så lenge elementet i gitt er mindre en det i ny og listen ikke har nådd slutten så vil den gå vidre i listen. dette organsierer listen alphabetisk eller numerisk
    {
        gitt = gitt->m_neste;
    }

    for(Node<T>* p = hode->m_neste; p != hale; p = p->m_neste){     //her leter programmet gjennom listen og sørger for at den nye noden ikke er lik en node som alt eksiterer, om de er det så slettes den nye noden så den ikke legges til
        if(*ny == *p)
        {
            cout << "\ndenne er alt i listen" << endl;
            delete ny;
            nySlettet = true;                                       //sørger for at noden ikke prøves å legges til etter at den er slettet
            break;
        }
        else
            nySlettet =false;
    }
    if(!nySlettet)                                                  //om noden ikke er slettet og har funnet sin plass i listen så
    {                                                               //vil dette plassere noden på sin plass ved å koble om 'gitt' sine pekere
        ny->m_neste = gitt;                                         //til segselv og sine egene til gitt og det elementet gitt sine lenker var koblet til
        ny->m_forrige = gitt->m_forrige;
        gitt->m_forrige->m_neste = ny;
        gitt->m_forrige = ny;
    }

}

template <typename T>
void Liste<T>::fjernNode(Node<T> *gitt)                             //først så omkobles lenkene til noden som slettes til naboene dens
{                                                                   //så slettes den
    Node<T>* tidligere = gitt->m_forrige;
    Node<T>* etter = gitt->m_neste;
    tidligere->m_neste = etter;
    etter->m_forrige = tidligere;
    delete gitt;
}

template <typename T>
void Liste<T>::fjernStart() {fjernNode(hode->m_neste);}             //fjerner første node på listen som ikke er hodet

template <typename T>
void Liste<T>::fjernSlutt() {fjernNode(hale->m_forrige);}           //fjerner siste noden på listen som ikke er hale, ikke brukt i selve programmet

template <typename T>
void Liste<T>::skrivUt()                                            //skriver ut listen fra start noden (ikke hode) fram til den møter hale
{
    Node<T>* active = hode->m_neste;
    while(active != hale)
    {
        cout << active->elem << endl;
        active = active->m_neste;
    }
}

template <typename T>                                               //skriver ut listen fra slutt noden (ikke hale) fram til den møte hode
void Liste<T>::skrivUtBaklengs()
{
    Node<T>* active = hale->m_forrige;
    while(active != hode)
    {
        cout << active->elem << endl;
        active = active->m_forrige;
    }

}

template <typename T>
void Liste<T>::recursiveSearch(Node<T>* ptr, T querry)              //peker på en node i listen og får inn søkeparameteret
{

    if(ptr->elem == "")                                             //om ptr kommer til et punkt hvor noden ikke inneholder noe (altså halen) så finnes ikke objektet i listen
    {
        cout << querry << " er ikke i listen \n" << endl;            //forteller bruker at det de søker etter ikke er i listen
    }
    else if(ptr->elem == querry)                                    // om søkeparameteret finnes i listen så får brukeren svar
    {
        cout << querry << " er i listen \n";
    }
    else                                                            //om ikke søket har funnet det den leter etter ller nådd slutten av listen så hopper den til neste node
    {
        recursiveSearch(ptr->m_neste, querry);
    }
}


template <typename T>
void Liste<T>::slettNode(Node<T> *ptr, T querry)                    // her søker den igjennom per forrige funksjon og sletter noden som inneholder det som søkes etter om det finnes.
{
    if(ptr->elem == "")
    {
        cout << querry << " er ikke i listen" << endl;
    }
    else if(ptr->elem == querry)
    {
        fjernNode(ptr);
        cout << querry << " er slettet" << endl;
    }
    else
    {
        slettNode(ptr->m_neste, querry);
    }
}

#endif // LISTE_H
