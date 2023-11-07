namespace tablicaWartownik
{
    internal class Program
    {
        /*******************************************************
            nazwa funkcji: fillArray
            argumenty: array - tablica do wypełnienia
            typ zwracany: brak
            informacje: funkcja wypełnia wprowadzoną tablice losowymi liczbami w zakresie 1-100
            autor: Gami
        ******************************************************/

        static void fillArray(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                var random = new Random();
                array[i] = random.Next(0, 100);
            }
        }
        /*******************************************************
            nazwa funkcji: findInArray
            argumenty: array - przeszukiwana tablica
                       desire - szukana liczba
            typ zwracany: int
            informacje: funkcja zwraca pozycje szukanej liczby w tablicy, lub -1 jeśli nie znaleziono tej liczby
            autor: Gami
        ******************************************************/
        static int findInArray(int[] array, int desire)
        {
            array[array.Length - 1] = desire;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == desire)
                {
                    if(i == array.Length - 1)
                    {
                        return -1;
                    }
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            var array = new int[101];
            fillArray(array);
            Console.WriteLine("Wprowadź liczbę do znalezienia: ");
            int desire = Convert.ToInt32(Console.ReadLine());
            int index = findInArray(array, desire);

            Console.Write("Tablica: "+array[0]);
            for(int i = 1; i < array.Length-1; i++)
            {
                Console.Write(", "+array[i] );
            }
            if (index == -1)
            {
                Console.WriteLine("\nNie znaleziono");
            }
            else
            {
                Console.WriteLine("\nZnaleziono na pozycji: " + index);
            }
            Console.Read();
        }
    }
}