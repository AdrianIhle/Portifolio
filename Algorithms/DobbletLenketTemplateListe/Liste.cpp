#include "Liste.h"
#include "Node.h"


Liste::Liste()
{
    hode = new Node;
    hale = new Node;
    hode->m_neste = hale;
    hale->m_forrige = hode;
}

Liste::~Liste()
{
    while (!tom()) fjernStart();
    delete hode;
    delete hale;
}
bool Liste::tom() {return (hode->m_neste == hale);}

Node* Liste::start() {return hode->m_neste;}

Node* Liste::slutt() {return hale->m_forrige;}

void Liste::leggTil(const T &data)
{
    Node* ny = new Node;
    ny->elem = data;
    Node* gitt = hode->m_neste;



    while (gitt->elem < ny->elem && gitt != hale)
    {
        gitt = gitt->m_neste;
    }

    for(Node* p = hode->m_neste; p != hale; p = p->m_neste){
        if(*ny == *p)
        {
            delete ny;
            nySlettet = true;
            break;
        }
        else
            nySlettet =false;
    }
    if(!nySlettet)
    {
        ny->m_neste = gitt;
        ny->m_forrige = gitt->m_forrige;
        gitt->m_forrige->m_neste = ny;
        gitt->m_forrige = ny;
    }

}


void Liste::fjernNode(Node<T> *gitt)
{
    Node* tidligere = gitt->m_forrige;
    Node* etter = gitt->m_neste;
    tidligere->m_neste = etter;
    etter->m_forrige = tidligere;
    delete gitt;
}

void Liste::fjernStart() {fjernNode(hode->m_neste);}

void Liste::fjernSlutt() {fjernNode(hale->m_forrige);}

void Liste::skrivUt()
{
    Node* active = hode->m_neste;
    while(active != hale)
    {
        cout << active->elem << endl;
        active = active->m_neste;
    }
}

void Liste::skrivUtBaklengs()
{
    Node* active = hale->m_forrige;
    while(active != hode)
    {
        cout << active->elem << endl;
        active = active->m_forrige;
    }

}

void Liste::recursiveSearch(Node* ptr, string querry)
{

    if(ptr->elem == "")
    {
        cout << querry << " er ikke i listen" << endl;
    }
    else if(ptr->elem == querry)
    {
        cout << querry << " er i listen \n";
    }
    else
    {
        recursiveSearch(ptr->m_neste, querry);
    }
}

void Liste::sammenlignNoder()
{
    for(Node* p; p != hale; p = p->m_neste)
    {


    }
}

void Liste::slettNode(Node<T> *ptr, T querry)
{
    if(ptr->elem == "")
    {
        cout << querry << " er ikke i listen" << endl;
    }
    else if(ptr->elem == querry)
    {
        fjernNode(ptr);
    }
    else
    {
        slettNode(ptr->m_neste, querry);
    }
}



