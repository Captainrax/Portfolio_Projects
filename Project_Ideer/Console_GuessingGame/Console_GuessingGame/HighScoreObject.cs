using System;
using System.Collections.Generic;
using System.Text;

namespace Console_GuessingGame
{
    class HighScoreObject
    {
        interface IHighScore
        {
            string Name { get; set; }
            int Score { get; set; }
        }
        public class Unit : IHighScore
        {
            public string Name { get; set; }
            public int Score { get; set; }

            // Constructor
            public Unit(String Name, int Score)
            {
                this.Name = Name;
                this.Score = Score;
            }
        }
    }
}
