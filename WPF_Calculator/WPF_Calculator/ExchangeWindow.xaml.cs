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
                tot = amount * 1.07;
                ExchangeTB.Text = tot.ToString();

            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Euro" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Pond")
            {
                tot = amount * 0.89;
                ExchangeTB.Text = tot.ToString();
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Dollar" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Pond")
            {
                tot = amount * 0.83;
                ExchangeTB.Text = tot.ToString();
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Dollar" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Euro")
            {
                tot = amount * 0.93;
                ExchangeTB.Text = tot.ToString();
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Pond" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Euro")
            {
                tot = amount * 1.13;
                ExchangeTB.Text = tot.ToString();
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Pond" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Dollar")
            {
                tot = amount * 1.21;
                ExchangeTB.Text = tot.ToString();
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Euro" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Euro")
            {
                tot = amount * 1;
                ExchangeTB.Text = tot.ToString();
                MessageBox.Show("Niet zo handig he, 2 dezelfde eenheden omrekenen. Idioot! Nah do!");
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Dollar" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Dollar")
            {
                tot = amount * 1;
                ExchangeTB.Text = tot.ToString();
                MessageBox.Show("Niet zo handig he, 2 dezelfde eenheden omrekenen. Idioot! Nah do!");
            }

            else if (((ComboBoxItem)Cbox1.SelectedItem).Content.ToString() == "Pond" &&
                    ((ComboBoxItem)Cbox2.SelectedItem).Content.ToString() == "Pond")
            {
                tot = amount * 1;
                ExchangeTB.Text = tot.ToString();
                MessageBox.Show("Niet zo handig he, 2 dezelfde eenheden omrekenen. Idioot! Nah do!");
            }
        }


    }
}
