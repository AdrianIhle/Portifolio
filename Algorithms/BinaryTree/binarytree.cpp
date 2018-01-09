#include "binarytree.h"
#include <iostream>

using namespace std;
int BinaryTree::s_antall = 0;
BinaryTree::BinaryTree(char tegn, BinaryTree *vsub, BinaryTree *hsub)
    : m_tegn(tegn), m_vsub(vsub), m_hsub(hsub), m_parent(0)
{
    s_antall++;
}

int BinaryTree::size()
{
    return s_antall;
}

char BinaryTree::hentData() const
{
    return m_tegn;
}
BinaryTree::~BinaryTree()
{
    s_antall--;
}
void BinaryTree::settHsub(BinaryTree* hsub)
{
    m_hsub = hsub;
}
void BinaryTree::settVsub(BinaryTree* vsub)
{
    m_vsub = vsub;
}

void BinaryTree::pretrav() const
{
    std::cout << m_tegn; // eller cout << hentData();
    if (m_vsub)
        m_vsub->pretrav();
    if (m_hsub)
        m_hsub->pretrav();
}

void BinaryTree::intrav() const
{
    if (m_vsub)
        m_vsub->intrav();
    std::cout << m_tegn; // eller cout << hentData();
    if (m_hsub)
        m_hsub->intrav();
}

