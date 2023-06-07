using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Calculator.MetricImperialContent
{
    /// <summary>
    /// Interaction logic for Lengte.xaml
    /// </summary>
    public partial class Lengte : UserControl
    {
        public Lengte()
        {
            InitializeComponent();
        }

        private bool InvertedDirection = false;
        private int Decimalen = 2;

        private Dictionary<string, double> _metricValues = new Dictionary<string, double>()
        {
            {"Centimeter", 1 },
            {"Meter", 100 },
            {"Kilometer", 1000 }
        };
        private Dictionary<string, double> _imperialValues = new Dictionary<string, double>()
        {
            {"Inch", 1 },
            {"Voet", 12 },
            {"Mile", 63359 }
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

                    var multiplier = 1;
                    switch (LeftComboBox.Text)
                    {
                        case "Meter":
                            {
                                multiplier = 100;
                                break;
                            }
                        case "Kilometer":
                            {
                                multiplier = 1000 * 100;
                                break;
                            }
                        case "Voet":
                            {
                                multiplier = 12 * 12;
                                break;
                            }
                        case "Mile":
                            {
                                multiplier = 5280 * 12;
                                break;
                            }
                    }

                    switch (RightComboBox.Text)
                    {
                        case "Centimeter":
                            {
                                result = result * 2.54 * multiplier;
                                break;
                            }
                        case "Meter":
                            {
                                result = result * 2.54 / 100 * multiplier;
                                break;
							}
                        case "Kilometer":
                            {
                                result = result * 2.54 / 100000 * multiplier;
                                break;
							}
						case "Inch":
							{
								result = result / 2.54 * multiplier;
								break;
							}
						case "Voet":
							{
								result = result / 2.54 / 12 * multiplier;
								break;
							}
						case "Mile":
							{
								result = result / 2.54 / 12 / 5280 * multiplier;
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
                        new Repository().insertInDb(1, LeftComboBox.Text, RightComboBox.Text, Convert.ToDouble(InputBox.Text), Math.Round(result, Decimalen));
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
