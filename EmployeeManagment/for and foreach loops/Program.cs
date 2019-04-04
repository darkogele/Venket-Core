using System;

namespace for_and_foreach_loops
{
    class Program
    {
        static void Main(string[] args)
        {         
            int[] Numbers = new int[] { 101, 102, 103 };

            var Numbers2 = new int[3];
            Numbers2[0] = 201;
            Numbers2[1] = 202;
            Numbers2[2] = 203;

            foreach (var broj in Numbers2)
            {
                Console.WriteLine(broj);
            }

            for (int i = 0; i < Numbers.Length; i++)
            {
                Console.WriteLine(Numbers[i]);
            }

            int b = 0;
            while (b < Numbers.Length)
            {
                Console.WriteLine(Numbers[b]);
                b++;
            }

            for (int i = 1; i <= 20; i++)
            {               
                //if (i == 10) break;    

                if (i % 2 == 1) continue;
                Console.WriteLine(i);
            }
        }
    }
}
