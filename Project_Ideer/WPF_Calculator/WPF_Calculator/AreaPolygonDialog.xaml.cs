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
	/// Interaction logic for AreaPolygonDialog.xaml
	/// </summary>
	public partial class AreaPolygonDialog : Window
	{
		public AreaPolygonDialog(string question1, string question2)
		{
			InitializeComponent();
			LabelQuestion1.Content = question1;
			LabelQuestion2.Content = question2;
			// tooltip text
			TooltipInfo.Text = "Input each Point of a Polygon as a Coordinate System. \n Example \n p1(x1,y1) \n p2(x1,y5) \n p3(x5,y5) \n p4(x5,y1) \n for a Polygon with 4 points";
		}
		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
		private void btnDialogClear_Click(object sender, RoutedEventArgs e)
		{
			txtAnswer1.Text = "";
			txtAnswer2.Text = "";
			txtAnswer3.Text = "";
			txtAnswer4.Text = "";
			txtAnswer5.Text = "";
			txtAnswer6.Text = "";
			txtAnswer7.Text = "";
			txtAnswer8.Text = "";
			txtAnswer9.Text = "";
			txtAnswer10.Text = "";
			txtAnswer11.Text = "";
			txtAnswer12.Text = "";
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
		public string Answer4
		{
			get { return txtAnswer4.Text; }
		}
		public string Answer5
		{
			get { return txtAnswer5.Text; }
		}
		public string Answer6
		{
			get { return txtAnswer6.Text; }
		}
		public string Answer7
		{
			get { return txtAnswer7.Text; }
		}
		public string Answer8
		{
			get { return txtAnswer8.Text; }
		}
		public string Answer9
		{
			get { return txtAnswer9.Text; }
		}
		public string Answer10
		{
			get { return txtAnswer10.Text; }
		}
		public string Answer11
		{
			get { return txtAnswer11.Text; }
		}
		public string Answer12
		{
			get { return txtAnswer12.Text; }
		}
	}
}
