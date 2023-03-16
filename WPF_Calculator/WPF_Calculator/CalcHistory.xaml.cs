using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
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
    /// Interaction logic for CalcHistory.xaml
    /// </summary>
    public partial class CalcHistory : Window
    {

        static class DB 
        {
            public static string connectionDB = "SERVER=localhost;DATABASE=calcresults;USERNAME=root;PASSWORD=Test@1234!";
        }
        
        public CalcHistory()
        {
            InitializeComponent();           

        }

        private void RefreshButton(object sender, RoutedEventArgs e)
        {

        }

  
    }
        
        
    }
}
