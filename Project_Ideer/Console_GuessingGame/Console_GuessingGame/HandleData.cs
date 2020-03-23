using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Console_GuessingGame
{
    class HandleData
    {
        public static List<HighScoreObject.Unit> DataBase = new List<HighScoreObject.Unit>();

        public static string filename = Path.Combine(Environment.CurrentDirectory, "HighScore.json");

        public static void Commit()
        {
            StreamWriter file = new StreamWriter(filename);

            string json = JsonConvert.SerializeObject(DataBase, Formatting.Indented);

            file.WriteLine(json);
            file.Close();
        }
        public static void Load()
        {
            if (!File.Exists(filename))
            {
                Commit();
            }

            string fileName = filename;

            string json = File.ReadAllText(fileName);

            List<HighScoreObject.Unit> templist = JsonConvert.DeserializeObject<List<HighScoreObject.Unit>>(json);

            foreach (HighScoreObject.Unit p in templist)
            {
                DataBase.Add(p);
            }
        }
    }
}
