#include <iostream>
#include "charnode.h"
#include "stack.h"
#include <stack>

int main()
{
    CharNode* liste = new CharNode('a');
    liste = new CharNode('b', liste);
    liste = new CharNode('c', liste);
    liste = new CharNode('d', liste);
    for (CharNode* p=liste; p!=0; p=p->hentNeste())
        std::cout << p->hentData();

    std::cout << std::endl << liste->hentAntall();
    std::cout << std::endl;

    // Slette den første i lista
    CharNode* ut = liste;
    liste = liste->hentNeste();
    delete ut;

    std::cout << std::endl << liste->hentAntall();

//     Nå tester vi egen stakk
    std::cout << "\nTester egen stakk. pusher og popper\n";
    stack stakk;

    for (char ch = 'a'; ch<'h'; ch++)
    {
        std::cout << " push " << ch << std::endl;
        stakk.push(ch);
    }
    while (!stakk.empty())
    {
        char tegn = stakk.top();
        stakk.pop();
        std::cout << "pop " << tegn << std::endl;
    }
    char ch;
    std::cin >> ch;
    return 0;

    int i;
    std::cin >> i;

//          std::stack <int> stakk;
//      for(int i = 0; i < 1; i++)
//      {
//          std::cout << "push " << i << std::endl;
//          stakk.push(i);
//      }
//      while(!stakk.empty()){
//          int j = stakk.top();
//          stakk.pop();
//          std::cout <<"pop " << j << std::endl;
//      }




}


