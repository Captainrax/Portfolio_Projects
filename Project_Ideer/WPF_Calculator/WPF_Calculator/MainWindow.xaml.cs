﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using NCalc;

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
            DataContext = new ViewModel();
        }
        double FirstNumber;
        double SecondNumber;
        string Operation;
        bool InProgress = false;
        double Result;

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "0";
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "1";
        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "2";
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "3";
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "4";
        }
        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "5";
        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "6";
        }
        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "7";
        }
        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "8";
        }
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += "9";
        }
        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text += ".";
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            Operator_SetNumbers();
            Operation = "+";
        }
        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            Operator_SetNumbers();
            Operation = "-";
        }
        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            Operator_SetNumbers();
            Operation = "/";
        }
        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            Operator_SetNumbers();
            Operation = "*";
        }
        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            if ( InProgress == true)
            {
                try
                {
                    SecondNumber = Convert.ToDouble(Display.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else {
                try
                {
                    FirstNumber = Convert.ToDouble(Display.Text);
                    InProgress = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // calculates both numbers using the set operator, Using NClac Library
            NCalc.Expression ee = new NCalc.Expression(FirstNumber + Operation + SecondNumber);
            Result = Convert.ToDouble( ee.Evaluate());

            Display.Text = Convert.ToString(Result);
            LastResult.Content = "Current Result: " + FirstNumber + Operation + SecondNumber + " = " + Result;
            SecondNumber = Result;
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "";
            Operation = "";
            FirstNumber = 0;
            SecondNumber = 0;
            LastResult.Content = "Current Result: ";
            InProgress = false;
            Result = 0;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1);
                if (Display.Text.Length < 1)
                {
                    SecondNumber = 0;
                }
                else
                {
                    SecondNumber = Convert.ToDouble(Display.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // sets numbers according to current state
        private void Operator_SetNumbers()
        {
            if (InProgress == true)
            {
                try {
                    SecondNumber = Convert.ToDouble(Display.Text);
                    InProgress = false;
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else {
                try {
                    FirstNumber = Convert.ToDouble(Display.Text);
                    InProgress = true;
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            Display.Text = "";
        }
       
        private void Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(Area_Selection.SelectedItem.ToString());

            double temp_result;

            try {
                if (FirstNumber == 0 || SecondNumber == 0)
                {
                    temp_result = Convert.ToDouble(Display.Text);
                }
                else
                {
                    temp_result = Result;
                }
            } catch (Exception ex)  {
                //MessageBox.Show(ex.Message);
            }

            switch (Area_Selection.SelectedItem.ToString())
            {
                case "Circle":
                    AreaInputDialog areaInput = new AreaInputDialog("Enter Radius", "");
                    areaInput.ShowDialog();
                    try {
                        if(areaInput.Answer != "")
                        {
                            Display.Text = Convert.ToString(Math.PI * (Convert.ToDouble(areaInput.Answer) * Convert.ToDouble(areaInput.Answer)));
                        }
                    }   catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case "Square":
                    AreaInputDialog areaInput_Square = new AreaInputDialog("Enter Radius", "");
                    areaInput_Square.ShowDialog();
                    try
                    {
                        if (areaInput_Square.Answer != "")
                        {
                            Display.Text = Convert.ToString(Math.PI * (Convert.ToDouble(areaInput_Square.Answer) * Convert.ToDouble(areaInput_Square.Answer)));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Trapez":

                    break;
                case "Cone":

                    break;
            }
        }


    }
    public class ViewModel
    {
        public ObservableCollection<string> Area_Content { get; set; }

        public ViewModel()
        {
            Area_Content = new ObservableCollection<string>
            {
            "Circle",
            "Square",
            "Trapez",
            "Cone"
            };
        }
    }
}
