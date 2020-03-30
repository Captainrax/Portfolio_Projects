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
        public static ObservableCollection<Unit> templist;
        public static ObservableCollection<Unit> CheckOutList = new ObservableCollection<Unit>();
        DAL DAL_Object = new DAL();

        public MainWindow()
        {
            InitializeComponent();
            templist = DAL_Object.Get();
            this.DataContext = templist;
            ListView2.DataContext = CheckOutList;
        }
        private void BtnAddToCheckOut_Click(object sender, RoutedEventArgs e)
        {
            var selectedunit = (Unit)listView1.SelectedItem;

            try
            {

                string pizzasize = "";
                int pizzaprice = selectedunit.Price;
                if(DataTemplates.SizeSmall == true)
                {
                    pizzasize = "Small";
                    selectedunit.SizeSmall = true;
                } else if (DataTemplates.SizeLarge == true)
                {
                    pizzasize = "Large";
                    pizzaprice += 10;
                    selectedunit.SizeLarge = true;
                }


                ListView2.Items.Add(selectedunit.PizzaName + " " + selectedunit.Ingredients + " - " + pizzasize + " - " + pizzaprice + "Kr");





                CheckOutList.Add(selectedunit);
            }
            catch (Exception)
            {

                //throw;
            }
        }
        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            //var selectedunit = (Unit)listView1.SelectedItem;
            int totalprice = 0;

            try
            {
                foreach(Unit U in CheckOutList)
                {
                    if(U.SizeLarge == true)
                    {
                        totalprice += U.Price + 10;
                    } else if (U.SizeSmall == true)
                    {
                        totalprice += U.Price;
                    }
                }
                MessageBox.Show("Total Price: " + totalprice.ToString() + " Kr.");
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}
