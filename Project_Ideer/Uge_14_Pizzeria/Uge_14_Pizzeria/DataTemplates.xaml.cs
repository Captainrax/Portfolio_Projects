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
        public DataTemplates()
        {
            InitializeComponent();
        }

        private void Small_Selected(object sender, RoutedEventArgs e)
        {
            if( ((MainWindow)Application.Current.MainWindow).listView1.SelectedItem is Pizza selected)
            {
                foreach (Ingredient I in MainWindow.IngredientsList)
                {
                    if (I.Type == "Size")
                    {
                        selected.Ingredients.Remove(I);
                    }
                    if (I.Name == "Small")
                    {
                        selected.Ingredients.Add(I);
                    }
                }
            }
        }
        private void Medium_Selected(object sender, RoutedEventArgs e)
        {
            if (((MainWindow)Application.Current.MainWindow).listView1.SelectedItem is Pizza selected)
            {
                foreach (Ingredient I in MainWindow.IngredientsList)
                {
                    if (I.Type == "Size")
                    {
                        selected.Ingredients.Remove(I);
                    }
                    if (I.Name == "Medium")
                    {
                        selected.Ingredients.Add(I);
                    }
                }
            }
        }
        private void Large_Selected(object sender, RoutedEventArgs e)
        {

            if (((MainWindow)Application.Current.MainWindow).listView1.SelectedItem is Pizza selected)
            {
                foreach (Ingredient I in MainWindow.IngredientsList)
                {
                    if (I.Type == "Size")
                    {
                        selected.Ingredients.Remove(I);
                    }
                    if (I.Name == "Large")
                    {
                        selected.Ingredients.Add(I);
                    }
                }
            }
        }
        // this is probably not needed anymore
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
