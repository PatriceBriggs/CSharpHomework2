using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework2.Models;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            FindHelloPassword(users);
            DeleteNamePassword(users);
            DeleteFirstHelloPassword(users);
            PrintRemainingUsers(users);

        }

        private static void PrintRemainingUsers(List<User> users)
        {
            Console.WriteLine("Remaining Users are:");
            var remainingUsers = from u in users
                                 select u;
            foreach (var r in remainingUsers)
            {
                Console.WriteLine("Name: " + r.Name + " Password: " + r.Password);
            }
            Console.ReadLine();
        }

        private static void DeleteFirstHelloPassword(List<User> users)
        {
            var firstHello = users.Where(u => u.Password == "hello").FirstOrDefault();
            if (firstHello != null)
            {
                Console.WriteLine("Deleting first hello password: " + firstHello.Name);
                users.Remove(firstHello);
            }
            else
            {
               // no hellos
               Console.WriteLine("No users have with 'hello' password.");

            }
        }

        private static void DeleteNamePassword(List<User> users)
        {
            users.RemoveAll(u => u.Name.ToLower() == u.Password);           
        }

        private static void FindHelloPassword(List<User> users)
        {          
            var helloPassword = from u in users
                                where u.Password == "hello"
                                select u;
            if (helloPassword == null)
            {   // no hellos
                Console.WriteLine("No users have with 'hello' password.");
 
            }
            else
            {   // print hellos
                foreach (var h in helloPassword)
                {
                    Console.WriteLine("User: " + h.Name + " Password: " + h.Password);
                }
            }

        }

            
    }
}
