using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Deserialize
{
    class Program
    {
        static void Main(string[] args)
        {
            //string json = @"{'Email': 'james@example.com','Active': true,'CreatedDate': '2013-01-20T00:00:00Z','Roles': ['User','Admin']}";
            string json2 = @"{'Email':null,'Active': true,'CreatedDate': '2013-01-20T00:00:00Z','Roles': ['User','Admin']}";
            var Account = JsonConvert.DeserializeObject<Account>(json2);
            Console.WriteLine(Account.Email);
            Console.Read();
        }

        public class Account
        {
            public Account()
            {
                Email = "";
            }
         
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public IList<string> Roles { get; set; }
        }
    }
}
