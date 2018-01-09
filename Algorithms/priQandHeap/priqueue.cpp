#include "priqueue.h"

PriQueue::PriQueue()
{

}

void PriQueue::insert(int priority, string data)
{
    HP.addToQueue(priority, data);
    Pos v = HP.last();
    while(!HP.isRoot(v))
    {
        Pos u = HP.parent(v);
        if(!HP.isLess(*v, *u))
            break;
        HP.swap(v, u);
        v = u;
    }
}

void PriQueue::removeTopPri()
{
    if(HP.size() == 1)
        HP.removeLast();
    else
    {
        Pos u = HP.root();
        HP.swap(u, HP.last());
        HP.removeLast();
        while(HP.hasLeft(u))
        {
            Pos v = HP.left(u);
            if(HP.hasRight(u) && HP.isLess(*(HP.right(u)),*v))
                v = HP.right(u);
            if(HP.isLess(*v,*u))
            {
                HP.swap(u,v);
                u = v;
            }
            else break;
        }
    }
}



void PriQueue::print()
{
 //Ole Print
    for(int it = 1; it < HP.heapVector.size(); it++)
    {
        cout << "Nr " << it << " Pri " << HP.heapVector[it]->priority << " " << HP.heapVector[it]->elem << endl;
    }

//min print
    //    for(Pos it = HP.heapVector.begin()+1; it != HP.heapVector.end(); it++)
    //    {

    //        Pos current = it;

    //        while (current != HP.root())
    //        {
    //            current = HP.parent(current);
    //        }
    //        int indents = (*it)->priority -1;                       //usikker hvorfor disse pekerene må være inni en parantes??
    //        for(int i = 0; i < indents; i++)                        //skriver ut indents lik priority -1
    //        {
    //            cout << "   ";
    //        }
    //        cout<< "priority: " << (*it)->priority << " name: " << (*it)->elem <<endl;
    //    }


////    Bård print
//        for(Pos active = ++HP.heapVector.begin(); active != HP.heapVector.end(); active++)
//        {
//            int j = 0;
//            Pos current = active;

//            while(!HP.isRoot(current))
//            {
//                j++;
//                current = HP.parent(current);

//            }

//            cout << endl;

//            for(int i = 0 ; i < j; i++)
//            {
//                cout << "   " << endl;
//            }

//            if (current != HP.root())
//            {
//                cout << "second to " << (*HP.parent(current))->priority;
//                        cout <<", " << (*HP.parent(current))->elem << ": ";

//            }

//            cout << "number " << (*current)->priority;
//            cout << ", " << (*current)->elem;
//        }

}

