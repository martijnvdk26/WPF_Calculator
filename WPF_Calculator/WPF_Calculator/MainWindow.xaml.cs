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

namespace WPF_Calculator
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

        // sluit de app af, wordt gebruikt door de off button en de exit button boven in het menu genaamd rekenmachine
        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void R_Click(object sender, RoutedEventArgs e) 
        { 
            
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }


    
}

  

