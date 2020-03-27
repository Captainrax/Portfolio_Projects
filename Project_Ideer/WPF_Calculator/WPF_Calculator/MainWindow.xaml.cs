using System;
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
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // maybe change this to a switch instead?
            if (e.Key == Key.Enter)
            {
                EQUALS();
            }
            else if (e.Key == Key.Back)
            {
                BackSpace();
            }
            else if (e.Key == Key.Delete)
            {
                Clear();
            }
            else if (e.Key == Key.OemPlus || e.Key == Key.Add)
            {
                Operator_SetNumbers();
                Operation = "+";
            }
            else if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            {
                Operator_SetNumbers();
                Operation = "-";
            }
            else if (e.Key == Key.Divide)
            {
                Operator_SetNumbers();
                Operation = "/";
            }
            else if (e.Key == Key.Multiply)
            {
                Operator_SetNumbers();
                Operation = "*";
            }
            else if (e.Key == Key.NumPad0 || e.Key == Key.D0)
            {
                Display.Text = Display.Text += "0";
            }
            else if (e.Key == Key.NumPad1 || e.Key == Key.D1)
            {
                Display.Text = Display.Text += "1";
            }
            else if (e.Key == Key.NumPad2 || e.Key == Key.D2)
            {
                Display.Text = Display.Text += "2";
            }
            else if (e.Key == Key.NumPad3 || e.Key == Key.D3)
            {
                Display.Text = Display.Text += "3";
            }
            else if (e.Key == Key.NumPad4 || e.Key == Key.D4)
            {
                Display.Text = Display.Text += "4";
            }
            else if (e.Key == Key.NumPad5 || e.Key == Key.D5)
            {
                Display.Text = Display.Text += "5";
            }
            else if (e.Key == Key.NumPad6 || e.Key == Key.D6)
            {
                Display.Text = Display.Text += "6";
            }
            else if (e.Key == Key.NumPad7 || e.Key == Key.D7)
            {
                Display.Text = Display.Text += "7";
            }
            else if (e.Key == Key.NumPad8 || e.Key == Key.D8)
            {
                Display.Text = Display.Text += "8";
            }
            else if (e.Key == Key.NumPad9 || e.Key == Key.D9)
            {
                Display.Text = Display.Text += "9";
            } 
            else if (e.Key == Key.OemPeriod || e.Key == Key.Decimal)
            {
                Display.Text = Display.Text += ".";
            }
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
            EQUALS();
        }
        private void EQUALS()
        {
            if (InProgress == true)
            {
                try
                {
                    SecondNumber = Convert.ToDouble(Display.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
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
            Result = Convert.ToDouble(ee.Evaluate());

            Display.Text = Convert.ToString(Result);
            LastResult.Content = "Current Result: " + FirstNumber + Operation + SecondNumber + " = " + Result;
            SecondNumber = Result;
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            BackSpace();
        }
        private void Clear()
        {
            Display.Text = "";
            Operation = "";
            FirstNumber = 0;
            SecondNumber = 0;
            LastResult.Content = "Current Result: ";
            InProgress = false;
            Result = 0;
        }
        private void BackSpace()
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
        // Handles Area Events
        private bool ResetSelection = true;
        private void Area_DropDownClosed(object sender, EventArgs e)
        {
            if (ResetSelection == true)
            {
                Area_Calculations();
            }
            ResetSelection = true;
        }
        private void Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // sets ResetSelection to false if a different ComboBoxItem is selected
            ComboBox cmb = sender as ComboBox;
            ResetSelection = !cmb.IsDropDownOpen;
            Area_Calculations();
        }
        // Handles the Area Calculations within the dropdownmenu
        private void Area_Calculations()
        {

            switch (Area_Selection.SelectedItem.ToString())
            {
                case "Circle":
                    AreaInputDialog areaInput = new AreaInputDialog("Enter Radius");
                    areaInput.txtAnswer2.Height = 0;
                    areaInput.LabelQuestion2.Height = 0;
                    areaInput.txtAnswer3.Height = 0;
                    areaInput.LabelQuestion3.Height = 0;
                    areaInput.ShowDialog();
                    try
                    {
                        if (areaInput.Answer1 != "")
                        {
                            // PI x (Radius x Radius)
                            Display.Text = Convert.ToString(Math.PI * (Convert.ToDouble(areaInput.Answer1) * Convert.ToDouble(areaInput.Answer1)));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case "Rectangle":
                    AreaInputDialog areaInput_Square = new AreaInputDialog("Enter Height", "Enter Width", "");
                    areaInput_Square.txtAnswer3.Height = 0;
                    areaInput_Square.LabelQuestion3.Height = 0;
                    areaInput_Square.ShowDialog();
                    try
                    {
                        if (areaInput_Square.Answer1 != "")
                        {
                            // Height x Width
                            Display.Text = Convert.ToString(Convert.ToDouble(areaInput_Square.Answer1) * Convert.ToDouble(areaInput_Square.Answer2));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Trapez":
                    AreaInputDialog areaInput_Trapez = new AreaInputDialog("Enter Parrallel line 1", "Enter Parrallel line 2", "Enter Height");
                    areaInput_Trapez.ShowDialog();
                    try
                    {
                        if (areaInput_Trapez.Answer1 != "")
                        {
                            // (base 1 + base 2) / 2 x height
                            Display.Text = Convert.ToString((Convert.ToDouble(areaInput_Trapez.Answer1) + Convert.ToDouble(areaInput_Trapez.Answer2)) / 2 * Convert.ToDouble(areaInput_Trapez.Answer3));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Cone":
                    AreaInputDialog areaInput_Cone = new AreaInputDialog("Enter Radius", "Enter Height", "");
                    areaInput_Cone.txtAnswer3.Height = 0;
                    areaInput_Cone.LabelQuestion3.Height = 0;
                    areaInput_Cone.ShowDialog();
                    try
                    {
                        if (areaInput_Cone.Answer1 != "")
                        {
                            // L = √( H^2 + R^2 )
                            // Area^2 = PI x R x (R + L)

                            double R = Convert.ToDouble(areaInput_Cone.Answer1);
                            double H = Convert.ToDouble(areaInput_Cone.Answer2);

                            double L = Math.Sqrt(Math.Pow(H, 2) + Math.Pow(R, 2));

                            Display.Text = Convert.ToString(Math.PI * R * (R + L));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Polygon":
                    AreaPolygonDialog AreaInput_Polygon = new AreaPolygonDialog("Enter X", "Enter Y");
                    AreaInput_Polygon.ShowDialog();
                    try
                    {
                        if (AreaInput_Polygon.Answer1 != "")
                        {
                            double X1 = Convert.ToDouble(AreaInput_Polygon.Answer1);
                            double Y1 = Convert.ToDouble(AreaInput_Polygon.Answer2);
                            double X2 = Convert.ToDouble(AreaInput_Polygon.Answer3);
                            double Y2 = Convert.ToDouble(AreaInput_Polygon.Answer4);
                            double X3 = Convert.ToDouble(AreaInput_Polygon.Answer5);
                            double Y3 = Convert.ToDouble(AreaInput_Polygon.Answer6);
                            double X4 = Convert.ToDouble(AreaInput_Polygon.Answer7);
                            double Y4 = Convert.ToDouble(AreaInput_Polygon.Answer8);
                            //double X5 = Convert.ToDouble(AreaInput_Polygon.Answer9);
                            //double Y5 = Convert.ToDouble(AreaInput_Polygon.Answer10);
                            //double X6 = Convert.ToDouble(AreaInput_Polygon.Answer11);
                            //double Y6 = Convert.ToDouble(AreaInput_Polygon.Answer12);
                            double[] xpts = new double[4] {X1,X2,X3,X4 };
                            double[] ypts = new double[4] { Y1, Y2, Y3, Y4 }; 
                            double result = PolygonArea(xpts, ypts, 4);
                            Display.Text = Convert.ToString(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }

        }
        private double PolygonArea(double[] X, double[] Y, int NumPoints)
        {
            double Area = 0;
            int J = NumPoints-1;
            for (int i = 0; i < NumPoints; i++)
            {
                Area += (Convert.ToDouble(X.GetValue(J)) + Convert.ToDouble( X.GetValue(i))) * (Convert.ToDouble(Y.GetValue(J)) - Convert.ToDouble(Y.GetValue(i)));
                J = i;  //j is previous vertex to i
            }
            return Area / 2;
        }

    }
    // datacontext for Area calculation dropdown menu
    public class ViewModel
    {
        public ObservableCollection<string> Area_Content { get; set; }

        public ViewModel()
        {
            Area_Content = new ObservableCollection<string>
            {
            "Circle",
            "Rectangle",
            "Trapez",
            "Cone",
            "Polygon"
            };
        }
    }
}
