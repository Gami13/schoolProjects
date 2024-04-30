
//**********************************************
//Klasa: Address
//opis: Klasa służy do przechowywania informacji na temat adresu kontaktowego
//pola: ID - unikalny identyfikator adresu
//      Count - statyczne pole zawierające ilość utworzonych notatek
//      FirstName - pole przechowujące imie kontaktu
//      LastName - pole przechowujace nazwisko kontaktu
//      PhoneNumber - pole przechowujace numer telefonu kontaktu
//      
//autor: 05220406236
//***********************************************

class Address
{
    private int ID;
    static private int Count = 0;
    protected string FirstName;
    protected string LastName;
    protected string PhoneNumber;

    public Address(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Count++;
        ID = Count;
    }

    public void Display()
    {
        Console.WriteLine(FirstName);
        Console.WriteLine(LastName);
        Console.WriteLine(PhoneNumber);
    }

    public void Diagnose()
    {
        Console.WriteLine($"{ID}; {FirstName}; {LastName}; {PhoneNumber}");
    }
}


public static class Exam
{
    public static void Main()
    {
        Address a = new Address("Mateusz", "Piklowski", "123-456-789");
        Address b = new Address("Janusz", "Okojski", "234-567-890");
        Address c = new Address("Piotr", "Futrowy", "321-656-432");
        Address d = new Address("Kazimierz", "Kozioł", "134-321-765");
        Address e = new Address("Ferdynard", "Kiepski", "954-568-423");
        a.Display();
        a.Diagnose();
        Console.WriteLine();
        b.Display();
        b.Diagnose();
        Console.WriteLine();
        c.Display();
        c.Diagnose();
        Console.WriteLine();
        d.Display();
        d.Diagnose();
        Console.WriteLine();
        e.Display();
        e.Diagnose();

    }
}