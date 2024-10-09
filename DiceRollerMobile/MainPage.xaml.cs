namespace DiceRollerMobile
{
    public partial class MainPage : ContentPage
    {
        string[] images = { "question.png", "z1.png", "z2.png", "z3.png", "z4.png", "z5.png", "z6.png" };
        int[] points = new int[5];

        int totalResult = 0;
        Image[] diceFields = { };

        public MainPage()
        {
            InitializeComponent();
            diceFields = new Image[] { dice0, dice1, dice2, dice3, dice4 };
        }
        //*******************************
        //nazwa: RollDice
        //opis: Obsługuje przycisk do losowania, losuje kości, ustawia obrazki, sumuje punkty i je wyświetla
        //parametry: tylko wymagane przez MAUI
        //zwracany typ i opis: brak
        //autor: Marcin Czechowicz
        //*******************************
        void RollDice(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                points[i] = rollDice();

                diceFields[i].Source = images[points[i]];
            }
            int currentPoints = CalculatePoints(points);
            totalResult += currentPoints;
            RollResult.Text = "Wynik tego losowania: " + currentPoints;
            GameResult.Text = "Wynik gry: " + totalResult;

        }
        //*******************************
        //nazwa: ResetGame
        //opis: Resetuje gre do stanu początkowego
        //parametry: tylko wymagane przez MAUI
        //zwracany typ i opis: brak
        //autor: Marcin Czechowicz
        //*******************************
        void ResetGame(object sender, EventArgs e)
        {
            totalResult = 0;
            GameResult.Text = "Wynik gry: 0";
            RollResult.Text = "Wynik tego losowania: 0";
            for (int i = 0; i < 5; i++)
            {
                points[i] = 0;
                diceFields[i].Source = images[0];
            }

        }
        //*******************************
        //nazwa: rollDice
        //opis: Losuje jedną kostką, zwraca liczbe z zakresu 1-6
        //parametry: brak
        //zwracany typ i opis: int - wylosowana liczba
        //autor: Marcin Czechowicz
        //*******************************

        static int rollDice()
        {
            Random rnd = new Random();
            int roll = rnd.Next(1, 7);
            return roll;
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

    }

}
