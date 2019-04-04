using System;

namespace WhileLoop
{
    class Program
    {
        static void Main()
        {
            string UserChoice;
            do
            {
                Console.WriteLine("Please enter your target?");
                int UserTarget = int.Parse(Console.ReadLine());

                int Start = 0;

                while (Start <= UserTarget)
                {
                    Console.Write(Start + " ");
                    Start += 2;
                }
                do
                {
                    Console.WriteLine("Do you want to continue - Yes or No?");

                    UserChoice = Console.ReadLine().ToLower();

                    if (UserChoice != "yes" && UserChoice != "no")
                    {
                        Console.WriteLine("Invalid Choice, please say Yes or No");
                    }
                }
                while (UserChoice != "yes" && UserChoice != "no");
            } while (UserChoice == "yes");
        }
    }
}
