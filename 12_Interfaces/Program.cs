using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Demo();

            ICustomerDal[] customerDals = new ICustomerDal[3]
            {
                new SqlServerCustomerDal(),
                new OracleCustomerDal(),
                new MySqlCustomerDal()
        };

            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }

            Console.ReadLine();
        }

        private static void Demo()
        {
            // Bir interfaces hiçbir zaman new'lenemez. Çünkü tek başına bir anlamı yoktur.
            //InterfacesIntro();


            //IPerson person = new IPerson(); // Bir interfaces'in instance'si OLUŞTURULAMAZ. Soyut nesneler NEW'lenemez.

            IPerson person = new Customer(); // Customer ya da Student olarak newleyebiliriz.
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new OracleCustomerDal());

        }

        private static void InterfacesIntro()
        {
            PersonManager personManager = new PersonManager();
            Customer customer = new Customer()
            {
                id = 1,
                FirstName = "İsmail",
                LastName = "Aydemir",
                Address = "İstanbul"
            };

            Student student = new Student
            {
                id = 1,
                FirstName = "Yusuf",
                LastName = "Aydemir",
                Department = "Kuaför"
            };
            personManager.Add(student);
            personManager.Add(customer);
        }
    }
    // Interface'lerin temel kullanım amacı bir temel nesne oluşturup, bütün nesneleri ondan implemente etmektir.
    interface IPerson
    {
        int id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }

    class Customer : IPerson
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    class Student : IPerson
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }

    }

    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine("Welcome, " + person.FirstName);
        }
    }
}


// Neden interface'leri kullanıyoruz?
/* 
 

 
 */