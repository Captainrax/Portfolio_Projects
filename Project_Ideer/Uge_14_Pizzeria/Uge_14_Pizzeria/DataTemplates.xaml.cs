using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Uge_14_Pizzeria
{
    partial class DataTemplates : ResourceDictionary
    {
        public static bool SizeSmall;
        public static bool SizeLarge;
        public DataTemplates()
        {
            InitializeComponent();
        }

        private void Small_Selected(object sender, RoutedEventArgs e)
        {
            SizeLarge = false;
            SizeSmall = true;
        }

        private void Large_Selected(object sender, RoutedEventArgs e)
        {
            SizeSmall = false;
            SizeLarge = true;
        }
        // this needs fixing so when you change size for one, it dosnt change size for everyone.
        private void Size_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //switch (SizeSelection.SelectedItem.ToString())
            //{
            //    case "Circle":

            //        break;
            //}
        }
    }
}
