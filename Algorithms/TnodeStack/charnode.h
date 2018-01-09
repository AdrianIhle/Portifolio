#ifndef CHARNODE_H
#define CHARNODE_H

#include <string>

class CharNode
{
public:
    CharNode(char tegn='0', CharNode* neste=0);
    std::string toString() const;
    CharNode* hentNeste() const;
    void skrivBaklengs() const;
    static int hentAntall();
    char hentData() const;
    ~CharNode();
private:
    char m_tegn;            // Data-del
    static int s_antall;
    CharNode* m_neste;      // Datastruktur-del
};

#endif // CHARNODE_H
