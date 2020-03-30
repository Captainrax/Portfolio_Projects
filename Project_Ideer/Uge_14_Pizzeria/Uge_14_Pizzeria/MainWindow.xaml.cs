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
        DAL DAL_Object = new DAL();

        public MainWindow()
        {
            InitializeComponent();
            templist = DAL_Object.Get();
            this.DataContext = templist;
        }
        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            var selectedunit = (Unit)listView1.SelectedItem;
            MessageBox.Show(selectedunit.PizzaName + " - " + selectedunit.Price);
        }
    }
}
