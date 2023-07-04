using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList();
            //List();
            Dictionary<string, string> dictionary = new Dictionary<string, string>(); // Sözlük mantığı. Anahtar ve değerin hangi türde olacağını belirtiyoruz
            dictionary.Add("book", "kitap");
            dictionary.Add("table", "tablo");
            dictionary.Add("computer","bilgisayar");

            //Console.WriteLine(dictionary["table"]);
            //Console.WriteLine(dictionary["cherry"]);

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            Console.WriteLine(dictionary.ContainsKey("glass"));
            Console.WriteLine(dictionary.ContainsKey("table"));


            Console.ReadLine();
        }

        private static void List()
        {
            List<string> cities = new List<string>();
            cities.Add("İstanbul");
            cities.Add("Ankara");

            Console.WriteLine(cities.Contains("Ankara")); // Şehirlerin içerisinde Ankara değeri varsa True döner yoksa False.

            foreach (string city in cities)
            {
                Console.WriteLine(city);
            }

            //List<Customer> customers = new List<Customer>();
            //customers.Add(new Customer { Id=1,FirstName="İsmail"});
            //customers.Add(new Customer { Id=2,FirstName="Aydemir"});

            List<Customer> customers = new List<Customer>
            {
                new Customer{Id=1,FirstName="İsmail" },
                new Customer{Id=2,FirstName="Aydemir" },
            };

            var customer1 = new Customer
            {
                Id = 3,
                FirstName = "Engin",
            };
            customers.Add(customer1);

            customers.AddRange(new Customer[2] // AddRange ile liste içerisine eklemek istediğimiz ayrı bir listeyi ekleyebiliriz.
            {
                new Customer {Id=5,FirstName="Mehmet"},
                new Customer{Id=6,FirstName="Zerrin" },
            });


            var index = customers.IndexOf(customer1);
            Console.WriteLine("Index: {0}", index);

            customers.Add(customer1);
            var index2 = customers.LastIndexOf(customer1);
            Console.WriteLine("Index: {0}", index2);

            customers.Insert(0, customer1);

            customers.Remove(customer1);
            customers.RemoveAll(a => a.FirstName == "İsmail"); // predict

            var count = customers.Count; // Listedeki elemanların sayısını bir değişkene atadık.

            //customers.Clear(); // Listedeki tüm elemanları uçurduk.
            Console.WriteLine("Count: {0}", count);

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
        }

        private static void ArrayList()
        {
            //En temel Collection oluşturma kodu.
            ArrayList Cities = new ArrayList();
            Cities.Add("İstanbul");
            Cities.Add("Ankara");
            Cities.Add("Mersin");
            Cities.Add("Kastamonu");
            Cities.Add(1); // Obje türü kabul ettiği için her veri tipini List'imize ekleyebiliriz.
            Cities.Add('A');

            foreach (var city in Cities)
            {
                Console.WriteLine(city);
            }
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
