using System;

namespace Console_GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int num = random.Next(1, 101);

            // Debug
            Console.WriteLine(num);
            Console.WriteLine(" ");

            int count = 0;

            while (true)
            {
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

                count++;

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

            }
            Console.WriteLine("you guessed " + count + " times!");
            Console.ReadKey();
        }
    }
}
