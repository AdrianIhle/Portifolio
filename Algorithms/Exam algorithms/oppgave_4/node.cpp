// Node.cpp
#include <iostream>
#include <queue>
#include <list>
#include "kant.h"
#include "node.h"
#include <vector>
Node::Node()
 : mNavn(' '), mNestenode(nullptr), mForstekant(nullptr), mBesoekt(false)
{ }
Node::Node(char navn, Node* neste) :
 mNavn(navn), mNestenode(neste), mForstekant(nullptr), mBesoekt(false)
{ }
void Node::settinnkant(double vekt, Node* til) {

    Kant* tempKant;
    tempKant = new Kant(vekt,this,til,nullptr);
    if(mForstekant == nullptr)
        mForstekant = tempKant;
    else if( mForstekant->mNestekant == nullptr)
        mForstekant->mNestekant = tempKant;

}
void Node::skrivrek() const {
    this->skriv();
    if(mNestenode != nullptr)
        mNestenode->skrivrek();

}

void Node::skriv() const
{
    std::cout<<"---"<< mNavn <<"---";
}
double Node::f() {
 double sum = 0.0;

 /* dette ser ut som en enkel pathfinding funksjon som prøver å finne den minst
  * vektede veien fra en node til en annen. den legger kantene inn i en prioritets kø
  * (som da antagentligvis sorterer basert på vekt). den sier så at kant er lik
  * den kanten som er på toppen av køen, sletter så denne toppen. soer at p er den noden
  * kanten strekker seg til, sjekker om denne noden er besøkt, om den ikke er det blir den
  * satt til å være besøkt og kanten blir skrivd ut og dens vekt lagt til total summen.
  * så for hver førstekant tilhørende p kjører den så neste kant og legger in i køen, og
  * gjør det samme for så å legge returnere summen av all vekten for disse kantene.
*/
 std::priority_queue<Kant, std::vector<Kant>, std::greater<Kant> > apq;
 // Initialiserer
 Kant kant(0.0, nullptr, this, nullptr);
 apq.push(kant);
 do {
 kant = apq.top();
 apq.pop();
 Node* p = kant.mTilnode;
 if (!p->mBesoekt) {
 p->mBesoekt = true;
 kant.skriv();
 sum += kant.mVekt;
 for (auto* q=p->mForstekant; q; q=q->mNestekant)
 apq.push(*q);
 }
 } while (!apq.empty());
 return sum;
}
