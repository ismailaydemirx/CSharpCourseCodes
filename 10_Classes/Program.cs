using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
            customerManager.Update();

            ProductManager productManager = new ProductManager();
            productManager.Add();
            productManager.Update();

            Customer customer = new Customer();

            customer.Id = 1;
            customer.FirstName = "Ismail";
            customer.LastName = "Aydemir";
            customer.City = "Istanbul";

            Customer customer2 = new Customer
            {
                City = "Ankara",
                FirstName="Yusuf",
                LastName="Aydemir",
                Id=2
            };

            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();
        }
    }
}
