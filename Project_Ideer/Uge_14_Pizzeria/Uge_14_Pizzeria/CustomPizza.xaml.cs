using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Uge_14_Pizzeria
{
    /// <summary>
    /// Interaction logic for CustomPizza.xaml
    /// </summary>
    public partial class CustomPizza : Window
    {
		public CustomPizza()
        {
            DataContext = new ViewModel();
            InitializeComponent();
			// tooltip text
			TooltipInfo.Text = "ToDo add tooltip info";
		}
		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
            var pizza1 = new Pizza("Custom Pizza", false, false)
            {
                Price = 20,
                Ingredients = new ObservableCollection<Ingredient>(),
                Serial = 1
            };

            foreach(Ingredient I in MainWindow.IngredientsList)
            {   // this can probably be done in a... better way
                if (Foundation_Selection.SelectedItem == null)
                {
                    // forced to choose in XAML
                } 
                else if(Foundation_Selection.SelectedItem.ToString() == I.Name.ToString())
                {
                    pizza1.Ingredients.Add(I);
                }
                if (Sauce_Selection.SelectedItem == null)
                {
                } 
                else if (Sauce_Selection.SelectedItem.ToString() == I.Name.ToString())
                {
                    pizza1.Ingredients.Add(I);
                }
                if (Cheese_Selection.SelectedItem == null)
                {
                }
                else if (Cheese_Selection.SelectedItem.ToString() == I.Name.ToString())
                {
                    pizza1.Ingredients.Add(I);
                }
                if (Proteins_Selection.SelectedItem == null)
                {
                }
                else if (Proteins_Selection.SelectedItem.ToString() == I.Name.ToString())
                {
                    pizza1.Ingredients.Add(I);
                }
                if (Vegetables_Selection.SelectedItem == null)
                {
                }
                else if (Vegetables_Selection.SelectedItem.ToString() == I.Name.ToString())
                {
                    pizza1.Ingredients.Add(I);
                }
                if (Size_Selection.SelectedItem == null)
                {
                    // forced to choose in XAML
                }
                else if (Size_Selection.SelectedItem.ToString() == I.Name.ToString())
                {
                    pizza1.Ingredients.Add(I);
                }
            }
            try // oh god please fix this at some point please.
            {
                int price = pizza1.GetPrice();
                string allingredients = "";
                try
                {
                    foreach (Ingredient I in pizza1.Ingredients)
                    {
                        allingredients += I.Name + ", ";
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }

                PizzaViewModel.checkOutList.Add(pizza1);

                // ToDo Do this using ViewModel
                ((MainWindow)Application.Current.MainWindow).ListView2.Items.Add(pizza1.Name + " " + " - " + allingredients + " - " + price + "Kr");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }

            // debug
            //MessageBox.Show(pizza1.Ingredients.Count.ToString());

            DialogResult = true;
		}
		private void btnDialogClear_Click(object sender, RoutedEventArgs e)
		{
            // it works.
            Sauce_Selection.SelectedItem = null;
            Cheese_Selection.SelectedItem = null;
            Proteins_Selection.SelectedItem = null;
            Vegetables_Selection.SelectedItem = null;
            Size_Selection.SelectedItem = Size_Selection.SelectedIndex = 0;
        }
		private void Window_ContentRendered(object sender, EventArgs e)
		{
            // incase you wanna do some shenanigans on load i guess.
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // this might not be needed, keeping it for now
        }
    }
    public class ViewModel
    {
        public ObservableCollection<string> Foundation_List { get; set; }
        public ObservableCollection<string> Sauce_List { get; set; }
        public ObservableCollection<string> Cheese_List { get; set; }
        public ObservableCollection<string> Proteins_List { get; set; }
        public ObservableCollection<string> Vegetables_List { get; set; }
        public ObservableCollection<string> Size_List { get; set; }

        public ViewModel()
        {
            Foundation_List = new ObservableCollection<string>
            {
            };
            Sauce_List = new ObservableCollection<string>
            {
            };
            Cheese_List = new ObservableCollection<string>
            {
            };
            Proteins_List = new ObservableCollection<string>
            {
            };
            Vegetables_List = new ObservableCollection<string>
            {
            };
            Size_List = new ObservableCollection<string>
            {
            };
            Getingredients(MainWindow.IngredientsList);
        }
        public void Getingredients(ObservableCollection<Ingredient> obsv)
        {
            foreach (Ingredient I in obsv)
            {
                if(I.Type == "Foundation")
                {
                    Foundation_List.Add(I.Name);
                } else if(I.Type == "Sauce")
                {
                    Sauce_List.Add(I.Name);
                } else if(I.Type == "Cheese")
                {
                    Cheese_List.Add(I.Name);
                } else if (I.Type == "Protein")
                {
                    Proteins_List.Add(I.Name);
                } else if (I.Type == "Vegetable")
                {
                    Vegetables_List.Add(I.Name);
                } else if (I.Type == "Size")
                {
                    Size_List.Add(I.Name);
                }
            }

        }
    }
}
