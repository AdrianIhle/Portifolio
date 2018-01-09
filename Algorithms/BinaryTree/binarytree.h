#ifndef BINARYTREE
#define BINARYTREE

class BinaryTree
{
public:
    BinaryTree(char tegn='0', BinaryTree* vsub=0, BinaryTree* hsub=0);
    ~BinaryTree();

    static int size() ;// het hentAntall() static funksjon deles av alle instanser
    bool empty() const;
            // root() - trenger vi den???
    char hentData() const;
    void settHsub(BinaryTree* hsub);
    void settVsub(BinaryTree* vsub);
    BinaryTree* getHsub() const { return m_hsub; }    // Boka bruker Position klassen her
    BinaryTree* getVsub() const { return m_vsub; }
    void pretrav() const;
    void intrav() const;

private:
    static int s_antall;

    // Data-del
    char m_tegn;

    // Datastruktur-del
    BinaryTree* m_parent;   // ikke implementert ennå
    BinaryTree* m_vsub;
    BinaryTree* m_hsub;
};

#endif // BINARYTREE
