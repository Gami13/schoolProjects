namespace PagesDemo;

public partial class ShitStain : TabbedPage
{
    public static readonly List<string> images = new()
        {
            "https://stayhipp.com/wp-content/uploads/2020/10/brrrridgette.jpg",
            "https://i.pinimg.com/236x/9a/52/9d/9a529db54384d7f6868d59c945d36c5c--cat-ears-kawaii-anime.jpg",
            "https://static.wikia.nocookie.net/disney/images/5/5d/Catboy-2.png/revision/latest?cb=20190605061937",
            "https://w0.peakpx.com/wallpaper/273/920/HD-wallpaper-cute-catboy-anime-thumbnail.jpg",
            "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/b1e578a9-df87-46b3-a9d6-b9c8a9359da4/dfrnbg9-478275e7-feff-436a-bd7d-7d4f67a353f3.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcL2IxZTU3OGE5LWRmODctNDZiMy1hOWQ2LWI5YzhhOTM1OWRhNFwvZGZybmJnOS00NzgyNzVlNy1mZWZmLTQzNmEtYmQ3ZC03ZDRmNjdhMzUzZjMucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.l53Lxf5EjHLvHnze48RvLCLOWCT2M1kLfsDufU4R33Y",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQG5j7Eay4XYedSByqNIzgi5HQflz_hQWKY2v0c7sc5Xzj0g1c1WqXZaV-YBv5IgGF41Ac&usqp=CAU",
            "https://wallpapercave.com/wp/wp9329008.jpg",
            "https://avatars.cloudflare.steamstatic.com/c7996a057b9ad655499a2e99480e830db845792b_full.jpg"
        };
    public int imageIndexo = 0;
    public ShitStain()
    {
        InitializeComponent();
        imago.Source = images[0];
    }
    public int NWDCalcular(int a, int b)
    {
        while (a != b)
        {
            if (a > b)
            {
                a = a - b;
            }
            else
            {
                b = b - a;
            }
        }
        return a;
    }
    public void calculatoro(object sender, EventArgs e)
    {
        int numero = int.Parse(numeroUno.Text);
        int numerodos = int.Parse(numeroDos.Text);
        int resultando = NWDCalcular(numero, numerodos);
        wynikando.Text = "Wynik: " + resultando.ToString();

    }
    public void anterior(object sender, EventArgs e)
    {

        imageIndexo--;
        if (imageIndexo <0)
        {
            imageIndexo = images.Count - 1;
        }
        imago.Source = images[imageIndexo];
    }
    public void proximo(object sender, EventArgs e)
    {
        imageIndexo++;
        if(imageIndexo > images.Count-1)
        {
            imageIndexo = 0;
        }
        imago.Source = images[imageIndexo];

    }
}