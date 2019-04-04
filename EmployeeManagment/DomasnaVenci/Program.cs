using System;
using System.Collections.Generic;
using System.Linq;

namespace DomasnaVenci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many persons are in the collection !");

            var numberOfUsers = Convert.ToInt32(Console.ReadLine());

            var kolekcija = new List<User>();

            for (int i = 0; i < numberOfUsers; i++)
            {
                Console.WriteLine("Enter the user Data");
                var newUser = new User();
                Console.WriteLine("Enter the user Name");

                newUser.Name = Console.ReadLine();
                Console.WriteLine("Enter the Suername");

                newUser.Surname = Console.ReadLine();
                Console.WriteLine("Enter the Age");
                newUser.Age = int.Parse(Console.ReadLine());
                kolekcija.Add(newUser);
            }
            var max = 0;
            string korisnik = string.Empty; 
            foreach (var user in kolekcija) // da go najde najgolemiot broj
            {
                if (user.Name.Length > max)
                {
                    max = user.Name.Length;
                    korisnik = user.Name;
                }
            }

            //var longestString = kolekcija.Where(x => x.Name.Length > max); // so ling 
            var longestString2 = kolekcija.OrderByDescending(x => x.Name.Length).FirstOrDefault(); //so ling druga verzija

            Console.WriteLine("Longest Name is" + longestString2.Name);
            Console.WriteLine("Longest Name is " + korisnik);
            Console.Read();
        }
    }

    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
