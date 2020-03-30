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

        private void Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //switch (SizeSelection.SelectedItem.ToString())
            //{
            //    case "Circle":

            //        break;
            //}
        }

    }
    // datacontext for Area calculation dropdown menu
    public class ViewModel
    {
        public ObservableCollection<string> Sizes { get; set; }

        public ViewModel()
        {
            Sizes = new ObservableCollection<string>
            {
            "Small",
            "Large"
            };
        }
    }
}
