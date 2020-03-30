using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Uge_14_Pizzeria
{
    partial class DataTemplates : ResourceDictionary
    {
        public static string PizzaSize = "";
        public DataTemplates()
        {
            InitializeComponent();
        }

        private void SizeSmall_Checked(object sender, RoutedEventArgs e)
        {
            PizzaSize = "Small";
        }
        private void SizeLarge_Checked(object sender, RoutedEventArgs e)
        {
            
            PizzaSize = "Large";
        }

    }
}
