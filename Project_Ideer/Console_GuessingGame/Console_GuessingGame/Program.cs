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
            string[] menuItems = { "New Game", "LeaderBoard", "Tutorial", "Exit" };

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

                // Select menu
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
                            Tutorial();
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
            // numbers to guess between ( both numbers get -1 )
            int num = random.Next(1, 11);
            // number of guesses the player gets at the start
            int GuessCount = 3;
            // current guess
            int guess = 0;
            // game loop
            while (GuessCount >= 0)
            {
                bool nomore = false;
                Console.Clear();

                // Debug
                //Console.WriteLine(num);

                // checks if game is over ie. 0 guesses left
                if( guess == num) {
                    // Guessed correct, +3 guesses, new guess number 0 / 10
                    WinStreak++;
                    Console.WriteLine("Guess Correct!");
                    GuessCount = GuessCount + 3;
                    num = random.Next(1, 11);
                } else if (GuessCount < 1) {
                    // bool for making sure the player presses Y/n or N/n
                    bool c = true;
                    while (c == true)
                    {
                        Console.WriteLine("you lose! play agian? (Y/N)");
                        Console.Write(": ");

                        string repeat = Console.ReadLine();

                        if (repeat == "Y" || repeat == "y")
                        {
                            // New game
                            GuessCount += 3;
                            num = random.Next(1, 11);
                            guess = 0;
                            WinStreak = 0;
                            c = false;
                        }
                        else if (repeat == "N" || repeat == "n")
                        {
                            // Saves current game to HighScore.json
                            if (WinStreak >= 1)
                            {
                                Console.WriteLine("input name: ");
                                WinStreakName = Console.ReadLine();
                                if (WinStreakName.Count() >= 1)
                                {
                                    HighScoreObject.Unit tempunit = new HighScoreObject.Unit(WinStreakName, WinStreak);
                                    HandleData.DataBase.Add(tempunit);
                                    HandleData.Commit();
                                }
                            }
                            // resets game
                            guess = 0;
                            WinStreak = 0;
                            c = false;
                            nomore = true;
                        }
                        Console.Clear();
                    }
                    // breaks out of the game if you typed "N / n"
                    if (nomore == true)
                    {
                        break;
                    }
                }
                if(guess != 0)
                {
                    if (guess > num)
                    {
                        Console.WriteLine("The number is smaller.");
                    }
                    else if (guess < num)
                    {
                        Console.WriteLine("the number is bigger.");
                    }
                }

                Console.WriteLine("Current WinStreak: " + WinStreak);
                Console.WriteLine("Guesses Left: " + GuessCount);
                Console.Write("Guess Number: ");

                // takes player guess
                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                    if(guess < 0 || guess > 10)
                    {

                    } else
                    {
                        GuessCount--;
                    }
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
            // copies current list into templist, just incase i was gonna remove anything
            List<HighScoreObject.Unit> templist = HandleData.DataBase.ToList();
            int counter = 1;

            foreach (HighScoreObject.Unit U in templist.OrderByDescending(unit => unit.Score))
            {
                Console.Write(counter + " - ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(U.Name);
                Console.ResetColor();
                Console.Write(" / " + U.Score);
                Console.WriteLine("");
                //templist.Remove(U);
                counter++;
            }
            Console.ReadKey();
            Console.ResetColor();
        }
        public static void Tutorial()
        {
            Console.Clear();
            Console.WriteLine("Guess a number between 0 / 10.");
            Console.WriteLine("Guessing correctly rewards you with 3 more guesses.");
            Console.Write("Once you run out of guesses you can input your");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" name ");
            Console.ResetColor();
            Console.Write("to be entered unto the leaderboard.");
            Console.WriteLine("");
            Console.WriteLine("if you enter nothing you will not be entered.");
            Console.ReadKey();
        }

    }
}
