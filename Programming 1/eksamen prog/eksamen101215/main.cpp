//Eksamen programmering 10.12.15 kandidatnr 824
#include <stdio.h>
#include <iostream>
#include <time.h>
using namespace std;


const int M=6, N=6;
const char BLANK = ' ';
const char SKIP = 'S';
const char BOM = 'B';
const char TREFF = 'T';

char brett [M][N]; //todimensjonal array med M rader og N kolonner
int antallTreff;
int antallSkudd;

//int BokstavTilTall (char bokstav) //ta kun store bokstaver
//{return (int) (bokstav) -65; }

int i = 0;
int j = 0;
char bokstav;

void lagTomtBrett()
{
    char brett [i][j]
    {
        {BLANK,BLANK,BLANK,BLANK,BLANK,BLANK},
        {BLANK,BLANK,BLANK,BLANK,BLANK,BLANK},
        {BLANK,BLANK,BLANK,BLANK,BLANK,BLANK},
        {BLANK,BLANK,BLANK,BLANK,BLANK,BLANK},
        {BLANK,BLANK,BLANK,BLANK,BLANK,BLANK},
        {BLANK,BLANK,BLANK,BLANK,BLANK,BLANK}
    };
}

//int tilfeldigRad()
//{
//    int randomM = srand();
//};

//int tilfeldigKolonne()
//{
//    int randomN = rand(srand());
//};

void skrivBokstaver ()
{
    cout<< "|A|B|C|D|E|F" << endl;
}

bool SkipTilOvers = true;
int antallSkip;
int rad = 0;
int kolonne = 0;

void inntakKolonne()
{
    switch (bokstav)
    {
    case 'A':
            kolonne = 0;
        break;
    case 'B':
            kolonne = 1;
        break;
    case 'C':
            kolonne = 2;
        break;
    case 'D':
            kolonne = 3;
        break;
    case 'E':
            kolonne = 4;
        break;
    case 'F':
            kolonne = 5;
        break;

    default:
        cout << "velg en STOR bokstav mellom A og F" << endl;

    }
}

void lagBrett ()
{
    while(SkipTilOvers)
    {
        lagTomtBrett();
        for ( antallSkip= 11; antallSkip>0; antallSkip--)
        {
            brett[rad][kolonne] = SKIP;
        }
        if(antallSkip == 0)
        {
            SkipTilOvers = false;
            cout << "ingen skip igjen" << endl;
        }
    }
    for (i = 0; i <6; i++)
    {
        for (j = 0; j< 6; j++)
        {
            cout << brett << endl;
        }
    }
}

void lagEgetBrett()
{
    char brett [i][j]
    {
        {SKIP,SKIP,BLANK,BLANK,BLANK,BLANK},
        {BLANK,BLANK,BLANK,SKIP,BLANK,SKIP},
        {SKIP,BLANK,BLANK,SKIP,BLANK,SKIP},
        {BLANK,BLANK,SKIP,BLANK,BLANK,BLANK},
        {SKIP,BLANK,BLANK,BLANK,BLANK,SKIP},
        {BLANK,BLANK,SKIP,BLANK,BLANK,BLANK}
    };
        for (i = 0; i <6; i++)
        {
            for (j = 0; j< 6; j++)
            {
                cout << brett;
            }
        }
         cout << endl;
}

//void skrivSpillerBrett()
//{
//    for (i = 0)
//}

char p;

int main()
{
    cout << " please wait" << endl;
    lagTomtBrett();
    cout << "please press p then enter" << endl;
    cin >> p;
    cout << "please wait" << endl;
    lagEgetBrett();
    skrivBokstaver();

}

/*av ukjente grunner printer C++ ut ram verdiene i steden for char verdiene?

