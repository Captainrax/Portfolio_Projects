using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF_GUI
{
    // Interaction logic for MainWindow.xaml
    // WPF APP by Andreas Østgård
    // > basic CRUD functions.
    // > backgroundworker that uses savefile from %appdata% (see DAL.cs)

    public partial class MainWindow : Window
    {

        public static ObservableCollection<Unit> templist;
        DAL DAL_Object = new DAL();

        public MainWindow()
        {
            InitializeComponent();
            templist = DAL_Object.Get();
            contentContro1.DataContext = templist.FirstOrDefault();
            this.DataContext = templist;

            AutoUpdate();
        }

        // Create , Update , Delete

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            var selectedunit = (Unit)listView1.SelectedItem;
            DAL_Object.Delete(selectedunit);
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            DAL_Object.Get();
            // if List has no Unit , Create Temp Unit , this needs reworking(?)
            if ((Unit)contentContro1.Content == null)
            {
                Unit temp = new Unit("fuck", 2);
                temp.ClassName = "Default";
                 contentContro1.Content = temp;
            }
            // Creates new Object(Unit) from GUI information
            Unit displayunit = (Unit)contentContro1.Content;

            string Name = displayunit.Name;
            int Age = displayunit.Age;
            string ClassName = displayunit.ClassName;

            var Creation = new Unit(Name, Age)
            {
                Serial = GenerateSerial()
            };
            Creation.ClassName = ClassName;
            
            DAL_Object.Get().Add(Creation);
            DAL_Object.Commit();
        }
        public int GenerateSerial()
        {
            // returns 1 higher than current highest Serial Number
            int serialcount = 0;
            foreach (Unit H in DAL_Object.Get())
            {
                if (H.Serial >= serialcount)
                {
                    serialcount = H.Serial;
                }
            }
            return serialcount + 1;
        }
        // manual update method (probably dosnt need all 3 calls)
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DAL_Object.Get();
            DAL_Object.Commit();
        }
        
        // Backgroundworker that compares savefile and templist, updates templist if savefile has been modified
        private void AutoUpdate()
        {
            BackgroundWorker autoupdater = new BackgroundWorker();
            autoupdater.DoWork += Worker_DoWork;
            autoupdater.RunWorkerAsync(2000);

        }

        // Replace list if changes were made
        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int sleeptime = (int)e.Argument;

            while (true)
            {
                var comparelist = DAL_Object.Get();
                if (comparelist != templist)
                {
                    templist = comparelist;
                }
                Thread.Sleep(sleeptime);
            }
        }
    }
}
