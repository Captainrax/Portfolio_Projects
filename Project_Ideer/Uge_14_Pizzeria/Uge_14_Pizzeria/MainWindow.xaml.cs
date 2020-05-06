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
        readonly HandleData DATA = new HandleData();
        // only 1 coupon can be applied at once
        public bool CouponApplied = false;
        public string CouponEffect = "";

        public MainWindow()
        {
            PizzaViewModel.checkOutList = new ObservableCollection<IFoodItem>();
            PizzaViewModel.totalOrderAmount = new int();

            InitializeComponent();
            PizzaViewModel.orderMenu = DATA.Get();

            // setting datacontexts (should move everything into 1 viewmodel an set bindings from that, would simplify things)
            this.DataContext = PizzaViewModel.orderMenu;
            TotalOrderPrice.DataContext = PizzaViewModel.totalOrderAmount;
            ListView2.DataContext = PizzaViewModel.checkOutList;
            // coupon tooltip
            TooltipInfo.Text = "Coupon Code: \"FF\" (2 or more Pizzas and Drinks) \n Free Crust on the most expensive pizza";

            var pizza1 = new Pizza("Pepperoni Pizza")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>() 
                {
                    new Ingredient() { Name = "Small", Price = 10, Type = "Size" },
                    new Ingredient() { Name = "Thin Crust", Price = 5, Type = "Foundation" },
                    new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" },
                    new Ingredient() { Name = "Pepperoni", Price = 5, Type = "Protein" }, 
                },
                Serial = GenerateSerial()
            };

            var pizza2 = new Pizza("Hawaiian pizza")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>()
                {
                    new Ingredient() { Name = "Medium", Price = 15, Type = "Size" },
                    new Ingredient() { Name = "Thin Crust", Price = 5, Type = "Foundation" },
                    new Ingredient() { Name = "Mozzarella", Price = 5, Type = "Cheese" },
                    new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" },
                    new Ingredient() { Name = "Pineapple", Price = 5, Type = "Vegetable" },
                },
                Serial = GenerateSerial()
            };

            var pizza3 = new Pizza("Calzone Pizza")
            {
                Type = "Pizza",
                Ingredients = new ObservableCollection<Ingredient>()
                {
                    new Ingredient() { Name = "Large", Price = 20, Type = "Size" },
                    new Ingredient() { Name = "Thick Crust", Price = 5, Type = "Foundation" },
                    new Ingredient() { Name = "Mozzarella", Price = 5, Type = "Cheese" },
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

            PizzaViewModel.orderMenu.Add(pizza1);
            PizzaViewModel.orderMenu.Add(pizza2);
            PizzaViewModel.orderMenu.Add(pizza3);
            PizzaViewModel.orderMenu.Add(Drink1);
            PizzaViewModel.orderMenu.Add(Drink2);
            PizzaViewModel.orderMenu.Add(Drink3);
            pizza1.Price = pizza1.GetPrice;
            pizza2.Price = pizza2.GetPrice;
            pizza3.Price = pizza3.GetPrice;
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
                        temppizza.Price = temppizza.UpdatePrice;

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
                    //ListView2.Items.Add(selectedunit.Name + " - " + selectedunit.Price + "Kr");
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
            foreach (IFoodItem U in PizzaViewModel.orderMenu)
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
                string OrderInfo = "CheckOut";
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
                    MessageBox.Show(OrderInfo +"\n"+ OrderList + CouponEffect + "\n" + "Total Price: " + totalprice.ToString() + " Kr.");
                } else
                {
                    MessageBox.Show(OrderList + "Total Price: " + totalprice.ToString() + " Kr.");
                }
                totalprice = 0;
                // Clears order
                CouponApplied = false;
                CouponEffect = "";
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
                    IFoodItem TempPizza = new Pizza("Error")
                    {
                        Type = "Pizza",
                        Ingredients = new ObservableCollection<Ingredient>(),
                        Serial = GenerateSerial()
                    };
                    foreach (IFoodItem P in PizzaViewModel.checkOutList) // find the most expensive pizza an replace it with TempPizza
                    {
                        if (P is Pizza)
                        {
                            if (P.GetPrice > TempPizza.GetPrice)
                            {
                                TempPizza = P;
                                TempPizza.Name = P.Name;
                            }

                            //MessageBox.Show(TempPizza.GetPrice.ToString() + TempPizza.Name);

                            //ToDo add couponeffect to list
                            //PizzaViewModel.checkOutList.Add(CouponEffect);
                        }
                    }
                    string PreviousFoundationName = "";
                    foreach (Ingredient I in TempPizza.Ingredients) // remove old ingredient, saves name
                    {
                        if (I.Type == "Foundation")
                        {
                            PreviousFoundationName = I.Name;
                            TempPizza.Ingredients.Remove(I);
                            break;
                        }
                    }

                    Ingredient tempfoundation = new Ingredient() { Name = PreviousFoundationName, Price = 0, Type = "Foundation" };
                    TempPizza.Ingredients.Add(tempfoundation);
                    PizzaViewModel.Update();

                    CouponApplied = true;
                    CouponEffect += "1 Free Foundation -5 kr.";
                }
            }
        }
        // Clears checkOutList of items
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            //ListView2.Items.Clear();
            CouponApplied = false;
            CouponEffect = "";
            PizzaViewModel.checkOutList.Clear();
            PizzaViewModel.Update();
        }
    }

    //added the List to a viewmodel to get it to update when adding new fooditems
    public class PizzaViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<IFoodItem> checkOutList;

        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<IFoodItem> orderMenu; // Left Panel

        public ObservableCollection<IFoodItem> OrderMenu
        {
            get { return orderMenu; }
            set
            {
                orderMenu = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OrderMenu"));
            }
        }
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
            OrderMenu = new ObservableCollection<IFoodItem>();
        }

        public static int totalOrderAmount;
        // run it when making changes that you want to update (numbers n stuff)
        public static void Update()
        {
            int totalprice = 0;
            foreach (IFoodItem U in checkOutList)
            {
                totalprice += U.GetPrice;
            }
            totalOrderAmount = totalprice;

            ((MainWindow)Application.Current.MainWindow).TotalOrderPrice.Content = totalOrderAmount;
        }
    }

}
