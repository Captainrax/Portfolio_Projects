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
        readonly HandleData DATA = new HandleData();
        // only 1 coupon can be applied at once
        public bool CouponApplied = false;
        public string CouponEffect = "";

        public MainWindow()
        {
            PizzaViewModel.checkOutList = new ObservableCollection<IFoodItem>();
            PizzaViewModel.totalOrderAmount = new int();
            InitializeComponent();
            OrderMenu = DATA.Get();

            // setting datacontexts
            this.DataContext = OrderMenu;

            // fix it (might work, if not set databinding in xaml to textinfo with the window resource datacontext thing an then bind that )
            TotalOrderPrice.DataContext = PizzaViewModel.totalOrderAmount;

            ListView2.DataContext = PizzaViewModel.checkOutList;
            // coupon tooltip
            TooltipInfo.Text = "Coupon Code: \"FF\" (2 or more Pizzas and Drinks) \n Free foundation on the first pizza in the list";

            var pizza1 = new Pizza("Pizza4")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>() 
                {
                    new Ingredient() { Name = "Small", Price = 10, Type = "Size" },
                    new Ingredient() { Name = "Traditional", Price = 5, Type = "Foundation" },
                    new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" },
                    new Ingredient() { Name = "Cheese", Price = 5, Type = "Cheese" },
                    new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" }, 
                },
                Serial = GenerateSerial()
            };

            var pizza2 = new Pizza("Pizza5")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>()
                {
                    new Ingredient() { Name = "Medium", Price = 10, Type = "Size" },
                    new Ingredient() { Name = "Traditional", Price = 5, Type = "Foundation" },
                    new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" },
                    new Ingredient() { Name = "Cheese", Price = 5, Type = "Cheese" },
                    new Ingredient() { Name = "Onion", Price = 5, Type = "Vegetable" },
                    new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" },
                },
                Serial = GenerateSerial()
            };

            var pizza3 = new Pizza("Pizza6")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>()
                {
                    new Ingredient() { Name = "Large", Price = 10, Type = "Size" },
                    new Ingredient() { Name = "Traditional", Price = 5, Type = "Foundation" },
                    new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" },
                    new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" },
                },
                Serial = GenerateSerial()
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

        }
        // add selected item to checkout list
        private void BtnAddToCheckOut_Click(object sender, RoutedEventArgs e)
        {
            // Adds selected pizza to checkOutList
            try
            {
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
            // updates totalorderamount
            PizzaViewModel.Update();
        }

        public static int GenerateSerial()
        {
            // returns 1 higher than current highest Serial Number(checks left panel and right panel)
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
                string OrderList = "";
                foreach (IFoodItem U in PizzaViewModel.checkOutList)
                {
                    totalprice += U.GetPrice;
                    OrderList += U.Name + " - " + U.GetPrice + "\n";
                }
                // Displays Final order
                if (CouponEffect != "")
                {
                    MessageBox.Show(OrderList + CouponEffect + "\n" + "Total Price: " + totalprice.ToString() + " Kr.");
                } else
                {
                    MessageBox.Show(OrderList + "Total Price: " + totalprice.ToString() + " Kr.");
                }
                totalprice = 0;
                // Clears order
                CouponApplied = false;
                CouponEffect = "";
                ListView2.Items.Clear();
                PizzaViewModel.checkOutList.Clear();

                PizzaViewModel.Update();
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

            PizzaViewModel.Update();
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

                if (pizzacount >= 2 && drinkcount >= 2 && CouponApplied == false)
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

                            foreach (Ingredient I in P.Ingredients.ToList())
                            {
                                couponpizza.Ingredients.Add(I);
                            }
                            PizzaViewModel.checkOutList.Remove(P);
                            // replace old ingredient with a new instance of the same with new price
                            foreach (Ingredient I in couponpizza.Ingredients)
                            {
                                if (I.Type == "Foundation")
                                {
                                    couponpizza.Ingredients.Remove(I);

                                    var TempTraditional = new Ingredient() { Name = "Traditional", Price = 0, Type = "Foundation" };

                                    couponpizza.Ingredients.Add(TempTraditional);
                                    break;
                                }
                            }

                            PizzaViewModel.checkOutList.Add(couponpizza);
                            PizzaViewModel.Update();
                            CouponApplied = true;
                            CouponEffect += "1 Free Foundation -5 kr.";
                            ListView2.Items.Add(CouponEffect);

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
            PizzaViewModel.Update();
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
        // constructor
        public PizzaViewModel()
        {
            CheckOutList = new ObservableCollection<IFoodItem>();
        }

        public static int totalOrderAmount;
        // runs when BtnAddToCheckOut_Click is pressed
        public static void Update()
        {
            int totalprice = 0;
            foreach (IFoodItem U in PizzaViewModel.checkOutList)
            {
                totalprice += U.GetPrice;
            }
            totalOrderAmount = totalprice;

            ((MainWindow)Application.Current.MainWindow).TotalOrderPrice.Content = totalOrderAmount;
        }
    }

}
