﻿using System;
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
        }
        double FirstNumber;
        double SecondNumber;
        string Operation;
        
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
            try
            {
                FirstNumber = Convert.ToDouble(Display.Text);
            }
            catch (Exception)
            {
            }
            Display.Text = "";
            Operation = "+";

        }
        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FirstNumber = Convert.ToDouble(Display.Text);
            }
            catch (Exception)
            {
            }
            Display.Text = "";
            Operation = "-";
        }
        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FirstNumber = Convert.ToDouble(Display.Text);
            }
            catch (Exception)
            {
            }
            Display.Text = "";
            Operation = "/";
        }
        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FirstNumber = Convert.ToDouble(Display.Text);
            }
            catch (Exception)
            {
            }
            Display.Text = "";
            Operation = "*";
        }
        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            double Result;
            try
            {
                    SecondNumber = Convert.ToDouble(Display.Text);
            }
            catch (Exception)
            {
            }

            NCalc.Expression ee = new NCalc.Expression(FirstNumber + Operation + SecondNumber);
            Result = Convert.ToDouble( ee.Evaluate());

            Display.Text = Convert.ToString(Result);
            LastResult.Content = "Current Result: " + FirstNumber + Operation + SecondNumber + " = " + Result;
            SecondNumber = Result;
            //MessageBox.Show(Convert.ToString(ble));

            //switch (Operation)
            //{
            //    case "+":
            //        Result = FirstNumber + SecondNumber;
            //        //Display.Text = Convert.ToString(Result);
            //        FirstNumber = Result;
            //        LastResult.Content = "Current Result: " + Result;
            //        break;
            //    case "-":
            //        Result = FirstNumber - SecondNumber;
            //        Display.Text = Convert.ToString(Result);
            //        FirstNumber = Result;
            //        LastResult.Content = "Current Result: " + Result;
            //        break;
            //    case "/":
            //        Result = FirstNumber / SecondNumber;
            //        Display.Text = Convert.ToString(Result);
            //        FirstNumber = Result;
            //        LastResult.Content = "Current Result: " + Result;
            //        break;
            //    case "*":
            //        Result = FirstNumber * SecondNumber;
            //        Display.Text = Convert.ToString(Result);
            //        FirstNumber = Result;
            //        LastResult.Content = "Current Result: " + Result;
            //        break;
            //}

        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "";
            Operation = "";
            FirstNumber = 0;
            SecondNumber = 0;
            LastResult.Content = "Current Result: ";
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
            catch (Exception)
            {

            }
        }
    }
}