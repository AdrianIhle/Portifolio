// node.h
#ifndef NODE_H
#define NODE_H
struct Kant;
struct Node {
 char mNavn;
 Node* mNestenode;
 Kant* mForstekant;
 bool mBesoekt;
 Node();
 Node(char navn, Node* neste);
 ~Node() { }
 void settinnkant(double vekt, Node* til);
 void skrivrek() const;
 void skriv() const;
 double f();
};
#endif // NODE_H
