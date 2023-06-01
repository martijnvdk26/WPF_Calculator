using System.Windows.Controls;
using System.Windows.Input;
using WPF_Calculator.MetricImperialContent;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MetricImperial.xaml
    /// </summary>
    public partial class MetricImperial : UserControl
    {
        public MetricImperial()
		{
			InitializeComponent();
            this.metricControl.Content = new Lengte();
        }

        private void Navigate(object sender, MouseButtonEventArgs e)
        {
            var page = ((ComboBoxItem)sender).Tag;
            switch (page)
            {
                case "1":
                    this.metricControl.Content = new Lengte();
                    break;
                case "2":
                    this.metricControl.Content = new Gewicht();
                    break;
                case "3":
                    this.metricControl.Content = new Volume();
                    break;
            }
        }
    }
}
