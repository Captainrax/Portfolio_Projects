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
        public static ObservableCollection<Ingredient> IngredientsList = new ObservableCollection<Ingredient>(); // used by CustomPizza
        public CustomPizza()
        {
            InitializeComponent();
			// tooltip text
			TooltipInfo.Text = "ToDo add tooltip info";

            // Manually adding fooditems and ingredients
            var Traditional = new Ingredient() { Name = "Traditional", Price = 5, Type = "Foundation" };
            var TomatoSauce = new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" };
            var Cheese = new Ingredient() { Name = "Cheese", Price = 5, Type = "Cheese" };
            var Ham = new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" };
            var Onion = new Ingredient() { Name = "Onion", Price = 5, Type = "Vegetable" };

            var SmallSize = new Ingredient() { Name = "Small", Price = 10, Type = "Size" };
            var MediumSize = new Ingredient() { Name = "Medium", Price = 15, Type = "Size" };
            var LargeSize = new Ingredient() { Name = "Large", Price = 20, Type = "Size" };

            IngredientsList.Add(Traditional);
            IngredientsList.Add(TomatoSauce);
            IngredientsList.Add(Cheese);
            IngredientsList.Add(Ham);
            IngredientsList.Add(Onion);
            IngredientsList.Add(SmallSize);
            IngredientsList.Add(MediumSize);
            IngredientsList.Add(LargeSize);

            // DataContext
            DataContext = new ViewModel();
        }
		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
            // new instance of a pizza so it dosnt get affected by other things
            var pizza999 = new Pizza("Custom Pizza")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>(),
                Serial = MainWindow.GenerateSerial()
            };

            // this feels like a future proof ish way of doing it
            switch (Foundation_Selection.SelectedItem.ToString())
            {
                case "Traditional":
                    var Traditional = new Ingredient() { Name = "Traditional", Price = 5, Type = "Foundation" };
                    pizza999.Ingredients.Add(Traditional);
                    break;
            }
            switch (Sauce_Selection.SelectedItem.ToString())
            {
                case "TomatoSauce":
                    var TomatoSauce = new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" };
                    pizza999.Ingredients.Add(TomatoSauce);
                    break;
            }
            switch (Cheese_Selection.SelectedItem.ToString())
            {
                case "Cheese":
                    var Cheese = new Ingredient() { Name = "Cheese", Price = 5, Type = "Cheese" };
                    pizza999.Ingredients.Add(Cheese);
                    break;
            }
            switch (Proteins_Selection.SelectedItem.ToString())
            {
                case "Ham":
                    var Ham = new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" };
                    pizza999.Ingredients.Add(Ham);
                    break;
            }
            switch (Vegetables_Selection.SelectedItem.ToString())
            {
                case "Onion":
                    var Onion = new Ingredient() { Name = "Onion", Price = 5, Type = "Vegetable" };
                    pizza999.Ingredients.Add(Onion);
                    break;
            }
            switch (Size_Selection.SelectedItem.ToString())
            {
                case "Small":
                    var SmallSize = new Ingredient() { Name = "Small", Price = 10, Type = "Size" };
                    pizza999.Ingredients.Add(SmallSize);
                    break;
                case "Medium":
                    var MediumSize = new Ingredient() { Name = "Medium", Price = 15, Type = "Size" };
                    pizza999.Ingredients.Add(MediumSize);
                    break;
                case "Large":
                    var LargeSize = new Ingredient() { Name = "Large", Price = 20, Type = "Size" };
                    pizza999.Ingredients.Add(LargeSize);
                    break;
            }

            // adds the custom pizza to the checkout list and right panel
            try 
            {
                int price = pizza999.GetPrice;
                string allingredients = "";
                try
                {
                    foreach (Ingredient I in pizza999.Ingredients)
                    {
                        allingredients += I.Name + ", ";
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }

                PizzaViewModel.checkOutList.Add(pizza999);

                // ToDo Do this using ViewModel
                ((MainWindow)Application.Current.MainWindow).ListView2.Items.Add(pizza999.Name + " " + " - " + allingredients + " - " + price + "Kr");
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
            Foundation_Selection.SelectedItem = Foundation_Selection.SelectedIndex = 0;
            Sauce_Selection.SelectedItem = Sauce_Selection.SelectedIndex = 1; // Nothing
            Cheese_Selection.SelectedItem = Cheese_Selection.SelectedIndex = 1; // Nothing
            Proteins_Selection.SelectedItem = Proteins_Selection.SelectedIndex = 1; // Nothing
            Vegetables_Selection.SelectedItem = Vegetables_Selection.SelectedIndex = 1; // Nothing
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
    // ViewModel for all avaliable ingredients
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
            string NothingOption = "Nothing";
            Sauce_List.Add(NothingOption);
            Cheese_List.Add(NothingOption);
            Proteins_List.Add(NothingOption);
            Vegetables_List.Add(NothingOption);
        }
    }
}
