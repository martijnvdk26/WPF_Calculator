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

        private void Degrees_Window(object sender, RoutedEventArgs e)
        {
            DegreesWindow degreesWindow = new DegreesWindow();
            degreesWindow.Show();
            this.Close();
        }

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // code voor het omrekenen van de lengtes
        private void Convert_Length (object sender, RoutedEventArgs e)
        {
            double tot1;
            double length = double.Parse(LengthTB.Text);

            if (((ComboBoxItem)StatsBox1.SelectedItem).Content.ToString() == "Inch" &&
               ((ComboBoxItem)StatsBox2.SelectedItem).Content.ToString() == "Centimeter")
            {
                tot1 = Math.Round(length * 2.54, 2);
                ResultTB.Text = length.ToString() + " Inch is " + tot1.ToString() + " centimeter";

            }

            if (((ComboBoxItem)StatsBox1.SelectedItem).Content.ToString() == "Voet" &&
               ((ComboBoxItem)StatsBox2.SelectedItem).Content.ToString() == "Meter")
            {
                tot1 = Math.Round(length * 0.3048, 2);
                ResultTB.Text = length.ToString() + " Voet is " + tot1.ToString() + " meter";

            }

            if (((ComboBoxItem)StatsBox1.SelectedItem).Content.ToString() == "Mile" &&
               ((ComboBoxItem)StatsBox2.SelectedItem).Content.ToString() == "Kilometer")
            {
                tot1 = Math.Round(length * 1.6093, 2);
                ResultTB.Text = length.ToString() + " Mile is " + tot1.ToString() + " kilometer";

            }

            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=calcresults;Uid=root;Pwd=Test@1234!;";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("INSERT INTO calc (CalcResult) values(@nm)", connection);
                cmd.Parameters.AddWithValue("@nm", ResultTB.Text);
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

        // code voor het omrekenen van de gewichten
        private void Convert_Weight(object sender, RoutedEventArgs e)
        {
            double tot2;
            double weight = double.Parse(WeightTB.Text);
            if (((ComboBoxItem)StatsBox3.SelectedItem).Content.ToString() == "Pound" &&
               ((ComboBoxItem)StatsBox4.SelectedItem).Content.ToString() == "Kilogram")
            {
                tot2 = Math.Round(weight * 0.453592, 2);
                WeightResultTB.Text = weight.ToString() + " Pound is " + tot2.ToString() + " kilogram";

            }
            if (((ComboBoxItem)StatsBox3.SelectedItem).Content.ToString() == "Stone" &&
               ((ComboBoxItem)StatsBox4.SelectedItem).Content.ToString() == "Kilogram")
            {
                tot2 = Math.Round(weight * 6.35029, 2);
                WeightResultTB.Text = weight.ToString() + " Stone is " + tot2.ToString() + " kilogram";
            }

            if (((ComboBoxItem)StatsBox3.SelectedItem).Content.ToString() == "Pound" &&
               ((ComboBoxItem)StatsBox4.SelectedItem).Content.ToString() == "Gram")
            {
                tot2 = Math.Round(weight * 453.592, 2);
                WeightResultTB.Text = weight.ToString() + " Pound is " + tot2.ToString() + " gram";
            }

            if (((ComboBoxItem)StatsBox3.SelectedItem).Content.ToString() == "Stone" &&
               ((ComboBoxItem)StatsBox4.SelectedItem).Content.ToString() == "Gram")
            {
                tot2 = Math.Round(weight * 6350.29, 2);
                WeightResultTB.Text = weight.ToString() + " Stone is " + tot2.ToString() + " gram";
            }

            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=calcresults;Uid=root;Pwd=Test@1234!;";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("INSERT INTO calc (CalcResult) values(@nm)", connection);
                cmd.Parameters.AddWithValue("@nm", WeightResultTB.Text);
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

        // code voor het omrekenen van volumes
        private void Convert_Volume(object sender, RoutedEventArgs e)
        {
            double tot3;
            double volume = double.Parse(VolumeTB.Text);
            if (((ComboBoxItem)StatsBox5.SelectedItem).Content.ToString() == "Gallon" &&
               ((ComboBoxItem)StatsBox6.SelectedItem).Content.ToString() == "Liter")
            {
                tot3 = Math.Round(volume * 3.78541, 2);
                VolumeTB2.Text = volume.ToString() + " Gallon is " + tot3.ToString() + " liter";
            }

            if (((ComboBoxItem)StatsBox5.SelectedItem).Content.ToString() == "Liter" &&
                ((ComboBoxItem)StatsBox6.SelectedItem).Content.ToString() == "Gallon")
            {
                tot3 = Math.Round(volume * 0.264172, 2);
                VolumeTB2.Text = volume.ToString() + " Liter is " + tot3.ToString() + " gallon";
            }

            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=calcresults;Uid=root;Pwd=Test@1234!;";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("INSERT INTO calc (CalcResult) values(@nm)", connection);
                cmd.Parameters.AddWithValue("@nm", VolumeTB2.Text);
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

        private void Calc_History(object sender, RoutedEventArgs e)
        {
            CalcHistory calcHistory = new CalcHistory();
            calcHistory.Show();
            this.Close();
        }





    }
}
