using Plugin.Maui.Pedometer;

namespace FitnessTracker;

public partial class MainPage : ContentPage
{
    readonly IPedometer pedometer = Pedometer.Default;
    int stepsGoal = 1000;




    public MainPage()
    {
        InitializeComponent();

        if (Pedometer.IsSupported)
        {

            pedometer.ReadingChanged += (sender, reading) =>
            {
                Console.WriteLine(reading.NumberOfSteps);
                Database.addStepHistory(reading.NumberOfSteps, DateTime.Now);
                updateCounter();

            };
            pedometer.Start();
        }
        updateCounter();
        //StepsViewBorder.Stroke = createStepProgressBrush();


    }
    public void updateCounter()
    {
        int daySteps = Database.getDaySteps(DateTime.Now);

        StepCounter.Text = daySteps.ToString();
        //A red to green gradient


        //StepsViewBorder.Stroke = createStepProgressBrush();
        if (daySteps < 3) daySteps = 3;
        double angle = 360 * daySteps / stepsGoal;
        double radians = Math.PI / 180 * angle;
        double x = 120 + (120 * Math.Sin(radians));
        double y = 120 - (120 * Math.Cos(radians));

        ProgressArc.Point = new Point(x, y);
        ProgressArc.IsLargeArc = angle >= 180.0;



    }



}