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
        public static ObservableCollection<Ingredient> IngredientsList; // used by CustomPizza viewmodel
        public CustomPizza()
        {
            InitializeComponent();
			// tooltip text
			TooltipInfo.Text = "Each Ingredient Type is 5kr. \n Sizes: \n Small: 10kr. \n Medium: 15kr. \n Large: 20kr.";

            // Manually adding fooditems and ingredients
            Ingredient Thin_Crust = new Ingredient() { Name = "Thin Crust", Price = 5, Type = "Foundation" };
            Ingredient Thick_Crust = new Ingredient() { Name = "Thick Crust", Price = 5, Type = "Foundation" };
            Ingredient Stuffed_Crust = new Ingredient() { Name = "Stuffed Crust", Price = 5, Type = "Foundation" };
            Ingredient TomatoSauce = new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" };
            Ingredient BBQDressing = new Ingredient() { Name = "BBQDressing", Price = 5, Type = "Sauce" };
            Ingredient Mozzarella = new Ingredient() { Name = "Mozzarella", Price = 5, Type = "Cheese" };
            Ingredient Emmentaler = new Ingredient() { Name = "Emmentaler", Price = 5, Type = "Cheese" };
            Ingredient Ham = new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" };
            Ingredient Pepperoni = new Ingredient() { Name = "Pepperoni", Price = 5, Type = "Protein" };
            Ingredient Onion = new Ingredient() { Name = "Onion", Price = 5, Type = "Vegetable" };
            Ingredient Salad = new Ingredient() { Name = "Salad", Price = 5, Type = "Vegetable" };

            Ingredient SmallSize = new Ingredient() { Name = "Small", Price = 10, Type = "Size" };
            Ingredient MediumSize = new Ingredient() { Name = "Medium", Price = 15, Type = "Size" };
            Ingredient LargeSize = new Ingredient() { Name = "Large", Price = 20, Type = "Size" };

            IngredientsList = new ObservableCollection<Ingredient>()
            {
                Thin_Crust, Thick_Crust, Stuffed_Crust,
                TomatoSauce, BBQDressing,
                Mozzarella, Emmentaler,
                Ham, Pepperoni,
                Onion, Salad,
                SmallSize, MediumSize, LargeSize
            };

            // DataContext
            DataContext = new ViewModel();
        }
		private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
		{
            // new instance of a pizza so it dosnt get affected by other things
            for (int x = 1; Convert.ToInt32(AmountOfPizza.Text) >= x ; x++)
            {

                Pizza pizza999 = new Pizza("Custom Pizza")
                {
                    Type = "Pizza",
                    Ingredients = new ObservableCollection<Ingredient>(),
                    Serial = MainWindow.GenerateSerial()
                };

                //debug
                //MessageBox.Show(rb1.IsChecked.ToString());

                // Foundations (only 1 can be selected through xaml)
                if (RB_Crust1.IsChecked == true)
                {
                    Ingredient Thin_Crust = new Ingredient() { Name = "Thin Crust", Price = 5, Type = "Foundation" };
                    pizza999.Ingredients.Add(Thin_Crust);
                }
                if (RB_Crust2.IsChecked == true)
                {
                    Ingredient Thick_Crust = new Ingredient() { Name = "Thick Crust", Price = 5, Type = "Foundation" };
                    pizza999.Ingredients.Add(Thick_Crust);
                }
                if (RB_Crust3.IsChecked == true)
                {
                    Ingredient Stuffed_Crust = new Ingredient() { Name = "Stuffed Crust", Price = 5, Type = "Foundation" };
                    pizza999.Ingredients.Add(Stuffed_Crust);
                }
                // Sauces
                if (RB_Sauce1.IsChecked == true)
                {
                    Ingredient TomatoSauce = new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" };
                    pizza999.Ingredients.Add(TomatoSauce);
                }
                if (RB_Sauce2.IsChecked == true)
                {
                    Ingredient BBQDressing = new Ingredient() { Name = "BBQDressing", Price = 5, Type = "Sauce" };
                    pizza999.Ingredients.Add(BBQDressing);
                }
                // Cheeses
                if (RB_Cheese1.IsChecked == true)
                {
                    Ingredient Mozzarella = new Ingredient() { Name = "Mozzarella", Price = 5, Type = "Cheese" };
                    pizza999.Ingredients.Add(Mozzarella);
                }
                if (RB_Chesse2.IsChecked == true)
                {
                    Ingredient Emmentaler = new Ingredient() { Name = "Emmentaler", Price = 5, Type = "Cheese" };
                    pizza999.Ingredients.Add(Emmentaler);
                }
                // Proteins
                if (RB_Proteins1.IsChecked == true)
                {
                    Ingredient Ham = new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" };
                    pizza999.Ingredients.Add(Ham);
                }
                if (RB_Proteins2.IsChecked == true)
                {
                    Ingredient Pepperoni = new Ingredient() { Name = "Pepperoni", Price = 5, Type = "Protein" };
                    pizza999.Ingredients.Add(Pepperoni);
                }
                // Vegetables
                if (RB_Vegetables1.IsChecked == true)
                {
                    Ingredient Onion = new Ingredient() { Name = "Onion", Price = 5, Type = "Vegetable" };
                    pizza999.Ingredients.Add(Onion);
                }
                if (RB_Vegetables2.IsChecked == true)
                {
                    Ingredient Salad = new Ingredient() { Name = "Salad", Price = 5, Type = "Vegetable" };
                    pizza999.Ingredients.Add(Salad);
                }
                // Sizes (only 1 can be selected through xaml)
                if (RB_Size1.IsChecked == true)
                {
                    Ingredient SmallSize = new Ingredient() { Name = "Small", Price = 10, Type = "Size" };
                    pizza999.Ingredients.Add(SmallSize);
                }
                if (RB_Size2.IsChecked == true)
                {
                    Ingredient MediumSize = new Ingredient() { Name = "Medium", Price = 15, Type = "Size" };
                    pizza999.Ingredients.Add(MediumSize);
                }
                if (RB_Size3.IsChecked == true)
                {
                    Ingredient LargeSize = new Ingredient() { Name = "Large", Price = 20, Type = "Size" };
                    pizza999.Ingredients.Add(LargeSize);
                }

                //switch (Foundation_Selection.SelectedItem.ToString())
                //{
                //    case "Thin Crust":
                //        Ingredient Thin_Crust = new Ingredient() { Name = "Thin Crust", Price = 5, Type = "Foundation" };
                //        pizza999.Ingredients.Add(Thin_Crust);
                //        break;
                //    case "Thick Crust":
                //        Ingredient Thick_Crust = new Ingredient() { Name = "Thick Crust", Price = 5, Type = "Foundation" };
                //        pizza999.Ingredients.Add(Thick_Crust);
                //        break;
                //    case "Stuffed Crust":
                //        Ingredient Stuffed_Crust = new Ingredient() { Name = "Stuffed Crust", Price = 5, Type = "Foundation" };
                //        pizza999.Ingredients.Add(Stuffed_Crust);
                //        break;
                //}
                //switch (Sauce_Selection.SelectedItem.ToString())
                //{
                //    case "TomatoSauce":
                //        Ingredient TomatoSauce = new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" };
                //        pizza999.Ingredients.Add(TomatoSauce);
                //        break;
                //    case "BBQDressing":
                //        Ingredient BBQDressing = new Ingredient() { Name = "BBQDressing", Price = 5, Type = "Sauce" };
                //        pizza999.Ingredients.Add(BBQDressing);
                //        break;
                //}
                //switch (Cheese_Selection.SelectedItem.ToString())
                //{
                //    case "Mozzarella":
                //        Ingredient Mozzarella = new Ingredient() { Name = "Mozzarella", Price = 5, Type = "Cheese" };
                //        pizza999.Ingredients.Add(Mozzarella);
                //        break;
                //    case "Emmentaler":
                //        Ingredient Emmentaler = new Ingredient() { Name = "Emmentaler", Price = 5, Type = "Cheese" };
                //        pizza999.Ingredients.Add(Emmentaler);
                //        break;
                //}
                //switch (Proteins_Selection.SelectedItem.ToString())
                //{
                //    case "Ham":
                //        Ingredient Ham = new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" };
                //        pizza999.Ingredients.Add(Ham);
                //        break;
                //    case "Pepperoni":
                //        Ingredient Pepperoni = new Ingredient() { Name = "Pepperoni", Price = 5, Type = "Protein" };
                //        pizza999.Ingredients.Add(Pepperoni);
                //        break;
                //}
                //switch (Vegetables_Selection.SelectedItem.ToString())
                //{
                //    case "Onion":
                //        Ingredient Onion = new Ingredient() { Name = "Onion", Price = 5, Type = "Vegetable" };
                //        pizza999.Ingredients.Add(Onion);
                //        break;
                //    case "Salad":
                //        Ingredient Salad = new Ingredient() { Name = "Salad", Price = 5, Type = "Vegetable" };
                //        pizza999.Ingredients.Add(Salad);
                //        break;
                //}
                //switch (Size_Selection.SelectedItem.ToString())
                //{
                //    case "Small":
                //        Ingredient SmallSize = new Ingredient() { Name = "Small", Price = 10, Type = "Size" };
                //        pizza999.Ingredients.Add(SmallSize);
                //        break;
                //    case "Medium":
                //        Ingredient MediumSize = new Ingredient() { Name = "Medium", Price = 15, Type = "Size" };
                //        pizza999.Ingredients.Add(MediumSize);
                //        break;
                //    case "Large":
                //        Ingredient LargeSize = new Ingredient() { Name = "Large", Price = 20, Type = "Size" };
                //        pizza999.Ingredients.Add(LargeSize);
                //        break;
                //}

                // adds the custom pizza to the checkout list
                try
                {
                    pizza999.Price = pizza999.UpdatePrice;
                    try
                    {
                        // adds custompizza to checkOutList
                        PizzaViewModel.checkOutList.Add(pizza999);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.ToString());
                    }

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }

                // debug
                //MessageBox.Show(pizza999.Ingredients.Count.ToString());

            }

            DialogResult = true;
		}
		private void BtnDialogClear_Click(object sender, RoutedEventArgs e)
		{
            // it works.
            RB_Crust1.IsChecked = true;
            RB_Sauce1.IsChecked = false;
            RB_Sauce2.IsChecked = false;
            RB_Cheese1.IsChecked = false;
            RB_Chesse2.IsChecked = false;
            RB_Proteins1.IsChecked = false;
            RB_Proteins2.IsChecked = false;
            RB_Vegetables1.IsChecked = false;
            RB_Vegetables2.IsChecked = false;
            RB_Size1.IsChecked = true;
            //Foundation_Selection.SelectedItem = Foundation_Selection.SelectedIndex = 0;
            //Sauce_Selection.SelectedItem = Sauce_Selection.SelectedIndex = 2; // Nothing
            //Cheese_Selection.SelectedItem = Cheese_Selection.SelectedIndex = 2; // Nothing
            //Proteins_Selection.SelectedItem = Proteins_Selection.SelectedIndex = 2; // Nothing
            //Vegetables_Selection.SelectedItem = Vegetables_Selection.SelectedIndex = 2; // Nothing
            //Size_Selection.SelectedItem = Size_Selection.SelectedIndex = 0;
            AmountOfPizza.Text = "1";
        }
		private void Window_ContentRendered(object sender, EventArgs e)
		{
            // incase you wanna do some shenanigans on load i guess.
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // this might not be needed, keeping it for now
        }
        // handles the amount of custom pizza's you wanna add in one go
        private void AmountPlus_Click(object sender, RoutedEventArgs e)
        {
            int tempchange = Convert.ToInt32(AmountOfPizza.Text);

            if (tempchange <= 19)
            {
                tempchange += 1;
            }
            AmountOfPizza.Text = tempchange.ToString();
        }
        private void AmountMinus_Click(object sender, RoutedEventArgs e)
        {
            int tempchange = Convert.ToInt32(AmountOfPizza.Text);

            if (tempchange >= 2)
            {
                tempchange -= 1;
            }
            AmountOfPizza.Text = tempchange.ToString();
        }
    }
    // ViewModel for all avaliable ingredients
    public class ViewModel
    {
        public static ObservableCollection<string> Foundation_List { get; set; }
        public ObservableCollection<string> Sauce_List { get; set; }
        public ObservableCollection<string> Cheese_List { get; set; }
        public ObservableCollection<string> Proteins_List { get; set; }
        public ObservableCollection<string> Vegetables_List { get; set; }
        public ObservableCollection<string> Size_List { get; set; }

        public ViewModel()
        {
            Foundation_List = new ObservableCollection<string> { };
            Sauce_List = new ObservableCollection<string> { };
            Cheese_List = new ObservableCollection<string> { };
            Proteins_List = new ObservableCollection<string>  { };
            Vegetables_List = new ObservableCollection<string> { };
            Size_List = new ObservableCollection<string> { };

            Getingredients(CustomPizza.IngredientsList);
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
            // adds "nothing" option so it dosnt get a null exeception
            string NothingOption = "Nothing";
            Sauce_List.Add(NothingOption);
            Cheese_List.Add(NothingOption);
            Proteins_List.Add(NothingOption);
            Vegetables_List.Add(NothingOption);
        }
    }
}
