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
        public static ObservableCollection<IFoodItem> OrderMenu; // Left Panel
        public static ObservableCollection<Ingredient> IngredientsList = new ObservableCollection<Ingredient>(); // used by CustomPizza
        readonly HandleData DATA = new HandleData();

        public MainWindow()
        {
            PizzaViewModel.checkOutList = new ObservableCollection<IFoodItem>();
            InitializeComponent();
            OrderMenu = DATA.Get();

            TooltipInfo.Text = "Coupon Code: \"FF\" (2 or more Pizzas and Drinks) \n Free foundation on the first pizza in the list";

            // Manually adding fooditems and ingredients
            var Traditional = new Ingredient() { Name = "Traditional", Price = 5, Type = "Foundation" };
            var tomatoSauce = new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" };
            var Cheese = new Ingredient() { Name = "Cheese", Price = 5, Type = "Cheese" };
            var Ham = new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" };
            var Onion = new Ingredient() { Name = "Onion", Price = 5, Type = "Vegetable" };

            var SmallSize = new Ingredient() { Name = "Small", Price = 10, Type = "Size" };
            var MediumSize = new Ingredient() { Name = "Medium", Price = 15, Type = "Size" };
            var LargeSize = new Ingredient() { Name = "Large", Price = 20, Type = "Size" };
            //added to a list for use in the custompizza dialog window (and also for the future when its not being created in code)
            IngredientsList.Add(Traditional);
            IngredientsList.Add(tomatoSauce);
            IngredientsList.Add(Cheese);
            IngredientsList.Add(Ham);
            IngredientsList.Add(Onion);
            IngredientsList.Add(SmallSize);
            IngredientsList.Add(MediumSize);
            IngredientsList.Add(LargeSize);

            var pizza1 = new Pizza("Pizza4")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>() {SmallSize, Traditional, tomatoSauce, Cheese, Ham, Ham, Ham },
                Serial = 4
                
            };

            var pizza2 = new Pizza("Pizza5")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>() {LargeSize, Traditional, tomatoSauce, Cheese, Ham, Onion },
                Serial = 5
            };

            var pizza3 = new Pizza("Pizza6")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>() {MediumSize, Traditional, tomatoSauce, Ham },
                Serial = 6
            };

            var Drink1 = new Drink("Coca Cola - 0.5L")
            {
                Price = 15
            };
            var Drink2 = new Drink("Coca Cola - 1L")
            {
                Price = 20
            };
            var Drink3 = new Drink("Coca Cola - 1.5L")
            {
                Price = 25
            };

            OrderMenu.Add(pizza1);
            OrderMenu.Add(pizza2);
            OrderMenu.Add(pizza3);
            OrderMenu.Add(Drink1);
            OrderMenu.Add(Drink2);
            OrderMenu.Add(Drink3);

            // setting datacontexts
            this.DataContext = OrderMenu;
            ListView2.DataContext = PizzaViewModel.checkOutList;
        }
        // add selected item to checkout list
        private void BtnAddToCheckOut_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Adds selected pizza to checkOutList
                if (listView1.SelectedItem is Pizza selectedunit)
                {
                    try
                    {
                        var temppizza = new Pizza(selectedunit.Name)
                        {
                            Type = "Pizza",
                            Ingredients = new ObservableCollection<Ingredient>(),
                            Serial = GenerateSerial()
                        };
                        foreach(Ingredient I in selectedunit.Ingredients) 
                        {
                            temppizza.Ingredients.Add(I);
                        }

                        // added visually to the right panel(checkout)
                        ListView2.Items.Add(temppizza.Name + " - " + temppizza.GetIngredients + " - " + temppizza.GetPrice + "Kr");

                        // added to the checkOutList
                        PizzaViewModel.checkOutList.Add(temppizza);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.ToString());
                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            // Adds Drinks to checkOutList
            try
            {
                if (listView1.SelectedItem is Drink selectedunit)
                {
                    ListView2.Items.Add(selectedunit.Name + " - " + selectedunit.Price + "Kr");
                    PizzaViewModel.checkOutList.Add(selectedunit);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
        // not currently being used for anything, but i imagine giving objects unique ID's isnt a bad thing
        public static int GenerateSerial()
        {
            // returns 1 higher than current highest Serial Number
            int serialcount = 0;
            foreach (IFoodItem U in OrderMenu)
            {
                if (U.Serial >= serialcount)
                {
                    serialcount = U.Serial;
                }
            }
            foreach (IFoodItem U in PizzaViewModel.checkOutList)
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
                // gets prices, adds it to totalprice.
                int totalprice = 0;
                string pizzaList = "";
                foreach (IFoodItem U in PizzaViewModel.checkOutList)
                {
                    totalprice += U.GetPrice;
                    pizzaList += U.Name + " - " + U.GetPrice + "\n";
                }
                // Displays Final order
                MessageBox.Show(pizzaList + "Total Price: " + totalprice.ToString() + " Kr.");
                totalprice = 0;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        // custom pizza button, opens new dialog window
        private void BtnCustomPizza_Click(object sender, RoutedEventArgs e)
        {
            CustomPizza newcustompizza = new CustomPizza();
            newcustompizza.ShowDialog();
        }

        // applies coupon deals
        private void BtnCoupon_Click(object sender, RoutedEventArgs e)
        {
            if (CouponText.Text == "FF")
            {
                var pizzacount = 0;
                var drinkcount = 0;
                Pizza ComparePizza = new Pizza("ComparePizza");
                Drink CompareDrink = new Drink("CompareDrink");

                foreach (IFoodItem P in PizzaViewModel.checkOutList)
                {
                    if(P.GetType() == ComparePizza.GetType())
                    {
                        pizzacount++;
                    }
                }
                foreach (IFoodItem P in PizzaViewModel.checkOutList)
                {
                    if (P.GetType() == CompareDrink.GetType())
                    {
                        drinkcount++;
                    }
                }
                // Discount for 2 pizzas & 2 drinks, one pizza gets free Foundation

                // ToDo, currently changes all foundation ingredient costs to 0 for all pizzas, even outside list. only needs to change on the specific pizza
                // also changes all ingredient prices on custom pizza's which make no sense
                if (pizzacount >= 2 && drinkcount >= 2)
                {
                    foreach (IFoodItem P in PizzaViewModel.checkOutList)
                    {
                        if (P is Pizza)
                        {
                            var couponpizza = new Pizza(P.Name)
                            {
                                Type = "Pizza",
                                Ingredients = new ObservableCollection<Ingredient>(),
                                Serial = GenerateSerial()
                            };

                            foreach (Ingredient I in P.Ingredients)
                            {
                                couponpizza.Ingredients.Add(I);
                            }

                            foreach (Ingredient I in couponpizza.Ingredients)
                            {
                                if (I.Type == "Foundation")
                                {
                                    I.Price = 0;
                                }
                            }

                            PizzaViewModel.checkOutList.Remove(P);
                            PizzaViewModel.checkOutList.Add(couponpizza);

                            break;
                        }
                    }
                }
            }
        }
        // Clears checkOutList of items
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ListView2.Items.Clear();
            PizzaViewModel.checkOutList.Clear();
        }
    }

    //add the List to a viewmodel to get it to update when adding new fooditems
    public class PizzaViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<IFoodItem> checkOutList;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<IFoodItem> CheckOutList
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
            CheckOutList = new ObservableCollection<IFoodItem>();
        }
    }
}
