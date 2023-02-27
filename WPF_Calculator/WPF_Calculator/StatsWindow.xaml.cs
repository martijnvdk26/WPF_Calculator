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
using System.Windows.Shapes;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        public StatsWindow()
        {
            InitializeComponent();
        }

        //navigatie naar andere windows

        private void Calc_Window(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Exchange_Window(object sender, RoutedEventArgs e)
        {
            ExchangeWindow exchangeWindow = new ExchangeWindow();
            exchangeWindow.Show();
            this.Close();
        }

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // code voor het omrekenen van de lengtes
        private void Convert_Length (object sender, RoutedEventArgs e)
        {
            
        }

        // code voor het omrekenen van de gewichten
        private void Convert_Weight(object sender, RoutedEventArgs e)
        {

        }





    }
}
