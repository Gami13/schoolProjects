using Plugin.Maui.Pedometer;

namespace FitnessTracker;

public partial class PreferencesPage : ContentPage
{
    readonly IPedometer pedometer = Pedometer.Default;
    int steps = 0;



    public PreferencesPage()
    {
        InitializeComponent();



    }



}