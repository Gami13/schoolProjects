using System.Diagnostics;
int[] weights = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};
string pesel = "05220406236";

//**********************************************
//nazwa funkcji: handleInput
//opis funkcji: pobiera od użytkownika numer PESEL
//parametry: brak
//zwracany typ i opis: string - jest to numer PESEL
//autor: 05220406236
//***********************************************

string handleInput()
{
    string input = Console.ReadLine();
    if (input.Length != 11)
    {
        Console.WriteLine("Niepoprawna długość numeru PESEL");
        Console.WriteLine(
            "Wciśnij 1 aby wpisać ponownie, wciśnij 2 aby użyc wartości domyślnej, wciśnij 3 aby zakończyć");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.WriteLine("Proszę wprowadzić numer pesel: :3");
            input = Console.ReadLine();
        }
        else if (choice == "2")
        {
            Console.WriteLine("Używam wartości domyślnej");
            input = pesel;
        }
        else if (choice == "3")
        {
            return "0";
        }
    }

    return input;
}
//**********************************************
//nazwa funkcji: checkSex
//opis funkcji: Sprawdza płeć na podstawie numeru PESEL
//parametry: pesel - numer PESEL użytkownika
//zwracany typ i opis: string - jest to płeć użytkownika, K - kobieta, M - mężczyzna
//autor: 05220406236
//***********************************************
string checkSex(string pesel)
{
    if (pesel != null)
    {
    }
        return Int32.Parse(pesel[9].ToString()) % 2 == 0 ? "K" : "M";
}
//**********************************************
//nazwa funkcji: checkValidity
//opis funkcji: sprawdza poprawność numeru PESEL na podstawie algorytmu wagowego
//parametry: pesel - numer PESEL użytkownika
//zwracany typ i opis: boolean - true jeśli numer PESEL jest poprawny, false w przeciwnym wypadku
//autor: 05220406236
//***********************************************
bool checkValidity(string pesel)
{
    int S = 0;
    for (int i = 0; i < 10; i++)
    {
        S += Int32.Parse(pesel[i].ToString()) * weights[i];
    }
    int M = S % 10;
    int R = M==0 ? 0 : 10 - M;
    return R == Int32.Parse(pesel[10].ToString());
}

Console.WriteLine("Proszę wprowadzić numer pesel: :3");
string input = handleInput();
//sprawdzanie czy użytkownik wprowadził numer PESEL
if (input.Length != 11)
{
    Console.WriteLine("Niepoprawna długość numeru PESEL, zakończono program");
    return;
}
pesel = input;
string sex = checkSex(pesel);
bool valid = checkValidity(pesel);
Console.WriteLine("Podany numer PESEL: " + pesel);
Console.WriteLine(sex=="K" ? "Kobieta" : "Mężczyzna");
Console.WriteLine("Numer PESEL jest " + (valid ? "poprawny" : "niepoprawny"));