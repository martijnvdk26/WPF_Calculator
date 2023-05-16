using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for DegreesWindow.xaml
    /// </summary>
    public partial class DegreesWindow : Window
    {
        public DegreesWindow()
        {
            InitializeComponent();
        }

        private void Calc_Window(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Stats_Window(object sender, RoutedEventArgs e)
        {
            StatsWindow statsWindow = new StatsWindow();
            statsWindow.Show();
            this.Close();
        }
        
        private void Exchange_Window(object sender, RoutedEventArgs e)
        {
            ExchangeWindow exchangeWindow = new ExchangeWindow();
            exchangeWindow.Show();
            this.Close();
        }
        private void Calc_History(object sender, RoutedEventArgs e)
        {
            CalcHistory calcHistory = new CalcHistory();
            calcHistory.Show();
            this.Close();
        }

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Convert_Click_1(object sender, RoutedEventArgs e)
        {
            double degrees = double.Parse(DegreesTextBox.Text);
            double radians = Math.PI / 180 * degrees;
            ResultTextBox1.Text = Math.Round(radians, 2).ToString() + " radians";

            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=calcresults;Uid=root;Pwd=Test@1234!;";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("INSERT INTO calc (CalcResult) values(@nm)", connection);
                cmd.Parameters.AddWithValue("@nm", ResultTextBox1.Text);
                connection.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }



    }
}
