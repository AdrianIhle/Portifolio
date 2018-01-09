#include <iostream>
#include "linkedlist.h"

using namespace std;

int main()
{
    cout << "Hello LinkedList!" << endl;

    LinkedList<int> *liste = new LinkedList<int>(4);

    liste->leggTilNode(7);
    liste->leggTilNode(9);
    liste->leggTilNode(23);
    liste->leggTilNode(55);
    liste->leggTilNode(74);
    liste->leggTilNode(234);

    for (Iterator<int> iter = liste->hentListeHode(); iter !=  liste->hentListeHale(); ++iter)
    {
        cout << *iter << endl;
    }

    return 0;
}
