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
	/// Interaction logic for Koersen.xaml
	/// </summary>
	public partial class Koersen : UserControl
	{
		public Koersen()
		{
			InitializeComponent();
		}

		private void Omzetten_click(object sender, RoutedEventArgs e)
		{
			var result = InputBox.Text;
			try
			{
				OutputBox.Text = CalcResult(Convert.ToDouble(result), Convert.ToDouble(koersInput.Text));
			}
			catch
			{
				ErrorOutput.Text = "Foutieve invoer.";
			}
		}

		private string CalcResult(double result, double koers)
		{
			switch (LeftComboBox.Text)
			{
				case "Britse Pond":
					{
						new Repository().insertInDb(4, LeftComboBox.Text, RightComboBox.Text, result, Math.Round(result * koers, 2));
						return Convert.ToString(Math.Round(result * koers, 2));
					}
				case "Dollar":
					{
						new Repository().insertInDb(4, LeftComboBox.Text, RightComboBox.Text, result, Math.Round(result * koers, 2));
						return Convert.ToString(Math.Round(result * koers, 2));
					}
			}

			return "";
		}

		private void SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (InputBox.Text != "")
			{
				OutputBox.Text = "";
			}
		}
	}
}
