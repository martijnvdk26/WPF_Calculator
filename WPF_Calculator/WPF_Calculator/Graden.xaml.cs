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
using WPF_Calculator.MetricImperialContent;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for Graden.xaml
    /// </summary>
    public partial class Graden : UserControl
    {
		private int Decimalen = 2;

		public Graden()
        {
            InitializeComponent();
		}

        public void Omzetten()
        {
            try
            {
                double GradenInput = 0.00;
                double RadialenInput = 0.00;
				double GonInput = 0.00;

                if (double.TryParse(GradenTextBox.Text, out GradenInput) && !double.TryParse(RadialenTextBox.Text, out RadialenInput) && !double.TryParse(GonTextBox.Text, out GonInput))
                {
					Bereken("Graden", GradenInput);
                } 
                else if (!double.TryParse(GradenTextBox.Text, out GradenInput) && double.TryParse(RadialenTextBox.Text, out RadialenInput) && !double.TryParse(GonTextBox.Text, out GonInput))
                {
					Bereken("Radialen", RadialenInput);
				} 
                else if (!double.TryParse(GradenTextBox.Text, out GradenInput) && !double.TryParse(RadialenTextBox.Text, out RadialenInput) && double.TryParse(GonTextBox.Text, out GonInput))
                {
					Bereken("Gon", GonInput);
				} 
                else if (!double.TryParse(GradenTextBox.Text, out GradenInput) || !double.TryParse(RadialenTextBox.Text, out RadialenInput) || !double.TryParse(GonTextBox.Text, out GonInput))
                {
					ErrorOutput.Text = "Foutieve invoer.";
				} 
                else
                {
					ErrorOutput.Text = "Voer A.U.B alleen 1 veld in. Click op 'Clear' om de velden leeg te maken.";
				}
			}
            catch
            {
                ErrorOutput.Text = "Foutieve invoer.";
            }
        }

		private void Bereken(string type, double value)
		{
			switch (type)
			{
				case "Graden":
					{
						RadialenTextBox.Text = Math.Round((value * 0.01745329), Decimalen).ToString();
						GonTextBox.Text = Math.Round((value * 1.1111), Decimalen).ToString();
						ErrorOutput.Text = (100 / 90).ToString();
						break;
					}
				case "Radialen":
					{
						GradenTextBox.Text = Math.Round((value * 57.2958), Decimalen).ToString();
						GonTextBox.Text = Math.Round((value * 63.662), Decimalen).ToString();
						break;
					}
				case "Gon":
					{
						GradenTextBox.Text = Math.Round((value / 1.1111), Decimalen).ToString();
						RadialenTextBox.Text = Math.Round((value * 0.015708), Decimalen).ToString();
						break;
					}
			}
			ErrorOutput.Text = "";
		}

		private void ClearKnop_Click(object sender, RoutedEventArgs e)
		{
            GradenTextBox.Clear();
            RadialenTextBox.Clear();
            GonTextBox.Clear();
		}

		private void Omzetknop_Click(object sender, RoutedEventArgs e)
		{
            Omzetten();
		}

		private void DecimalenInput_TextChanged(object sender, TextChangedEventArgs e)
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
