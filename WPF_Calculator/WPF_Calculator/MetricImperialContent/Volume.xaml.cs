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

namespace WPF_Calculator.MetricImperialContent
{
	/// <summary>
	/// Interaction logic for Volume.xaml
	/// </summary>
	public partial class Volume : UserControl
	{
		public Volume()
		{
			InitializeComponent();
		}

		private bool InvertedDirection = true;
		private int Decimalen = 2;

		private Dictionary<string, double> _metricValues = new Dictionary<string, double>()
		{
			{"Milliliter", 1 },
			{"Centiliter", 10},
			{"Deciliter", 100 },
			{"Liter", 1000 }
		};

		private Dictionary<string, double> _imperialValues = new Dictionary<string, double>()
		{
			{"Fluid Ounce", 1 },
			{"Gill", 5 },
			{"Pint", 20 },
			{"Quart", 40 },
			{"Gallon", 160 }
		};

		public void InvertDirection(object sender, RoutedEventArgs e)
		{
			InvertedDirection = !InvertedDirection;
			var LeftSelectedItem = LeftComboBox.SelectedIndex;
			var RightSelectedItem = RightComboBox.SelectedIndex;
			LeftComboBox.Items.Clear();
			RightComboBox.Items.Clear();

			if (InvertedDirection)
			{
				foreach (var key in _metricValues.Keys)
				{
					ComboBoxItem newItem = new ComboBoxItem();
					newItem.Content = key;
					LeftComboBox.Items.Add(newItem);
				}

				foreach (var key in _imperialValues.Keys)
				{
					ComboBoxItem newItem = new ComboBoxItem();
					newItem.Content = key;
					RightComboBox.Items.Add(newItem);
				}

				DirectionText.Text = "Metric -> Imperial";
			}
			else
			{
				foreach (var key in _metricValues.Keys)
				{
					ComboBoxItem newItem = new ComboBoxItem();
					newItem.Content = key;
					RightComboBox.Items.Add(newItem);
				}

				foreach (var key in _imperialValues.Keys)
				{
					ComboBoxItem newItem = new ComboBoxItem();
					newItem.Content = key;
					LeftComboBox.Items.Add(newItem);
				}

				DirectionText.Text = "Imperial -> Metric";
			}

			LeftComboBox.SelectedIndex = RightSelectedItem;
			RightComboBox.SelectedIndex = LeftSelectedItem;
			if (OutputBox.Text != "")
			{
				InputBox.Text = OutputBox.Text;
				if (InputBox.Text != "")
				{
					Omzetten();
				}
			}
		}

		private void SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (InputBox.Text != "")
			{
				OutputBox.Text = "";
			}
		}

		private void Omzetten_click(object sender, RoutedEventArgs e)
		{
			Omzetten();
		}

		private void Omzetten()
		{
			var result = 0.00;
			try
			{
				if (InputBox.Text != "")
				{
					ErrorOutput.Text = "";
					result = Convert.ToDouble(InputBox.Text);
					double calculationVal = 0.00;

					if (InvertedDirection) { calculationVal = _metricValues[LeftComboBox.Text]; }
					else { calculationVal = _imperialValues[LeftComboBox.Text]; }

					switch (RightComboBox.Text)
					{
						case "Milliliter":
							{
								result = result * 28.413 * calculationVal;
								break;
							}
						case "Centiliter":
							{
								result = result * 28.413 * calculationVal;
								break;
							}
						case "Deciliter":
							{
								result = result * 28.413 * calculationVal;
								break;
							}
						case "Liter":
							{
								result = result * 28.413 * calculationVal;
								break;
							}
						case "Fluid Ounce":
							{
								result = result / 28.413 * calculationVal;
								break;
							}
						case "Gill":
							{
								result = result / 142.1 * calculationVal;
								break;
							}
						case "Pint":
							{
								result = result / 568.3 * calculationVal;
								break;
							}
						case "Quart":
							{
								result = result / 1137 * calculationVal;
								break;
							}
						case "Gallon":
							{
								result = result / 4546 * calculationVal;
								break;
							}
					}

					if (Math.Round(result, Decimalen) == 0)
					{
						OutputBox.Text = "Te Klein.";
					}
					else
					{
						OutputBox.Text = Math.Round(result, Decimalen).ToString();
					}
				}
				else
				{
					ErrorOutput.Text = "Lege Invoer.";
				}

			}
			catch
			{
				ErrorOutput.Text = "Foutieve Invoer.";
			}
		}

		private void DecimalenInput_Changed(object sender, TextChangedEventArgs e)
		{
			if (ErrorOutput != null)
			{
				try
				{
					if (Convert.ToInt32(DecimalenInput.Text) > 15)
					{
						Decimalen = 15;
						ErrorOutput.Text = "Te Grote Decimalen Invoer. Het Maximale 15 wordt gebruikt.";
					}
					else
					{
						Decimalen = Convert.ToInt32(DecimalenInput.Text);
						ErrorOutput.Text = "";
					}
				}
				catch
				{
					Decimalen = 2;
					ErrorOutput.Text = "Foutieve Decimalen Invoer. Standaard 2 wordt gebruikt.";
				}
			}
		}
	}
}
