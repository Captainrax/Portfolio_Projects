using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection<Pizza> CheckOutList = new ObservableCollection<Pizza>();
        DAL DAL_Object = new DAL();

        public MainWindow()
        {
            InitializeComponent();
            templist = DAL_Object.Get();

            var tomatoSauce = new Ingredient() { Name = "TomatoSauce", Price = 5, Type = "Sauce" };
            var Cheese = new Ingredient() { Name = "Cheese", Price = 5, Type = "Cheese" };
            var Ham = new Ingredient() { Name = "Ham", Price = 5, Type = "Topping" };

            var pizza1 = new Pizza("Pizza4",true,false)
            {
                Price = 20,
                Ingredients = new ObservableCollection<Ingredient>(),
                Serial = GenerateSerial()
            };
            pizza1.Ingredients.Add(tomatoSauce);
            pizza1.Ingredients.Add(Cheese);
            pizza1.Ingredients.Add(Ham);
            pizza1.Ingredients.Add(Ham);
            pizza1.Ingredients.Add(Ham);
            pizza1.Ingredients.Add(Ham);

            templist.Add(pizza1);
            this.DataContext = templist;
            ListView2.DataContext = CheckOutList;
        }
        // add selected pizza to checkout list
        private void BtnAddToCheckOut_Click(object sender, RoutedEventArgs e)
        {
            var selectedunit = (Pizza)listView1.SelectedItem;

            try
            {

                string pizzasize = "";
                int price = selectedunit.Price;
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
                    price += 10;
                }
                string allingredients = "";
                try
                {
                    foreach (Ingredient I in selectedunit.Ingredients)
                    {
                        allingredients += I.Name + ", ";
                    }
                }
                catch (Exception)
                {
                }

                ListView2.Items.Add(selectedunit.PizzaName + " "  + " - " + pizzasize + " - " + allingredients +  " - " + price + "Kr");


                CheckOutList.Add(selectedunit);
            }
            catch (Exception)
            {

                //throw;
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

            // this is completety fucked.
            try
            {
                int totalprice = 0;
                foreach (Pizza U in CheckOutList)
                {
                    if(U.SizeLarge == true)
                    {
                        //totalprice += U.Price + 10;
                    } else if (U.SizeSmall == true)
                    {
                        //totalprice += U.Price;
                    }
                }
                MessageBox.Show("Total Price: " + totalprice.ToString() + " Kr.");
                totalprice = 0;
            }
            catch (Exception)
            {

                //throw;
            }
        }

    }
}
