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
    /// Interaction logic for Gewicht.xaml
    /// </summary>
    public partial class Gewicht : UserControl
    {
        public Gewicht()
        {
            InitializeComponent();
        }

        private bool InvertedDirection = true;
        private int Decimalen = 2;

        private Dictionary<string, double> _metricValues = new Dictionary<string, double>()
        {
            {"Gram", 453.59237 },
            {"Kilogram", 0.45359237 }
        };

        private Dictionary<string, double> _imperialValues = new Dictionary<string, double>()
        {
            {"Pound", 453.59237 },
            {"Stone", 6350.29 }
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
                    var calculationValue = 0.00;

                    if (!InvertedDirection) { calculationValue = _imperialValues[LeftComboBox.Text]; }
                    else { calculationValue = _metricValues[LeftComboBox.Text]; }

					switch (RightComboBox.Text)
					{
						case "Pound":
							{
								result = result / calculationValue;
								break;
							}
						case "Stone":
							{
								result = result / calculationValue / 14;
								break;
							}
						case "Gram":
							{
								result = result * calculationValue;
								break;
							}
						case "Kilogram":
							{
								result = result * calculationValue / 1000;
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
