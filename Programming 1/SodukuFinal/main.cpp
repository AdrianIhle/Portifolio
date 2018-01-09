#include <iostream>

using namespace std;

// used to as a refereance board for what the player starts with to decide whether they can change a number
int StartBoard [9][9] =
{
    {0,4,0,0,0,0,9,0,7},
    {8,0,2,7,0,6,1,4,0},
    {9,0,0,4,0,3,0,0,6},

    {0,0,0,1,2,8,0,9,0},
    {3,0,0,0,0,0,0,0,1},
    {0,6,0,9,3,5,0,0,0},

    {2,0,0,5,0,7,0,0,8},
    {0,5,1,8,0,2,3,0,9},
    {7,0,6,0,0,0,0,1,0}
};
//the board that players choices are stored in
int PlayBoard [9][9] =
{
    {0,4,0,0,0,0,9,0,7},
    {8,0,2,7,0,6,1,4,0},
    {9,0,0,4,0,3,0,0,6},

    {0,0,0,1,2,8,0,9,0},
    {3,0,0,0,0,0,0,0,1},
    {0,6,0,9,3,5,0,0,0},

    {2,0,0,5,0,7,0,0,8},
    {0,5,1,8,0,2,3,0,9},
    {7,0,6,0,0,0,0,1,0}

};
//used to check if the player have won by comparing it to the playboard
int SolutionBoard [9][9] =
{
    {6,4,5,2,8,1,9,3,7},
    {8,3,2,7,9,6,1,4,5},
    {9,1,7,4,5,3,2,8,6},

    {5,7,4,1,2,8,6,9,3},
    {3,2,9,6,7,4,8,5,1},
    {1,6,8,9,3,5,7,2,4},

    {2,9,3,5,1,7,4,6,8},
    {4,5,1,8,6,2,3,7,9},
    {7,8,6,3,4,9,5,1,2}
};
//used to print the the play board
void PrintPlayBoard ()
{
    for (int i=0; i<9; i++)
    {
        for(int j=0; j<9; j++)
        {cout << PlayBoard [i][j] << ' ';
        }
        cout <<endl;
    }
};

void PrintSolutionBoard()
{
    for (int i=0; i<9; i++)
    {
        for(int j=0; j<9; j++)
        {cout << SolutionBoard [i][j] << ' ';
        }
        cout <<endl;
    }
};




int x = 0;          //used for players interaction with the x coordinates
int y = 0;          //used for players interaction with the y coordinates
int z = 0;          //used for player interaction with values on the board
int Column = 0;     //used for player interaction in SearchCol function
int Row = 0;        //used for player interaction SearchRow function
int SubnetIn = 0;
int SubnetMap [3][3] =
{
    {1,2,3},
    {4,5,6},
    {7,8,9}
};
int difficulty = 0;
void PrintSubnet()
{
    {for (int i=0; i<3; i++)
        {
            for(int j=0; j<3; j++)
            {cout << SubnetMap [i][j] << ' ';
            }
            cout <<endl;
        }
    }
}

char InputOrSearch; //used for player decision in Input function (deciding play or search)
char RowOrColumnOrSubnet;   //used for player decision in Input function (deciding what to search)
char i = 'i';
char I = 'I';
char s = 's';
char S = 'S';
char r = 'r';
char R = 'R';
char c = 'c';
char C = 'c';
char n = 'n';
char N = 'N';
char k = 'k';
char K = 'K';
char q = 'q';
char Q = 'Q';
char ContinueOrSolution;
int SearchNumber = 0;
bool GetInput = true;       //as long as this bool is true, the input while loop will run
bool ChangeValue = true;    //as long as this bool is true, the Change value loop will run
bool StillPlaying = true;   //as long as this bool is true, the StillPlaying loop will run

//uses the parameters input by the player to search a given Row in the board
void SearchRow ()
{
    bool NumberFound = false;
    cout << "please enter row to search in \n";
    cin >> Row;
    cout << "please enter number to search for \n";
    cin >> SearchNumber;
    if((1 <=  Row && Row <= 9)&&(1 <= SearchNumber && SearchNumber <= 9))
    {
        for (int k= 0; k<9; k++)
        {
            if( PlayBoard[Row - 1][k] == SearchNumber)
            {
                NumberFound = true;

            }


        }
        GetInput =true;
        if(NumberFound == true)
        {
            cout << SearchNumber << " is found in this row" << endl;
        }
        else
        {
            cout << SearchNumber << " is not found in this row" << endl;
        }
    }

}
//uses the parameters input by the player to search a given Column in the board
void SearchCol ()
{
    bool NumberFound = false;
    cout << "please enter column to search in \n";
    cin >> Column;
    cout << "please enter number to search for \n";
    cin >> SearchNumber;
    if((1 <= Column && Column <= 9)&&(1 <= SearchNumber && SearchNumber <= 9))
    { for (int c=0; c<9; c++)
        {
            if( PlayBoard[c][Column - 1] == SearchNumber)
            {
                NumberFound = true;
            }

        }

        if(NumberFound)
        {
            cout << SearchNumber << " is found in this column" << endl;

        }
        else
        {
            cout << SearchNumber << " is not found in this column" << endl;

        }
        GetInput = true;
    }

}
//uses the parmeters input by the player to search a given subnet in the board
void SearchSubnet ()
{
    int Subnet1[3][3] =
    {
        {PlayBoard[0][0],
         PlayBoard[0][1],
         PlayBoard[0][2]},

        {PlayBoard[1][0],
         PlayBoard[1][1],
         PlayBoard[1][2]},

        {PlayBoard[2][0],
         PlayBoard[2][1],
         PlayBoard[2][2]}
    };
    int Subnet2[3][3] =
    {
        {PlayBoard[0][3],
         PlayBoard[0][4],
         PlayBoard[0][5]},

        {PlayBoard[1][3],
         PlayBoard[1][4],
         PlayBoard[1][5]},

        {PlayBoard[2][3],
         PlayBoard[2][4],
         PlayBoard[2][5]}
    };
    int Subnet3[3][3] =
    {
        {PlayBoard[0][6],
         PlayBoard[0][7],
         PlayBoard[0][8]},

        {PlayBoard[1][6],
         PlayBoard[1][7],
         PlayBoard[1][8]},

        {PlayBoard[2][6],
         PlayBoard[2][7],
         PlayBoard[2][8]}
    };
    int Subnet4[3][3] =
    {
        {PlayBoard[3][0],
         PlayBoard[3][1],
         PlayBoard[3][2]},

        {PlayBoard[4][0],
         PlayBoard[4][1],
         PlayBoard[4][2]},

        {PlayBoard[5][0],
         PlayBoard[5][1],
         PlayBoard[5][2]}
    };
    int Subnet5[3][3] =
    {
        {PlayBoard[3][3],
         PlayBoard[3][4],
         PlayBoard[3][5]},

        {PlayBoard[4][3],
         PlayBoard[4][4],
         PlayBoard[4][5]},

        {PlayBoard[5][3],
         PlayBoard[5][4],
         PlayBoard[5][5]}
    };
    int Subnet6[3][3] =
    {
        { PlayBoard[3][6],
          PlayBoard[3][7],
          PlayBoard[3][8]},

        {PlayBoard[4][6],
         PlayBoard[4][7],
         PlayBoard[4][8]},

        {PlayBoard[5][6],
         PlayBoard[5][7],
         PlayBoard[5][8]}
    };
    int Subnet7[3][3] =
    {
        { PlayBoard[6][0],
          PlayBoard[6][1],
          PlayBoard[6][2]},

        {PlayBoard[7][0],
         PlayBoard[7][1],
         PlayBoard[7][2]},

        {PlayBoard[8][0],
         PlayBoard[8][1],
         PlayBoard[8][2]}
    };
    int Subnet8[3][3] =
    {
        { PlayBoard[6][3],
          PlayBoard[6][4],
          PlayBoard[6][5]},

        {PlayBoard[7][3],
         PlayBoard[7][4],
         PlayBoard[7][5]},

        {PlayBoard[8][3],
         PlayBoard[8][4],
         PlayBoard[8][5]}
    };
    int Subnet9[3][3] =
    {
        {PlayBoard[6][6],
         PlayBoard[6][7],
         PlayBoard[6][8]},

        {PlayBoard[7][6],
         PlayBoard[7][7],
         PlayBoard[7][8]},

        PlayBoard[8][6],
        PlayBoard[8][7],
        PlayBoard[8][5]
    };


    cout << "which subnet do you wanna search? \n"   << endl;
    cin >> SubnetIn;
    cout << "which number do you want to search for? " << endl;
    cin >> SearchNumber;
    if(((1 <=  SubnetIn && SubnetIn <= 9)&&(1 <= SearchNumber && SearchNumber <= 9)))
    {
        bool NumberFound = false;
        switch (SubnetIn)
        {

        case 1:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet1 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }
            cout <<endl;

            break;
        case 2:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet2 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }
            cout <<endl;

            break;
        case 3:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet3 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }
            cout <<endl;

            break;
        case 4:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet4 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }
            cout <<endl;

            break;
        case 5:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet5 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }
            cout <<endl;

            break;
        case 6:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet6 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }
            cout <<endl;

            break;
        case 7:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet7 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }
            cout <<endl;


            break;
        case 8:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet8 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }

            cout <<endl;

            break;

        case 9:
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)

                    if( Subnet9 [i][j] == SearchNumber)
                    {
                        NumberFound = true;
                    }

            }
            cout <<endl;

            break;

        default:

            cout << "invalid input \n" << endl;

            break;


        }

        if(NumberFound)
        {
            cout << SearchNumber << " is found in this subnet" << endl;
        }
        else
        {
            cout << SearchNumber << " is not found in this subnet" << endl;
        }
        GetInput = true;
    }

}
void RefineSearch()
{
    switch (RowOrColumnOrSubnet)
    {
    case 'r':
    case 'R':
        SearchRow();
        break;
    case 'c':
    case 'C':
        SearchCol();
        break;
    case 'n':
    case 'N':
        SearchSubnet();
        break;
    default:
        cout << "invalid input" << endl;
        return;
    }
}
//asks and processes the input given by the player

void NumberInput()
{
    cout << "please enter the row of number you wish to change (between 1 and 9)" << endl;
    cin >> x;
    cout << "please enter the column of the number you wish to change (between 1 and 9)" << endl;
    cin >> y;
    cout << "please input the value you wish to change the number to (between 1 and 9)" << endl;
    cin >> z;

    if((1 <=  x && x <= 9)&&(1 <= y && y <= 9)&&(1 <= z && z <= 9) && (StartBoard [x-1][y-1] == 0))
    {

        GetInput = false;
        ChangeValue = true;

    }
    else
    {
        cout << " invalid input"  << endl;
    }
}

void SearchInput()
{
    cout << "do you want to search a row (r) or a column(c)or a subnet(n)?" << endl;
    cin >> RowOrColumnOrSubnet;
    RefineSearch();
}
void Input ()
{
    cout << "Do you want to input(i) a new number or do you want to search(s) for a number?"  << endl;

    cin >> InputOrSearch ;
    switch (InputOrSearch)
    {
    case 's':
    case 'S':
        SearchInput();
        break;
    case 'i':
    case 'I':
        NumberInput();
        break;


    default:
        cout<< " that is not a valid input" << endl;
        return;
    }
}
//checks if the player ahs solved the board
bool CheckWin ()
{
    for (int c=0; c<9; c++)
    {

        for (int k=0; k<9; k++)
        {

            if (PlayBoard[c][k] != SolutionBoard [c][k])
            {
                return false;

            }

        }

    }
    return true;
}

bool FullBoard()
{
    for (int c=0; c<9; c++)
    {

        for (int k=0; k<9; k++)
        {

            if (!PlayBoard[c][k])
            {
                return false;

            }

        }

    }
    return true;
}


void DifficultyEasy()
{
    StartBoard[2][0] = 5;
    StartBoard[3][0] = 5;
    StartBoard[3][8] = 3;
    StartBoard[6][1] = 9;
    StartBoard[6][4] = 1;
    StartBoard[8][8] = 2;
};

void DifficultyMedium()
{
    StartBoard[2][0] = 5;
    StartBoard[3][0] = 5;
    StartBoard[3][8] = 3;
};

void ChooseDifficulty()
{

    bool DifficultyChosen = false;
    while (DifficultyChosen  == false)

    {

        switch (difficulty)
        {
        case 1:
            DifficultyChosen = true;
            DifficultyEasy();
            break;
        case 2:
            DifficultyChosen = true;
            DifficultyMedium();
            break;
        case 3:
            DifficultyChosen = true;
            break;
        default:
            cout << "please enter 1, 2 or 3 according to wanted difficulty" << endl;
            break;


        }
    }
}

int main()
{
    cout << "Welcome to sudoku. You will be given a board with 81 placements. \n Your goal is to fill them all with numbers from 1 to 9 \n"
            "YOu can only have one of each unique number in each row, column and subnet (3 by 3 square starting in the top left corner)  \n" << endl;
    cout <<" please choose a difficulty" << endl;
    cout << " easy (1) \t medium(2) \t hard(3)" << endl;
    cin >> difficulty;
    ChooseDifficulty();

    //loops as long as victory conditions arent met
    while (StillPlaying)
    {
        cout << "\n" << endl;
        PrintPlayBoard();   //prints an updated board at the start of each turn
        GetInput= true;     //initiates the getInput loop


        //iniates the input function to recieve input from the player then terminates it if the input is valid
        while(GetInput)
        {
            Input();
        }
        //updates the information on the board
        while (ChangeValue)
        {
            PlayBoard [x -1][y - 1] = z;
            ChangeValue = false;
        }

        if(FullBoard())
            if(PlayBoard != SolutionBoard)
            {
                {
                    cout << "you have filled the board, but its not filled correctly, do you want to continue(k) or see the solution(q)?" << endl;
                    cin >>ContinueOrSolution;
                    switch(ContinueOrSolution)
                    {
                    case 'k':
                    case 'K':
                        StillPlaying = true;
                        break;
                    case 'q':
                    case 'Q':
                        StillPlaying = false;
                        PrintSolutionBoard();

                    }
                }

            }
        //if the bool CheckWin returns true (the player has won) the play loop is terminated and the play ends
        if (CheckWin())
        {
            StillPlaying = false;
            cout << "You Win" << endl;
        }

    }

}























