using CommunityToolkit.Maui.Views;

namespace YetAnotherUselessHomeworkGallery
{
    public partial class MainPage : ContentPage
    {
        public static readonly List<String> images = new() {

        "https://preview.redd.it/v4i50fmy70671.jpg?width=640&crop=smart&auto=webp&s=32d2d77433ddae797ddaa52cd55793b2323210bb",
        "https://preview.redd.it/o0y6o38c9m471.jpg?width=640&crop=smart&auto=webp&s=0c0492ee41fb5305b3806cbc2f9d22f99c746ecf",
        "https://preview.redd.it/dkug4k2dst371.jpg?width=640&crop=smart&auto=webp&s=09f179ca43916e79cff2aa6a4fc7e209ba928c17",
        "https://preview.redd.it/zjy28wui58671.jpg?width=640&crop=smart&auto=webp&s=3535f16134c3eaa0397a0d4a84deb16c2b790ed1",
        "https://preview.redd.it/um9uw0oc9g271.jpg?width=640&crop=smart&auto=webp&s=54c7e70f6142f537ca00646a957f92270b46d93d",
        "https://preview.redd.it/g4l0dqqmte571.jpg?width=640&crop=smart&auto=webp&s=65ff49da7607a3aab2fb23a916b946cec799984a",
        "https://preview.redd.it/fuehajv4y6271.jpg?width=640&crop=smart&auto=webp&s=879ee5361bf8f5ca41c6823527450182881c41b5",
        "https://preview.redd.it/w40jbgst5u271.jpg?width=640&crop=smart&auto=webp&s=06a42db58cdd40215f8e241ec7d1aa67ef7483bc",
        "https://preview.redd.it/h6749rt71f471.jpg?width=640&crop=smart&auto=webp&s=3766aec95f56f75c84325931f2b1da7aedc81e75",
        "https://preview.redd.it/wxj7u6oi49271.jpg?width=640&crop=smart&auto=webp&s=2472c6fe8ee7d3550975cbaea78f860f84c3a023",
        "https://preview.redd.it/z420uo99e5d71.jpg?width=640&crop=smart&auto=webp&s=8a7f655f34585fc704fdf330396cb4cc147be01f",
        "https://preview.redd.it/liuxa9e3bx581.jpg?width=640&crop=smart&auto=webp&s=c1b2b65b5017f6939b425e3cbb82b6be263dbff7",
        "https://preview.redd.it/nmhp8yrlf8371.jpg?width=640&crop=smart&auto=webp&s=8aa4a7b5b2221732067f27e20697c7374e5ffe22",
        "https://preview.redd.it/1f523ppz00871.jpg?width=640&crop=smart&auto=webp&s=0353631acaf53793c0b8aa8353fba181eef03bd4",
        "https://preview.redd.it/lwj2uhkzmwi71.jpg?width=640&crop=smart&auto=webp&s=1677007e008b5c6bdd76c577de7db0890fe3cc70",
        "https://preview.redd.it/z9hw03c6z6271.jpg?width=640&crop=smart&auto=webp&s=b974ed284808b53102215e70ba4c1c676e9cde2a",
        "https://preview.redd.it/pqnpws33ne971.jpg?width=640&crop=smart&auto=webp&s=bec8c3fed537b407447755c250bab0dd9e57ab36",
        "https://preview.redd.it/oe69s349g6a71.jpg?width=640&crop=smart&auto=webp&s=51cbdccf775f380498c5730c3b3aed0d3dd1b81f",
        "https://preview.redd.it/q63jn381m0791.jpg?width=640&crop=smart&auto=webp&s=b6ac3cfd81069a5e4ff5abcc49c503d1291c3b11",
        "https://preview.redd.it/gisvlzhrnx381.jpg?width=640&crop=smart&auto=webp&s=af55300a2c246346da94eb1c885712806e7bf645",
        "https://preview.redd.it/3ebd6u9550b71.jpg?width=640&crop=smart&auto=webp&s=1b9037bd67672679df14b2f751f798a3d236124d",
        "https://preview.redd.it/la1xk43pwcb71.jpg?width=640&crop=smart&auto=webp&s=3167c4d1146076a59575d10c101d7a5d7cd66633"

        };

        public MainPage()
        {
            InitializeComponent();


        }

        private void clickedMe(object sender, EventArgs e)
        {
            DisplayAlert("Author", "Created by: Gami :3", "OK");
        }

        private void tappedImage(object sender, TappedEventArgs e)
        {
            var test = (Image)sender;


            var popup = new Popup
            {
                Content = new VerticalStackLayout
                {
                    Children =
                    {
                       
                        new Image
                            {
                            Source = test.BindingContext.ToString()
                           ,HeightRequest = 400,
                            WidthRequest=250,
                            }
                    }
                }
            };
            this.ShowPopup(popup);

        }
    }
}