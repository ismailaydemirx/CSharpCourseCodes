using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                Id = 1,
                LastName = "Aydemir",
                Age = 23
            };

            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);

            Console.ReadLine();
        }
    }

    [ToTable("Customers")]
    [ToTable("tblCustomers")]
    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }

    }

    class CustomerDal
    {
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!"
                ,customer.Id,customer.FirstName,customer.LastName,customer.Age);
        }
        [Obsolete("Don't use Add instead use AddNew method")] // hazır bir attribute 
        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!"
                , customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

    }

    [AttributeUsage(AttributeTargets.Property)]
    class RequiredPropertyAttribute:Attribute // Attribute'lerin sonuna "Attribute" kelimesi eklenir ve Attribute sınıfı inherit edilir.
    {

    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class ToTableAttribute:Attribute
    {
        private string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }

}
