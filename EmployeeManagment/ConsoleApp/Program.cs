using System;

namespace ConsoleApp
{
    class Program
    {
        //static void Main(string[] args)  // SO GOTO
        //{
        //    int TotalCoffeCost = 0;
        //Start:
        //    Console.WriteLine("Select your Coffe size: 1 - small , 2 - Medium, 3 - Lage");
        //    _ = int.TryParse(Console.ReadLine(), out int UserChoice);
        //    switch (UserChoice)
        //    {
        //        case 1:
        //            TotalCoffeCost += 1;
        //            break;
        //        case 2:
        //            TotalCoffeCost += 2;
        //            break;
        //        case 3:
        //            TotalCoffeCost += 3;
        //            break;
        //        default:
        //            Console.WriteLine("Your Choice {0} is invalid ", UserChoice);
        //            goto Start;
        //    }
        //Decide:
        //    Console.WriteLine("Do you want to buy another coffe - yes or no");
        //    var UserDecision = Console.ReadLine();

        //    switch (UserDecision.ToLower())
        //    {
        //        case "yes":
        //            goto Start;
        //        case "no":
        //            break;
        //        default:
        //            Console.WriteLine("Invalid Choice {0}", UserDecision);
        //            goto Decide;
        //    }
        //    Console.WriteLine("Thank you for shooping with us");
        //    Console.WriteLine("Bill Amoun - {0}", TotalCoffeCost);
        //}


        static void Main(string[] args)
        {
            int TotalCoffeCost = 0;
            string UserDecision;
            int UserChoice;
            do
            {
                do
                {

                    Console.WriteLine("Select your Coffe size: 1 - small , 2 - Medium, 3 - Lage");
                    _ = int.TryParse(Console.ReadLine(), out UserChoice);
                    switch (UserChoice)
                    {
                        case 1:
                            TotalCoffeCost += 1;
                            break;
                        case 2:
                            TotalCoffeCost += 2;
                            break;
                        case 3:
                            TotalCoffeCost += 3;
                            break;
                        default:
                            Console.WriteLine("Your Choice {0} is invalid ", UserChoice);
                            break;

                    }
                } while (UserChoice != 1 && UserChoice != 2 && UserChoice != 3);

                do
                {
                    Console.WriteLine("Do you want to buy another coffe - yes or no");
                    UserDecision = Console.ReadLine().ToLower();
                    if (UserDecision != "yes" && UserDecision != "no")
                    {
                        Console.WriteLine("Your choice {0} is invalid. Please try again...", UserDecision);
                    }
                } while (UserDecision != "yes" && UserDecision != "no");
            } while (UserDecision == "yes");
           

            Console.WriteLine("Thank you for shooping with us");
            Console.WriteLine("Bill Amoun - {0}", TotalCoffeCost);
        }
    }
}
