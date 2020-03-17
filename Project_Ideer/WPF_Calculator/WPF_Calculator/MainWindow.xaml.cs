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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            Result.Content = Convert.ToDouble(numberA.Text) / Convert.ToDouble(numberB.Text);
        }
        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            Result.Content = Convert.ToDouble(numberA.Text) + Convert.ToDouble(numberB.Text);
        }
        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            Result.Content = Convert.ToDouble(numberA.Text) - Convert.ToDouble(numberB.Text);
        }
        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            Result.Content = Convert.ToDouble(numberA.Text) * Convert.ToDouble(numberB.Text);
        }
    }
}
