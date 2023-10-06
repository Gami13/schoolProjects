int NWD(int a, int b)
{
    while (a!=b)
    {
        if (a>b)
        {
            a = a - b;
        }
        else
        {
            b = b - a;
        }
    }
    return a;
};


    Console.WriteLine(NWD(125, 5));
    Console.WriteLine(NWD(333, 111));

    Console.WriteLine(NWD(2500, 25));
    Console.WriteLine(NWD(27, 3));
