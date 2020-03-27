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

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for AreaInputDialog.xaml
    /// </summary>
    public partial class AreaInputDialog : Window
    {
		public AreaInputDialog(string question1, string question2, string question3, string defaultAnswer = "")
		{
			InitializeComponent();
			LabelQuestion1.Content = question1;
			LabelQuestion2.Content = question2;
			LabelQuestion3.Content = question3;
			txtAnswer1.Text = defaultAnswer;
			txtAnswer2.Text = defaultAnswer;
			txtAnswer3.Text = defaultAnswer;
		}
		public AreaInputDialog(string question1, string defaultAnswer = "")
		{
			InitializeComponent();
			LabelQuestion1.Content = question1;
			txtAnswer1.Text = defaultAnswer;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
		private void btnDialogCancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			txtAnswer1.SelectAll();
			txtAnswer1.Focus();
		}

		public string Answer1
		{
			get { return txtAnswer1.Text; }
		}
		public string Answer2
		{
			get { return txtAnswer2.Text; }
		}
		public string Answer3
		{
			get { return txtAnswer3.Text; }
		}
	}
}

