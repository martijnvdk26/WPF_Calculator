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
	/// Interaction logic for Geschiedenis.xaml
	/// </summary>
	public partial class Geschiedenis : UserControl
	{
		public Geschiedenis()
		{
			InitializeComponent();
			dtGrid.DataContext = new Repository().getHistory();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			dtGrid.DataContext = new Repository().clearHistory();
		}
	}
}
