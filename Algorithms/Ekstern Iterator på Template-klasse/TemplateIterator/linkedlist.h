#ifndef LINKEDLIST_H
#define LINKEDLIST_H

#include "node.h"
#include "iterator.h"

template <typename A>
class LinkedList
{
    Node<A>* hode;
    Node<A>* hale;

public:
    LinkedList(A inn);
    //Iterator<A> *listeHode();
    Iterator<A> hentListeHode();
    Iterator<A> hentListeHale();
    void leggTilNode(A inn);
};

template <typename A>
LinkedList<A>::LinkedList(A inn)
{
    hode = new Node<A>(inn);
    hale = hode;
}

template <typename A>
void LinkedList<A>::leggTilNode(A inn)
{
    //enkeltlenket liste, så jeg bruker halenoden til den nye noden:
    //singel linked list so i use the tail node of the new node
    hale->verdi = inn;
    //Lager ny halenode:
    //creates new tail node
    hale->neste = new Node<A>(inn);
    //sets the list's tail pointer to new tail
    //Setter listens hale-peker til den nye halen:
    hale = hale->neste;
}

template <typename A>
Iterator<A> LinkedList<A>::hentListeHode()
{
    return Iterator<A>(hode);
}

template <typename A>
Iterator<A> LinkedList<A>::hentListeHale()
{
    return Iterator<A>(hale);
}


#endif // LINKEDLIST_H
