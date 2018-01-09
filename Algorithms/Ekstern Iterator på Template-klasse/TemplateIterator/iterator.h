#ifndef ITERATOR_H
#define ITERATOR_H
/*************************Iterator*********************************/
template <typename TT>
class Iterator
{
public:
    Iterator (Node<TT>* inn)
    {
        v = inn;
    }

    Iterator& operator++()
    {
        //std::cout << "Iterator ++ called" << std::endl;
        v = v->neste;
        return *this;
    }

    TT operator*()
    {
        //std::cout << "Iterator * called" << std::endl;
        return v->hentVerdi();
    }

    bool operator!=(Iterator inn)
    {
        //std::cout << "Iterator != called" << std::endl;
        return ((v->neste) != (inn.v->neste));
    }

private:
    Node<TT>* v;

    template <typename>
    friend class LinkedList;
};

#endif // ITERATOR_H
