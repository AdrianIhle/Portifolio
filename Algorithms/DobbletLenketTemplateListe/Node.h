#ifndef NODE_H
#define NODE_H
#include "iostream"
#include<string>
#include <sstream>
#include <iostream>

using namespace std;

template <typename T>
class Node
{
private:
    T elem;
    Node<T>* m_neste;
    Node<T>* m_forrige;
    T m_data;
    static int s_antall;
    template <typename>
    friend class Liste;
public:
    Node(T data = "0", Node*neste = 0);
    Node<T>* hentNeste() const;
    static int hentAntall();
    T hentData() ;
    bool operator == (Node<T> node);
    ~Node();

};

//Template implementering

template <typename T>                           //lager int variablen s_antall for neste funksjon
int Node<T>::s_antall;

template <typename T>                           //her konstrueres klassen node til å inneholde data (av type T) og en peker til neste node
Node<T>::Node(T data, Node* neste)
    :m_data(data), m_neste(neste)               //kaller om data og neste til m_data og m_neste for oppkalling andre steder
{
    s_antall++;                                 // hver gang en node lages økes også telleren for antall som eksisterer
}

template <typename T>
Node<T>* Node<T>::hentNeste() const             //returnerer den neste i liste fra noden man er på
{
    return m_neste;
}


template <typename T>
int Node<T>::hentAntall()                       //returnere antall noder som ekistserer i listen
{
    return s_antall;
}

template <typename T>                           //når en node destruereres reduseres antallet i s_antall også
Node<T>::~Node()
{
    s_antall--;
}

template <typename T>                           //henter hva enn som er puttet inn som data i noden
 T Node<T>::hentData()
{
    return elem;
}

 template <typename T>                          //skjekker om elm i en node er det samme som det som er i den nye noden inn
 bool Node<T>::operator ==(Node<T> node)
{
    return(elem ==node.elem);
}


#endif // NODE_H
