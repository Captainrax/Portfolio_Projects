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
            var pizza1 = new Pizza("Custom Pizza", true, false)
            {
                Price = 20,
                Ingredients = new ObservableCollection<Ingredient>(),
                Serial = GenerateSerial()
            };

            //MessageBox.Show(pizza1.PizzaName.ToString());

            DialogResult = true;
		}
		private void btnDialogClear_Click(object sender, RoutedEventArgs e)
		{
		}
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			//txtAnswer1.SelectAll();
			//txtAnswer1.Focus();
		}
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(Foundation_Selection.SelectedItem.ToString());
            try
            {
                //string Foundation = Foundation_Selection.SelectedItem.ToString();
            }
            catch (Exception)
            {
            }

        }
        public int GenerateSerial()
        {
            // returns 1 higher than current highest Serial Number
            int serialcount = 0;
            foreach (Pizza U in MainWindow.templist)
            {
                if (U.Serial >= serialcount)
                {
                    serialcount = U.Serial;
                }
            }
            return serialcount + 1;
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
