namespace imageApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            likes.Text = count.ToString() + " polubień";

        }

        /*******************************************************
         nazwa funkcji: increment
         argumenty: brak
         typ zwracany: brak
         informacje: funkcja zwieksza ilosc polubien o 1 i akutalizuje tekst
         autor: Gami
        ******************************************************/
        private void increment(object sender, EventArgs e)

        {
           count++;
           likes.Text = count.ToString() + " polubień";
        }
        /*******************************************************
        nazwa funkcji: decrement
        argumenty: brak
        typ zwracany: brak
        informacje: funkcja zmniejsza ilosc polubien o 1 i akutalizuje tekst
        autor: Gami
       ******************************************************/
        private void decrement(object sender, EventArgs e)
        {
           if(count>0)
            {
                count--;
            }

           likes.Text = count.ToString() + " polubień";

        }
    }
}