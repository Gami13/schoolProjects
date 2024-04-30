namespace _0426ExamMobile;

public partial class MainPage : ContentPage
{
	private double HeronFormula(double a, double b, double c)
	{
		double p = (a + b + c) / 2;
		if (!(p - a > 0) || !(p - b > 0) || !(p - c > 0))
		{
			return -1;
		}
		return Math.Sqrt(p * (p - a) * (p - b) * (p - c));

	}
	public MainPage()
	{
		InitializeComponent();
	}
	
	private void OnCalculate(object sender, EventArgs e)
	{
		try
		{
			Double a = Double.Parse(SideA.Text);
			Double b = Double.Parse(SideB.Text);
			Double c = Double.Parse(SideC.Text);
			Double result = HeronFormula(a, b, c);
			if (result == -1)
			{
				DisplayAlert("Error", "Taki trójkąt nie istnieje", "OK");
			}
			else
			{
				OutputField.Text = "Pole wynosi: " + result.ToString();
			}
		}
		catch (Exception)
		{
			DisplayAlert("Error", "Taki trójkąt nie istnieje", "OK");
		}

	}

}

