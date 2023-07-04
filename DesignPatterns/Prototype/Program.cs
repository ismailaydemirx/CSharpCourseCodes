using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                FirsName = "ismail",
                LastName = "Aydemir",
                Id = 1,
            };
            Console.WriteLine(customer.FirsName);

            var customer2 = (Customer)customer.Clone();
            customer2.FirsName = "Mehmet";

            Console.WriteLine(customer.FirsName);
            Console.WriteLine(customer2.FirsName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone(); // Temel nesneyi prortotip haline getirebilmek için onun soyut bir clone methodundan besleniyor olması gerekir.
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();// customer'ı klonlamamızı sağlar

        }
    }
    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();// customer'ı klonlamamızı sağlar

        }
    }
}
