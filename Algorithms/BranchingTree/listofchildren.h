#ifndef LISTOFCHILDREN_H
#define LISTOFCHILDREN_H
#include "treenode.h"

using namespace std;

class TreeNode;

class ListOfChildren
{
public:
    ListOfChildren();
    ~ListOfChildren();
    bool empty();                                       //skal skjekke hvor vidt denne listen er tom
    TreeNode* getStart();                               //henter den første noden etter head sentinel
    TreeNode* getEnd();                                 //henter den siste noden før tail sentinel
    void addChildNode(TreeNode *parent, const string& data);              //legger til en node til denne listen
    void recursiveSearch (TreeNode* ptr, string Querry);// vil søke gjennom denne listen, burde funke siden dettte kommer til å bare være en dobbelt lenket liste
    TreeNode* tail;
    int numberOfChilds;
    friend class TreeNode;                              //sørger for full tilgang til TreeNode så alle noder her kan være av samme type som alle andre

private:
    TreeNode* head;                                     //initialiserer head og tail

};

#endif // LISTOFCHILDREN_H
