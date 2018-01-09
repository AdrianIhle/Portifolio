    #include <iostream>

using namespace std;

int linearSum(int A[], int n)
{
    if(n == 1)
        return A[0];
    else
        return linearSum(A, n-1) + A[n-1];
}

/*beregner rekusiv sum med en ut paramenter
når vi bruker refereanse lages det ingen lokal kopi av parameteren*/
void recursionSum2(int A[], int n, int& sum)
{
        if(n > 0){
            sum = sum + A[n-1];
            cout << "Delsum " << sum <<endl;
            recursionSum2(A,n-1,sum);
        }

}

int noenTall[] =
{
    1,2,3,4,5,6,7,8,9,10
};

int main()
{
    cout << "Calculated recursive sum = " << linearSum(noenTall, 10) << endl;
    int recursiveSum = 0;
    recursionSum2(noenTall,10,recursiveSum);
    cout << "Recursive sum calculated = " << recursiveSum << endl;
}

