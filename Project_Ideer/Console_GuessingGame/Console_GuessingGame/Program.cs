using System;

namespace Console_GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessGame();
        }

        private static void GuessGame()
        {
            Random random = new Random();

            int num = random.Next(1, 101);

            int count = 3;

            while (count > 0)
            {
                Console.Clear();

                // Debug
                //Console.WriteLine(num);

                Console.WriteLine("Guesses Left: " + count);
                Console.Write("Guess Number: ");
                int guess = 0;

                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("thats not a number!");
                }

                count--;

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
                    break;
                }

                if (count < 1)
                {
                    Console.WriteLine("you lost!");
                }
            }
            Console.ReadKey();
        }


    }
}
