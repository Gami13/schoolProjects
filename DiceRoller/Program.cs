
static public class App
{
    //*******************************
    //nazwa: RollDice
    //opis: Losuje jedną kostką, zwraca liczbe z zakresu 1-6
    //parametry: brak
    //zwracany typ i opis: int - wylosowana liczba
    //autor: Marcin Czechowicz
    //*******************************

    static int RollDice()
    {
        Random rnd = new Random();
        int roll = rnd.Next(1, 7);
        return roll;
    }
    //*******************************
    //nazwa: GetDesiredRollCount
    //opis: Pyta użytkownika ile kości chce rzucić, powtarza pytanie do momentu uzyskania odpowiedzi z zakresu 3-10, zwraca podaną ilość
    //parametry: brak
    //zwracany typ i opis: int - wybrana ilość kości
    //autor: Marcin Czechowicz
    //*******************************
    static int GetDesiredRollCount()
    {
        int input = 0;
        while (input == 0)
        {
            Console.WriteLine("Ile kostek chcesz rzucić? (3-10)");
            int temp = 0;
            try
            {
                temp = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Proszę wprowadzić liczbe");
            }
            if (temp >= 3 && temp <= 10)
            {
                input = temp;
            }
            else
            {
                Console.WriteLine("Podaj liczbę z zakresu 3-10");
            }


        }
        return input;
    }
    //*******************************
    //nazwa: DoesWantToRepeat
    //opis: Pyta użytkownika czy chce zagrać ponownie, powtarza pytanie do momentu uzyskania odpowiedzi t lub n, zwraca true dla t, false dla n
    //parametry: brak
    //zwracany typ i opis: bool - czy użytkownik chce zagrać ponownie
    //autor: Marcin Czechowicz
    //*******************************
    static bool DoesWantToRepeat()
    {
        string answer = "";
        Console.WriteLine("Jeszcze raz? (t/n)");

        while (answer != "t" && answer != "n")
        {
            answer = Console.ReadLine();
            if (answer == "t")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Wpisz t lub n");

            }

        }
        return false;
    }
    //*******************************
    //nazwa: CalculatePoints
    //opis: Oblicza ilość uzyskanych punktów zgodnie z regułą, że jeżeli liczba występuje co najmniej 2 razy,
    //to jest ona dodawana do sumy, np jezeli "2" występuje 3 razy to dodawane do sumy jest 6
    //parametry: int[] points - tablica z wynikami rzutów
    //zwracany typ i opis: int - obliczony wynik według wprowadzonych losów
    //autor: Marcin Czechowicz
    //*******************************
    static int CalculatePoints(int[] points)
    {
        int sum = 0;

        for (int i = 1; i <= 6; i++)
        {
            int occurences = 0;
            foreach (int point in points)
            {
                if (point == i)
                {
                    occurences++;
                }
            }
            if (occurences >= 2)
            {
                sum += i * occurences;
            }

        }
        return sum;
    }
    static public void Main()
    {

        while (true)
        {

            int input = GetDesiredRollCount();
            List<int> points = [];


            for (int i = 0; i < input; i++)
            {
                int roll = RollDice();
                Console.WriteLine($"Kostka {i}: {roll}");
                points.Add(roll);

            }
            Console.WriteLine($"Liczba uzyskanych punktów: {CalculatePoints(points.ToArray())}");


            if (!DoesWantToRepeat())
            {
                break;
            }



        }



    }
}


