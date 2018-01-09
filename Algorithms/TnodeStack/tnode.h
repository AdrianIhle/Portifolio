#ifndef TNODE_H
#define TNODE_H

template <typename T>
class Node
{
public:
    Node(T data, Node* neste=0);

    Node* hentNeste() const;

    static int hentAntall();
    T hentData() const;
    ~Node();
private:
    T m_tegn;            // Data-del
    static int s_antall;
    Node* m_neste;      // Datastruktur-del
};

// Templates krever at implementeringen også ligger i h-fila

template <typename T>
int Node<T>::s_antall;

template <typename T>
Node<T>::Node(T data, Node* neste)
    : m_tegn(data), m_neste(neste)
{
    //m_tegn = tegn;
    s_antall ++;
}

template <typename T>
Node<T>* Node<T>::hentNeste() const
{
    return m_neste;
}

template <typename T>
Node<T>::hentAntall() { return s_antall; }

template <typename T>
Node<T>::~Node()
{
    s_antall--;
}
template <typename T>
T Node<T>::hentData() const { return m_tegn; }

#endif // TNODE_H
