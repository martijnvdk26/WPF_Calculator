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

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_7(object sender, RoutedEventArgs e)
        {

        }

        private void Button_8(object sender, RoutedEventArgs e)
        {

        }

        private void Button_9(object sender, RoutedEventArgs e)
        {

        }
    }

  
}
