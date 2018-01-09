#ifndef KANT_H
#define KANT_H
#include "node.h"
struct Kant {
    double mVekt;
    Node* mTilnode;
    Node* mFranode;
    Kant* mNestekant;
    Kant() :
        mVekt(0.0), mFranode(nullptr), mTilnode(nullptr), mNestekant(nullptr)
    { }
    Kant(double vekt, Node* franode, Node* tilnode, Kant* nestekant) :
        mVekt(vekt), mFranode(franode), mTilnode(tilnode), mNestekant(nestekant)
    { }
    ~Kant() { }
    bool operator < (const Kant& k) const { return mVekt < k.mVekt; }
    bool operator > (const Kant& k) const { return mVekt > k.mVekt; }
    void skriv() const {
        if (mFranode) {
            std::cout << mFranode->mNavn;
            std::cout << mTilnode->mNavn;
            std::cout << "(" << mVekt << ") ";
        }
    }
};
#endif // KANT_H
