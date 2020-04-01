using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Uge_14_Pizzeria
{
    /// <summary>
    /// Interaction logic for CustomPizza.xaml
    /// </summary>
    public partial class CustomPizza : Window
    {
		public CustomPizza(string question1, string question2)
		{
			InitializeComponent();
			LabelQuestion1.Content = question1;
			LabelQuestion2.Content = question2;
			// tooltip text
			TooltipInfo.Text = "ToDo add tooltip info";
		}
		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
		private void btnDialogClear_Click(object sender, RoutedEventArgs e)
		{
		}
		private void Window_ContentRendered(object sender, EventArgs e)
		{
		}

	}
}
