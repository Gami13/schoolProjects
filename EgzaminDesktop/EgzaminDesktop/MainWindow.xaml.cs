using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EgzaminDesktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string number = "";
    private string name = "";
    private string lastName = "";
    private string eyeColor = "niebieskie";

    public MainWindow()
    {
        InitializeComponent();

    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (number.Length == 0 || name.Length == 0 || lastName.Length == 0)
        {
            MessageBox.Show("Wprowadź dane");

            return;
        }

        MessageBox.Show($"{name} {lastName} kolor oczu {eyeColor}");
    }

    private void BlueEyes(object sender, RoutedEventArgs e)
    {
        eyeColor = "niebieskie";
    }

    private void GreenEyes(object sender, RoutedEventArgs e)
    {
        eyeColor = "zielone";
    }

    private void BeerEyes(object sender, RoutedEventArgs e)
    {
        eyeColor = "piwne";
    }

    private void NumberInput(object sender, TextChangedEventArgs textChangedEventArgs)
    {
        number = ((TextBox)sender).Text;
        if (number == "111" || number == "222" || number == "333")
        {
            PersonImage.Source = new BitmapImage(new Uri($"pack://application:,,,/EgzaminDesktop;component/Resources/{number}-zdjecie.png"));
            FingerprintImage.Source = new BitmapImage(new Uri($"pack://application:,,,/EgzaminDesktop;component/Resources/{number}-odcisk.png"));

        }
    }

    private void NameInput(object sender, TextChangedEventArgs textChangedEventArgs)
    {
        name = ((TextBox)sender).Text;
    }

    private void LastNameInput(object sender, TextChangedEventArgs textChangedEventArgs)
    {
        lastName = ((TextBox)sender).Text;
    }
}