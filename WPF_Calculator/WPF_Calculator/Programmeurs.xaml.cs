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
using Google.Protobuf.WellKnownTypes;

namespace WPF_Calculator
{
	/// <summary>
	/// Interaction logic for Programmeurs.xaml
	/// </summary>
	public partial class Programmeurs : UserControl
	{
		public Programmeurs()
		{
			InitializeComponent();
		}

		private void Omzetten_click(object sender, RoutedEventArgs e)
		{
			var result = InputBox.Text;
			try
			{
				OutputBox.Text = CalcResult(Convert.ToInt32(result));
			}
			catch
			{
				ErrorOutput.Text = "Foutieve invoer.";
			}
		}

		private string CalcResult(int result)
		{
			switch (RightComboBox.Text)
			{
				case "Hexadecimaal":
					{
						new Repository().insertInDb(2, LeftComboBox.Text, RightComboBox.Text, result, result.ToString("X"));
						return result.ToString("X");
					}
				case "Binair":
					{
						new Repository().insertInDb(2, LeftComboBox.Text, RightComboBox.Text, result, Convert.ToString(result, 2));
						return Convert.ToString(result, 2);
					}
				case "Octaal":
					{
						int quotient, i = 1, j;
						int[] octalNumber = new int[100];
						quotient = result;
						while (quotient != 0)
						{
							octalNumber[i++] = quotient % 8;
							quotient /= 8;
						}

						string res = "";
						for (j = i - 1; j > 0; j--)
							res += octalNumber[j];

						new Repository().insertInDb(2, LeftComboBox.Text, RightComboBox.Text, result, res);
						return res;
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
