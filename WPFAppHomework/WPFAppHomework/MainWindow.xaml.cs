using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAppHomework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            DateTime dateOfBirth = DateOfBirthPicker.SelectedDate ?? DateTime.MinValue;

            TimeSpan timeSpan = DateTime.Now - dateOfBirth;
            int daysPassed = (int)timeSpan.TotalDays;

            ResultLabel.Content = $"Od twojego urodzenia mineło {daysPassed} dni";
            
        }
    }
}

