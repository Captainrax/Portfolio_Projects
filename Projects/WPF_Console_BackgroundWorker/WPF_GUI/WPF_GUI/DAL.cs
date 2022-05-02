using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace WPF_GUI
{
    public class DAL
    {
        private ObservableCollection<Unit> DataBase; // Da vi ikke har adgang til en database, 
                                                       // simulerer vi med denne private liste....

        private ObservableCollection<Unit> _publicListe; // Dette er objektet med elementer vi 
                                                         // "deler ud" til brugeren af vores class.


        public static string SaveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SAVEDATA");
        public static string savedata = "SaveData.JSON";
        public DAL()
        {
            _publicListe = new ObservableCollection<Unit>();
        }

        DateTime lastModified;
        // Get henter data fra databasen og kopierer det over i den lokale kopi
        public ObservableCollection<Unit> Get()
        {
            string fileName = SaveFolder + "\\" + savedata;

            if (lastModified == null || File.GetLastWriteTime(fileName) > lastModified)
            { 
                // assumes the folder already exists...
                string json = File.ReadAllText(fileName);
                DataBase = JsonConvert.DeserializeObject<ObservableCollection<Unit>>(json);

                App.Current.Dispatcher.Invoke((Action)delegate
                {

                    _publicListe.Clear(); //Først tømmes den lokale kopi

                });

                //løber alle elementerne igennem i databasen og overfører til lokal kopi
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    foreach (Unit p in DataBase)
                    {
                        _publicListe.Add(p);
                    }
                });

                lastModified = File.GetLastWriteTime(fileName);
                return _publicListe;
            }
            return MainWindow.templist;
        }
        // Commit indsætter vores lokale kopi af data, i databasen
        public void Commit()
        {
            DataBase = new ObservableCollection<Unit>(_publicListe);

            StreamWriter file = new StreamWriter(SaveFolder + "/" + savedata);

            string json = JsonConvert.SerializeObject(DataBase, Formatting.Indented);

            file.WriteLine(json);
            file.Close();
        }

        // Delete sletter et object fra _publicliste (tager et object som parameter)
        public int Delete(Unit Unit_Object)
        {
            int returnvalue = 0;

            for (int i = _publicListe.Count - 1; i >= 0; i--)
            {
                try {
                    if (_publicListe[i].Serial == Unit_Object.Serial)
                    {
                        _publicListe.RemoveAt(i);
                        returnvalue++;
                    }
                } catch {
                    
                }
            }
            Commit();
            return returnvalue;
        }
    }
}
