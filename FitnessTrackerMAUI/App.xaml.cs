namespace FitnessTracker;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Database.createDatabase();

        MainPage = new AppShell();

    }
}