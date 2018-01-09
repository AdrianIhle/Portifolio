// ADS101 Algoritmer og Datastrukturer for spill H2016
// Eksempel på binærtre 7/10
#include <iostream>
#include "binarytree.h"
using namespace std;

int main()
{
    // Bygge et binært søketre manuelt - eksempel
    // Bruker 8 char a-z i dette eksemplet
    // alohqzbj
    // Setter inn disse i rekkefølge. Må tegne treet til hjelp
    BinaryTree* binaryTree = new BinaryTree('a');
    BinaryTree* hjelp = new BinaryTree('l');
    binaryTree->settHsub(hjelp);
    hjelp->settHsub(new BinaryTree('o'));
    hjelp->settVsub(new BinaryTree('h'));
    hjelp->getHsub()->settHsub(new BinaryTree('q'));
    hjelp->getHsub()->getHsub()->settHsub(new BinaryTree('z'));
    hjelp->getVsub()->settVsub(new BinaryTree('b'));
    hjelp->getVsub()->settHsub(new BinaryTree('j'));

    cout << "Vi trenger absolutt en insert-funksjon!!!" << endl;
    cout << "inorder traversering av binaert soketre (manuelt bygget)" << endl;
    binaryTree->intrav();
    cout << endl;
    return 0;
}
