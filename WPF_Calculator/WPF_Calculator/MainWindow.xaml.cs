﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			this.contentControl.Content = new MetricImperial();
		}

        private void Exit_Application(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Navigate(object sender, MouseButtonEventArgs e)
        {
            var page = ((ComboBoxItem)sender).Tag;
            switch (page)
            {
                case "1":
                    this.contentControl.Content = new MetricImperial();
                    break;
                case "2":
                    this.contentControl.Content = new Graden();
                    break;
            }
        }
	}  
}
