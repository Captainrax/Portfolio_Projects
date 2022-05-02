using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_UI
{
    // Starts backgroundworker thread that looks at %appdata% savefile for changes, updates current list if changes are made
    class AutoUpdater
    {
        public static List<IInterface> templist = new List<IInterface>();
        public static void AutoUpdate()
        {
            BackgroundWorker autoupdater = new BackgroundWorker();
            autoupdater.DoWork += Worker_DoWork;
            autoupdater.RunWorkerAsync(2000);

        }

        // Compares lists
        static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int sleeptime = (int)e.Argument;

            while (true)
            {
                var comparelist = Load();
                if (comparelist != templist)
                {
                    templist = comparelist;
                }
                Thread.Sleep(sleeptime);
            }
        }

        public static string SaveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SAVEDATA");
        public static string savedata = "SaveData.JSON";

        public static DateTime lastModified;
        public static List<IInterface> Load()
        {

            string fileName = SaveFolder + "\\" + savedata;
            string json = File.ReadAllText(fileName);

            if (lastModified == null || File.GetLastWriteTime(fileName) > lastModified)
            {
                templist.Clear();
                // load savefile into templist, then load templist into people
                List<Unit> tempList = JsonConvert.DeserializeObject<List<Unit>> (json);
                try
                {
                    foreach (var unit in tempList)
                    {
                        templist.Add(unit);
                    }
                }
                catch
                {
                    Console.WriteLine("File is Empty - Creating New List for Unit Objects");
                }

                List<IInterface> realList = new List<IInterface>();
                foreach(var unit in tempList)
                {
                    realList.Add(unit);
                }
                lastModified = File.GetLastWriteTime(fileName);
                return realList;
            }
            return HandleData.people;
        }
    }
}
