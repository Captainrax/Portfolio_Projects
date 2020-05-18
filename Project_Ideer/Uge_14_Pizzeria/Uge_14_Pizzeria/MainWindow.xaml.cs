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
        public static bool DiscountApplied = false;
        public static string DiscountEffect = "";

        public MainWindow()
        {
            InitializeComponent();
            PizzaViewModel.checkOutList = new ObservableCollection<IFoodItem>();
            PizzaViewModel.totalOrderAmount = new int();

            PizzaViewModel.orderMenu = DATA.Get();

            // setting datacontexts (should move everything into 1 viewmodel an set bindings from that, would simplify things)
            this.DataContext = PizzaViewModel.orderMenu;
            TotalOrderPrice.DataContext = PizzaViewModel.totalOrderAmount;
            ListView2.DataContext = PizzaViewModel.checkOutList;


            // Discount tooltip
            TooltipInfo.Text = "Discount Code: \"FF\" (2 or more Pizzas and Drinks) \n Free Crust on the most expensive pizza";

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
                    new Ingredient() { Name = "Small", Price = 10, Type = "Size" },
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
                    new Ingredient() { Name = "Small", Price = 10, Type = "Size" },
                    new Ingredient() { Name = "Thick Crust", Price = 5, Type = "Foundation" },
                    new Ingredient() { Name = "Mozzarella", Price = 5, Type = "Cheese" },
                    new Ingredient() { Name = "Ham", Price = 5, Type = "Protein" },
                },
                Serial = GenerateSerial()
            };

            var Drink1 = new Drink("Coca Cola - 0.5L")
            {
                Price = new ObservableCollection<int>()
            };
            var Drink2 = new Drink("Coca Cola - 1L")
            {
                Price = new ObservableCollection<int>()
            };
            var Drink3 = new Drink("Coca Cola - 1.5L")
            {
                Price = new ObservableCollection<int>()
            };
            Drink1.Price.Add(15); // initialize variables
            Drink2.Price.Add(20);
            Drink3.Price.Add(25);

            PizzaViewModel.Update();

            PizzaViewModel.orderMenu.Add(pizza1);
            PizzaViewModel.orderMenu.Add(pizza2);
            PizzaViewModel.orderMenu.Add(pizza3);
            pizza1.Price.Add(0); // initialize variables
            pizza2.Price.Add(0);
            pizza3.Price.Add(0);
            PizzaViewModel.orderMenu.Add(Drink1);
            PizzaViewModel.orderMenu.Add(Drink2);
            PizzaViewModel.orderMenu.Add(Drink3);


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
                        temppizza.Price.Add(0);
                        foreach (Ingredient I in selectedunit.Ingredients) 
                        {
                            temppizza.Ingredients.Add(I);
                        }
                        temppizza.Price[0] = temppizza.UpdatePrice;

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

            UpdateDiscount(); // update discounts

            // Adds Drinks to checkOutList
            try
            {
                if (listView1.SelectedItem is Drink selectedunit)
                {
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
        public void UpdateDiscount()
        {
            // Handles Discounts
            foreach (IFoodItem I in PizzaViewModel.checkOutList)
            {
                if (I.DiscountApplied == true)
                {
                    I.LoadIngredients(); // loads old ingredients without the discount
                    I.DiscountApplied = false;

                    DiscountApplied = false;
                    DiscountEffect = "";
                    Discounts.Discount1(); // applies the discount agian
                }
            }
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
                if (DiscountEffect != "")
                {
                    MessageBox.Show(OrderInfo +"\n"+ OrderList + DiscountEffect + "\n" + "Total Price: " + totalprice.ToString() + " Kr.");
                } else
                {
                    MessageBox.Show(OrderList + "Total Price: " + totalprice.ToString() + " Kr.");
                }
                totalprice = 0;
                // Clears order
                DiscountApplied = false;
                DiscountEffect = "";
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
            UpdateDiscount(); // update discounts
        }

        // applies coupon deals
        private void BtnDiscount_Click(object sender, RoutedEventArgs e)
        {
            Discounts.Discount1();
            PizzaViewModel.Update();
        }
        // Clears checkOutList of items
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            //ListView2.Items.Clear();
            DiscountApplied = false;
            DiscountEffect = "";
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
        // theres probably a better way to do this with PropertyChanged?.
        public static void Update()
        {
            int totalprice = 0;
            foreach (IFoodItem U in checkOutList)
            {
                totalprice += U.GetPrice;
            }
            totalOrderAmount = totalprice;

            ((MainWindow)Application.Current.MainWindow).TotalOrderPrice.Content = totalOrderAmount;

            

            foreach (IFoodItem I in orderMenu)
            {
                I.Price[0] = I.GetPrice;
            }
        }
        
    }
}
