using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            var temp = (sender as Button).Content.ToString();
            if (Math.Text != "")
            {
                if ("+-*/.".Contains(Math.Text.Last()) && "+-*/.".Contains(temp)) { }
                else if (Math.Text.Split("+-*/").Last().Contains('.') && temp == ".") { }
                else Math.Text += temp;
            }
            else Math.Text += temp;
            Sum(sender, e);
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            Math.Text = "";
            Sum(sender, e);
        }
        private void Remove(object sender, RoutedEventArgs e)
        {
            if (Math.Text.Length > 0) { Math.Text = Math.Text.Remove(Math.Text.Length - 1); }
            Sum(sender, e);
        }
        private void Sum(object sender, RoutedEventArgs e)
        {
            try
            {
                var temp = new DataTable().Compute(Math.Text, null).ToString();
                var tmp =0;
                if(int.TryParse(temp, out tmp) == true) 
                if (int.Parse(temp) == double.Parse(temp))
                temp = System.Math.Floor(double.Parse(temp)).ToString();
                Res.Text = temp;
            }
            catch (Exception)
            {

            }
        }
    }
}
