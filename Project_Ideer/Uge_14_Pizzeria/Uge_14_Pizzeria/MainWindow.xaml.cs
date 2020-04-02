using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uge_14_Pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Pizza> templist;
        public static ObservableCollection<Ingredient> IngredientsList = new ObservableCollection<Ingredient>();

        DAL DAL_Object = new DAL();

        public MainWindow()
        {
            PizzaViewModel.checkOutList = new ObservableCollection<Pizza>();
            InitializeComponent();
            templist = DAL_Object.Get();

            var Traditional = new Ingredient() { Name = "Traditional", Price = 5, Type = "Foundation" };
            var tomatoSauce = new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" };
            var Cheese = new Ingredient() { Name = "Cheese", Price = 5, Type = "Cheese" };
            var Ham = new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" };
            var Onion = new Ingredient() { Name = "Onion", Price = 5, Type = "Vegetable" };

            var SmallSize = new Ingredient() { Name = "Small", Price = 10, Type = "Size" };
            var LargeSize = new Ingredient() { Name = "Large", Price = 20, Type = "Size" };
            IngredientsList.Add(Traditional);
            IngredientsList.Add(tomatoSauce);
            IngredientsList.Add(Cheese);
            IngredientsList.Add(Ham);
            IngredientsList.Add(Onion);
            IngredientsList.Add(SmallSize);
            IngredientsList.Add(LargeSize);

            var pizza1 = new Pizza("Pizza4",true,false)
            {
                Ingredients = new ObservableCollection<Ingredient>(),
                Serial = GenerateSerial()
            };
            var pizza2 = new Pizza("Pizza5", true, false)
            {
                Ingredients = new ObservableCollection<Ingredient>(),
                Serial = GenerateSerial()
            };
            pizza1.Ingredients.Add(Traditional);
            pizza1.Ingredients.Add(tomatoSauce);
            pizza1.Ingredients.Add(Cheese);
            pizza1.Ingredients.Add(Ham);
            pizza1.Ingredients.Add(Ham);
            pizza1.Ingredients.Add(Ham);
            pizza2.Ingredients.Add(Traditional);
            pizza2.Ingredients.Add(tomatoSauce);
            pizza2.Ingredients.Add(Cheese);
            pizza2.Ingredients.Add(Ham);
            pizza2.Ingredients.Add(Onion);

            templist.Add(pizza1);
            templist.Add(pizza2);
            this.DataContext = templist;
            ListView2.DataContext = PizzaViewModel.checkOutList;
        }
        // add selected pizza to checkout list
        private void BtnAddToCheckOut_Click(object sender, RoutedEventArgs e)
        {
            var selectedunit = (Pizza)listView1.SelectedItem;

            try
            {

                string pizzasize = "";
                int price = selectedunit.GetPrice();
                if(DataTemplates.SizeSmall == true)
                {
                    pizzasize = "Small";
                    selectedunit.SizeLarge = false;
                    selectedunit.SizeSmall = true;
                } else if (DataTemplates.SizeLarge == true)
                {
                    pizzasize = "Large";
                    selectedunit.SizeSmall = false;
                    selectedunit.SizeLarge = true;
                }
                string allingredients = "";
                try
                {
                    foreach (Ingredient I in selectedunit.Ingredients)
                    {
                        allingredients += I.Name + ", ";
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.ToString());
                }

                ListView2.Items.Add(selectedunit.PizzaName + " "  + " - " + pizzasize + " - " + allingredients +  " - " + price + "Kr");


                PizzaViewModel.checkOutList.Add(selectedunit);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
        public int GenerateSerial()
        {
            // returns 1 higher than current highest Serial Number
            int serialcount = 0;
            foreach (Pizza U in templist)
            {
                if (U.Serial >= serialcount)
                {
                    serialcount = U.Serial;
                }
            }
            return serialcount + 1;
        }
        // display total price of checkout List
        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // gets all ingredient prices, adds it to totalprice.
                int totalprice = 0;
                string pizzaList = "";
                foreach (Pizza U in PizzaViewModel.checkOutList)
                {
                    totalprice += U.GetPrice();
                    pizzaList += U.PizzaName + " - " + U.GetPrice() + "\n";
                }
                
                MessageBox.Show(pizzaList + "Total Price: " + totalprice.ToString() + " Kr.");
                totalprice = 0;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
        private void BtnCustomPizza_Click(object sender, RoutedEventArgs e)
        {
            // ToDo add the pizza to the checkout list
            CustomPizza newcustompizza = new CustomPizza();
            newcustompizza.ShowDialog();
        }
    }
    // tried adding the List to a viewmodel to get it to update when adding new pizza from custompizza, not working currently

    //public static ObservableCollection<Pizza> CheckOutList = new ObservableCollection<Pizza>();
    public class PizzaViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<Pizza> checkOutList;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Pizza> CheckOutList
        {
            get { return checkOutList; }
            set
            {
                checkOutList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CheckOutList"));
            }
        }

        public PizzaViewModel()
        {
            CheckOutList = new ObservableCollection<Pizza>();
        }
    }
}
