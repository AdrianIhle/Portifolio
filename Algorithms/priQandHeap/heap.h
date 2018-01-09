#ifndef HEAP_H
#define HEAP_H
#include <vector>
#include "iostream"
#include <string>
#include "prioritynode.h"

using namespace std;


class heap
{
public:
    heap();
    void addToQueue(int priority, string data);                             // kalles opp for å legge til noe i køen
    std::vector<PriorityNode*> heapVector = {};                             //vektoren som inneholder køen, vektor brukes som en flexible array (en array som varier størrelse)
    typedef typename std::vector<PriorityNode* >::iterator Pos;             //gir tilgang til iterator klassen for vector for å gi enkel tilgang til start, og slutt samt posisjone i vektoren
    Pos ps(int i);                                                          //gir en iterator kalt ps som bruker for å få tilgang til et spesifikt punkt av vektor bassert på inputtet

    int size();                                                             //gir størrelsen på heapen
    int index (const Pos& p) const;                                         //gir indexed til en node (hvor langt unna start den ligger antall noder)
    Pos left(const Pos& p);                                                 //gir venstre node basert på enkel matte
    Pos right(const Pos& p);                                                //gir høyre node basert på enkel matte
    Pos parent(const Pos& p);                                               //gir forelder node basert på enkel matte
    bool hasLeft(const Pos& p);                                             //oppgir om det eksister noe til venstre for noden
    bool hasRight(const Pos& p);                                            //oppgir om det eksistere noe til høyre for noden
    bool isRoot(const Pos& p) const;                                           //forteller om noden som blir puttet inn er roten av treet
    Pos root();                                                             //returnerer rota
    Pos last();                                                            //returnerer siste noden i treet (nederst mest til høyre)
    void removeLast();                                                     //fjerner den siste noden i lista
    void swap(const Pos& p, const Pos& q);                                  //bytter plass på to noder
    bool isLess(PriorityNode* a, PriorityNode* b);// {return a->priority < b->priority;}   //returnern om prioriteten til a er mindre enn b


};

#endif // HEAP_H
