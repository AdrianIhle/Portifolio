#ifndef PRIORITYNODE_H
#define PRIORITYNODE_H
#include <string>
#include "iostream"

using namespace std;


class PriorityNode
{
public:
    PriorityNode(int Priority, string data); //lager en klasse som kan inneholde en prioritet og data og to variabler for å få tilgang til disse
    int priority;
    string elem;
};

#endif // PRIORITYNODE_H
