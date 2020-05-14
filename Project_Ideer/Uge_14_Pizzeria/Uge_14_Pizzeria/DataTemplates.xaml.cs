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
            // changes size ingredient based on selected item
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
            SizeUpdatePrice();
        }
        private void Medium_Selected(object sender, RoutedEventArgs e)
        {
            // changes size ingredient based on selected item
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
            SizeUpdatePrice();
        }
        private void Large_Selected(object sender, RoutedEventArgs e)
        {
            if (((MainWindow)Application.Current.MainWindow).listView1.SelectedItem is Pizza selected)
            {
                // changes size ingredient based on selected item
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
            SizeUpdatePrice();
        }
        public void SizeUpdatePrice()
        {
            foreach (IFoodItem I in PizzaViewModel.orderMenu)
            {
                I.Price[0] = I.GetPrice;
            }
        }
        private void Size_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SizeUpdatePrice();
        }

        private void SizeSelection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                // this freaking works holy moly

                var item = (sender as FrameworkElement).DataContext;
                int index = ((MainWindow)Application.Current.MainWindow).listView1.Items.IndexOf(item);

                ((MainWindow)Application.Current.MainWindow).listView1.SelectedIndex = index;
                //MessageBox.Show(index.ToString());
            }
        }

        private void ButtonRemoveSelection_Click(object sender, RoutedEventArgs e) // removes it self
        {

            var item = (sender as FrameworkElement).DataContext;
            int index = ((MainWindow)Application.Current.MainWindow).ListView2.Items.IndexOf(item);

            foreach (IFoodItem I in PizzaViewModel.checkOutList)
            {
                if (I.DiscountApplied == true)
                {
                    I.LoadIngredients(); // loads old ingredients without the discount
                    I.DiscountApplied = false;

                    PizzaViewModel.checkOutList.RemoveAt(index);

                    MainWindow.DiscountApplied = false;
                    MainWindow.DiscountEffect = "";
                    Discounts.Discount1(); // applies the discount agian
                    break;
                }
            }

            PizzaViewModel.Update();
        }
    }
}
