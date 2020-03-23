using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Console_GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            HandleData.Load();
            MainMenu();
        }

        public static int WinStreak;
        public static string WinStreakName;

        public static void MainMenu()
        {
            // variable to keep track of the current Item, and a simple counter.
            short CurrentItem = 0;

            ConsoleKeyInfo key;

            // Menu option Names
            string[] menuItems = { "New Game", "LeaderBoard", "Three", "Exit" };

            while(true)
            {
                Console.Clear();

                for (int c = 0; c < menuItems.Length; c++)
                {
                    // if the current item number is variable c, tab out this option.
                    if (CurrentItem == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(menuItems[c]);
                        Console.ResetColor();
                    } 
                    else // paints the other options
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }

                // Waits until the user presses a key, and puts it into an object key.
                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    CurrentItem++;
                    if (CurrentItem > menuItems.Length - 1)
                    {
                        CurrentItem = 0;
                    }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    CurrentItem--;
                    if (CurrentItem < 0)
                    {
                        CurrentItem = Convert.ToInt16(menuItems.Length - 1);
                    }
                } else if (key.Key.ToString() == "Enter")
                {
                    switch (CurrentItem.ToString())
                    {
                        case "0":
                            GuessGame();
                            break;
                        case "1":
                            LeaderBoard();
                            break;
                        case "2":

                            break;
                        case "3":
                            Environment.Exit(0);
                            break;
                    }
                }
            }

        }
        private static void GuessGame()
        {
            Random random = new Random();

            int num = random.Next(1, 11);

            int GuessCount = 3;

            int guess = 0;

            while (GuessCount >= 0)
            {
                Console.Clear();

                // Debug
                //Console.WriteLine(num);

                if( guess == num) {
                    WinStreak++;
                    Console.WriteLine("Guess Correct!");
                    GuessCount = GuessCount + 3;
                    num = random.Next(1, 11);
                } else if (GuessCount < 1) {
                    WinStreak = 0;
                    Console.WriteLine("you lose! play agian? (Y/N)");
                    Console.Write(": ");
                    string repeat = Console.ReadLine();

                    if (repeat == "Y" || repeat == "y")
                    {
                        // New game
                        GuessCount += 3;
                        num = random.Next(1, 11);
                    }
                    else if (repeat == "N" || repeat == "n")
                    {
                        // Saves current game to HighScore.json
                        Console.WriteLine("input name: ");
                        WinStreakName = Console.ReadLine();
                        HighScoreObject.Unit tempunit = new HighScoreObject.Unit(WinStreakName, WinStreak);
                        HandleData.DataBase.Add(tempunit);
                        HandleData.Commit();
                        break;
                    }
                    Console.Clear();
                }

                if (guess > num)
                {
                    Console.WriteLine("smaller.");
                }
                else if (guess < num)
                {
                    Console.WriteLine("bigger.");
                }
                Console.WriteLine("Current WinStreak: " + WinStreak);
                Console.WriteLine("Guesses Left: " + GuessCount);
                Console.Write("Guess Number: ");


                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                    GuessCount--;
                }
                catch
                {
                    Console.WriteLine("thats not a number!");
                }

            }
        }
        public static void LeaderBoard()
        {
            Console.Clear();
            Console.WriteLine("LeaderBoards: ");
            List<HighScoreObject.Unit> templistt = HandleData.DataBase;

            foreach (HighScoreObject.Unit U in templistt.ToList())
            {
                Console.WriteLine(U.Name + " / " + templistt.Max(u => u.Score));
                templistt.Remove(U);
            }
            Console.ReadKey();
        }

    }
}
