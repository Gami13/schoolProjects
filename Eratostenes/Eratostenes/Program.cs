int n = 100;
int nRoot = 10;

bool[] numberArray = new bool[n];
Array.Fill(numberArray, true);

for (int i = 2; i <= nRoot; i++)
{
    if (numberArray[i])
    {
        for (int j = i * i; j < n; j += i)
        {
            numberArray[j] = false;
        }
    }
}
Console.WriteLine("LICZBY PIERWSZE:");
for (int i = 2; i < n; i++)
{
    if (numberArray[i])
    {
        Console.Write($"{i} ");
    }
}

Console.ReadLine();