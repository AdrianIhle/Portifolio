#ifndef NODE_H
#define NODE_H

template <typename T>
class Node
{
    T verdi;
    Node *neste;
public:
    Node(T inn){verdi = inn; neste = nullptr;}
    T hentVerdi(){return verdi;}

    template <typename>
    friend class LinkedList;
    template <typename>
    friend class Iterator;
};


#endif // NODE_H
