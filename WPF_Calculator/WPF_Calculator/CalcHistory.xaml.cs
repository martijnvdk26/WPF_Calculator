using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for CalcHistory.xaml
    /// </summary>
    public partial class CalcHistory : Window
    {
        //MySql connectie
        


        public CalcHistory()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Port=3306;Database=calcresults;Uid=root;Pwd=Test@1234!;";
            MySqlConnection connection = new MySqlConnection(connectionString);           
            
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM calc", connection);
            connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();

            dataGridCalc.DataContext = dt;

        }



        private void ClearDataButton(object sender, RoutedEventArgs e)
        {

        }



    }
        
        
    
}
