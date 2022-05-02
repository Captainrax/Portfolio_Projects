using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Console_UI
{
    // creates a savefile in appdata/Roaming/SAVEDATA/SaveData.json
    public class Program
    {
        static void Main(string[] args)
        {
            AutoUpdater.AutoUpdate();
            HandleData.Load();

            Start.Menu();
        }
    }               

    class Start
    {
        public static void Menu()
        {
            Idfk.Dostuff();
            bool runloop = true;

            while (runloop)
            {
                Console.WriteLine("Construct new Unit: new");
                Console.WriteLine("Remove Unit: remove");
                Console.WriteLine("Rename Unit: rename");
                Console.WriteLine("Enter new Age: changeage");
                Console.WriteLine("Show all Unit: list");
                Console.WriteLine("Exit: exit");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "new":
                        Controller.AddUnit();
                        break;

                    case "remove":
                        Controller.RemoveUnit();
                        break;

                    case "rename":
                        Controller.Rename();
                        break;

                    case "changeage":
                        Controller.Changeage();
                        break;

                    case "list":
                        Controller.ListUnits();
                        break;

                    case "exit":
                        runloop = false;
                        break;

                    default:
                        Console.Clear();
                        break;
                }
                Console.Clear();
            }
        }

    }

    class Controller
    {
        public static void AddUnit()
        {
            Console.WriteLine("Enter name");
            String Name = Console.ReadLine();
            Console.WriteLine("Enter age");

            try
            {
                Int16 Age = Convert.ToInt16(Console.ReadLine());
                var Creation = new Unit(Name, Age)
                {
                    Serial = GenerateSerial()
                };

                Console.WriteLine("Pick Class");

                Console.WriteLine("Human: 1 - HP: " + Idfk.HumanHP);
                Console.WriteLine("Dragon: 2 - HP: " + Idfk.DragonHP);

                bool pickclassbool = true;
                while (pickclassbool == true)
                {
                    byte Pick = 0;
                    try {
                        Pick = byte.Parse(Console.ReadLine());
                    } catch {
                        Console.WriteLine("invalid input");
                    }
                    switch (Pick)
                    {
                        case 1:
                            Creation.ClassName = "Human";
                            pickclassbool = false;
                            break;

                        case 2:
                            Creation.ClassName = "Dragon";
                            pickclassbool = false;
                            break;
                        default:
                            pickclassbool = true;
                            break;
                    }
                }

                HandleData.people.Add(Creation);
                HandleData.Save();
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                Console.ReadKey();
            }

        }

        public static int GenerateSerial()
        {
            // returns 1 higher than current highest Serial Number
            int serialcount = 0;
            foreach (Unit H in HandleData.people)
            {
                if (H.Serial >= serialcount)
                {
                    serialcount = H.Serial;
                }
            }
            return serialcount + 1;
        }

        public static void RemoveUnit()
        {
            for (var i = 1; i <= HandleData.people.Count; i++)
            {
                Console.WriteLine((i-1) + ". " + HandleData.people[i-1].Name + " " + HandleData.people[i-1].Age + " |Serial:" + HandleData.people[i-1].Serial + " |Class:" + HandleData.people[i-1].ClassName);
            }
            Console.WriteLine("Which Unit would you like to Remove?");
            Console.Write("> ");

            try {
                int pick = int.Parse(Console.ReadLine());
                HandleData.people.Remove(HandleData.people[pick]);
            } catch {
                Console.WriteLine("not a valid Unit");
            }
            HandleData.Save();
        }
        
        public static void Rename()
        {
            for (int i = 1; i <= HandleData.people.Count; i++)
            {
                Console.WriteLine((i - 1) + ". " + HandleData.people[i - 1].Name + " " + HandleData.people[i - 1].Age);
            }
            Console.WriteLine("PICK ONE - " + HandleData.people.Count);
            Console.Write("> ");

            try {
                int pick = int.Parse(Console.ReadLine());
                Console.WriteLine("Change Name: ");
                string setname = Console.ReadLine();
                HandleData.people[pick].Name = setname;
                Console.WriteLine("Name changed to " + setname + ".");
                Console.ReadKey();
            } catch {
                Console.WriteLine("Not a valid Unit");
                Console.ReadKey();
            }
            HandleData.Save();
        }

        public static void Changeage()
        {
            // ill make this one eventually, its basicly the rename method but with int.
            Console.WriteLine("Coming soon!");
            Console.ReadKey();
        }
        // shows a list of all units in the current list, lets you select a unit to see all stats
        public static void ListUnits()
        {
            Console.Clear();
            Console.WriteLine("================");
            foreach (Unit H in HandleData.people)
            {
                Thread.Sleep(50);
                Console.WriteLine("ID:" + H.Serial + " " + H.Name + " " + H.Age + " " + " Class: " + H.ClassName);
            }
            Console.Write("> ");

            byte Pick = 0;
            try {
                Pick = Convert.ToByte(Console.ReadLine());
            } catch {

            }
           
            bool doesexist = true;
            foreach (Unit H in HandleData.people)
            {
                if (Pick == H.Serial)
                {
                    Console.WriteLine("ID: " + H.Serial);
                    Console.Write("Class: " + H.ClassName);

                    // display Class HP values
                    if( H.ClassName == "Human") {
                        Console.WriteLine(" HP: " + Idfk.HumanHP);
                    } else if (H.ClassName == "Dragon") {
                        Console.WriteLine(" HP: " + Idfk.DragonHP);
                    } else { // just incase the ClassName is not a pre-existing unit type (formating)
                        Console.WriteLine("");
                    }

                    Console.WriteLine("Name: " + H.Name);
                    Console.WriteLine("Age: " + H.Age);
                    doesexist = true;
                    break;
                }
                else if (H.Serial != Pick)
                {
                    doesexist = false;
                }
            }
            if (doesexist == false)
            {
                Console.WriteLine("ID does not exist");
            }

            Console.ReadKey();
        }
    }

    class HandleData
    {
        public static List<IInterface> people = new List<IInterface>();
        public static string SaveFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SAVEDATA");
        public static string savedata = "SaveData.JSON";
        // saves JSON to %APPDATA%  
        public static void Save()
        {
            Directory.CreateDirectory(SaveFolder);

            StreamWriter file = new StreamWriter(SaveFolder + "/" + savedata);

            string json = JsonConvert.SerializeObject(people, Formatting.Indented);

            file.WriteLine(json);
            file.Close();
        }
        // Loads JSON from %APPDATA%       
        public static void Load()
        {
            string fileName = SaveFolder + "\\" + savedata;
            string json = "";
            // check if savefile exists else create new
            if(File.Exists(fileName))
            {
                json = File.ReadAllText(fileName);
            } else {
                Save();
            }
            // load savefile into templist, then load templist into people
            List<Unit> tempList = JsonConvert.DeserializeObject<List<Unit>>(json);
            try
            {
                foreach (var unit in tempList)
                {
                    people.Add(unit);
                }
            }
            catch
            {
                Console.WriteLine("File is Empty - Creating New List for Unit Objects");
            }
        }
    }


    // this is just here to make use of delegate.......
    class Idfk
    {
        public delegate int Print(int value);

        public static int HumanHP;  // 100
        public static int DragonHP; // 600

        public static void Dostuff()
        {
            Print DisplayHP = DisplayHumanHP;
            
            HumanHP = DisplayHP(100);

            DisplayHP = DisplayDragonHP;

            DragonHP = DisplayHP(600);
            
        }

        public static int DisplayHumanHP(int HumanHealth)
        {
            return HumanHealth;
        }
        public static int DisplayDragonHP(int DragonHealth)
        {
            return DragonHealth;
        }
    }
}