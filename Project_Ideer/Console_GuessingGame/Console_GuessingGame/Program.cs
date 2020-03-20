using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static int WinStreak;

        public static void MainMenu()
        {
            // variable to keep track of the current Item, and a simple counter.
            short curItem = 0, c;

            ConsoleKeyInfo key;

            string[] menuItems = { "New Game", "Two", "Three", "Exit" };

            while(true)
            {
                Console.Clear();

                for (c = 0; c < menuItems.Length; c++)
                {
                    // if the current item number is variable c, tab out this option.
                    if (curItem == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
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
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                } else if (key.Key.ToString() == "Enter")
                {
                    switch (curItem.ToString())
                    {
                        case "0":
                            GuessGame();
                            break;
                        case "1":

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

            int num = random.Next(1, 101);

            int GuessCount = 3;

            while (GuessCount > 0)
            {
                Console.Clear();

                // Debug
                //Console.WriteLine(num);

                Console.WriteLine("Guesses Left: " + GuessCount);
                Console.Write("Guess Number: ");

                int guess = 0;

                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                    GuessCount--;
                }
                catch
                {
                    Console.WriteLine("thats not a number!");
                }

                if (GuessCount < 3)
                {
                    if (guess > num)
                    {
                        Console.WriteLine("smaller.");
                    }
                    else if (guess < num)
                    {
                        Console.WriteLine("bigger.");
                    }
                    else
                    {
                        Console.WriteLine("you win!");
                        WinStreak++;
                        break;
                    }

                }

                if (GuessCount < 1)
                {
                    Console.WriteLine("you lost!");
                    break;
                }
            }
            Console.ReadKey();
        }


    }
}
