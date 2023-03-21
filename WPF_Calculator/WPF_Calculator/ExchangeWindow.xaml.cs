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
    /// Interaction logic for ExchangeWindow.xaml
    /// </summary>
    public partial class ExchangeWindow : Window
    {
        public ExchangeWindow()
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

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Convert_Click(object sender, RoutedEventArgs e) 
        {
            double tot;            
            double amount = double.Parse(AmountTB.Text);

            if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Euro" &&
                ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Dollar")
            {
                tot = Math.Round(amount * 1.07, 2);
                ExchangeTB.Text = amount.ToString() + "euro is " + tot.ToString() + " dollar";

            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Euro" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Pond")
            {
                tot = Math.Round(amount * 0.89, 2);
                ExchangeTB.Text = "1 euro is " + tot.ToString() + " pond";
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Dollar" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Pond")
            {
                tot = Math.Round(amount * 0.83, 2);
                ExchangeTB.Text = "1 Dollar is " + tot.ToString() + " pond";
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Dollar" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Euro")
            {
                tot = Math.Round(amount * 0.93, 2);
                ExchangeTB.Text = "1 Dollar is " + tot.ToString() + " euro";
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Pond" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Euro")
            {
                tot = Math.Round(amount * 1.13, 2);
                ExchangeTB.Text = "1 pond is " + tot.ToString() + " euro";
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Pond" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Dollar")
            {
                tot = Math.Round(amount * 1.21, 2);
                ExchangeTB.Text = "1 pond is " + tot.ToString() + " dollar";
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Euro" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Euro")
            {
                tot = amount * 1;
                ExchangeTB.Text = "1 euro is" + tot.ToString() + " euro";                
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Dollar" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Dollar")
            {
                tot = amount * 1;
                ExchangeTB.Text = "1 dollar is " + tot.ToString() + " dollar";
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Pond" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Pond")
            {
                tot = amount * 1;
                ExchangeTB.Text = "1 pond is" + tot.ToString() + " pond";
            }
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=calcresults;Uid=root;Pwd=Test@1234!;";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand cmd = new MySqlCommand("INSERT INTO calc (CalcResult) values(@nm)", connection);
                cmd.Parameters.AddWithValue("@nm", ExchangeTB.Text);
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
