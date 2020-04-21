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
                foreach (Ingredient I in selected.Ingredients)
                {
                    if (I.Type == "Size")
                    {
                        selected.Ingredients.Remove(I);
                        break;
                    }
                }

                var TempSmallSize = new Ingredient() { Name = "Small", Price = 10, Type = "Size" };
                selected.Ingredients.Add(TempSmallSize);
            }
        }
        private void Medium_Selected(object sender, RoutedEventArgs e)
        {
            if (((MainWindow)Application.Current.MainWindow).listView1.SelectedItem is Pizza selected)
            {
                foreach (Ingredient I in selected.Ingredients)
                {
                    if (I.Type == "Size")
                    {
                        selected.Ingredients.Remove(I);
                        break;

                    }
                }
                var TempMediumSize = new Ingredient() { Name = "Medium", Price = 15, Type = "Size" };
                selected.Ingredients.Add(TempMediumSize);
            }
        }
        private void Large_Selected(object sender, RoutedEventArgs e)
        {

            if (((MainWindow)Application.Current.MainWindow).listView1.SelectedItem is Pizza selected)
            {
                foreach (Ingredient I in selected.Ingredients)
                {
                    if (I.Type == "Size")
                    {
                        selected.Ingredients.Remove(I);
                        break;
                    }
                }
                var TempLargeSize = new Ingredient() { Name = "Large", Price = 20, Type = "Size" };
                selected.Ingredients.Add(TempLargeSize);
            }
        }
        // this is probably not needed anymore
        private void Size_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // trying to make to so when you click on the combobox it sets the focus(or selected) to the parent element


            //FrameworkElement ctrl = control; //or whatever you're passing in, since all controls are FrameworkElements.

            //// Move to a parent that can take focus
            //FrameworkElement parent = (FrameworkElement)ctrl.Parent;
            //while (parent != null && parent is IInputElement
            //                  && !((IInputElement)parent).Focusable)
            //{
            //    parent = (FrameworkElement)parent.Parent;
            //}

            //DependencyObject scope = FocusManager.GetFocusScope(ctrl); //can pass in ctrl here because FrameworkElement inherits from DependencyObject
            //FocusManager.SetFocusedElement(scope, parent as IInputElement);
        }

    }
}
