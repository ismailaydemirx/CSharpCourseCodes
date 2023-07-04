using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Inheritance_Kalitim_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Interface 'e benziyor ancak interface'lerde interface tek başına bir anlam ifade etmezken burada class kullandığımız için class lar bir anlam ifade eder.
            // Inheritance'ın interface'den farkı sadece 1 kez inherit edilebilir yani 1 class'a 1 den fazla inherit olmaz. Ancak Interface de bu durum böyle değil 1 den fazla interface ekleyebiliriz.
            // Aynı anda hem inheritance hem interface ekleyebiliriz ÖNCELİKLE inheritance yazılır zaten 1 tane yazabiliyoruz ardından virgül ile ayırarak dilediğimiz kadar interface ekleyebiliriz.
            Person[] persons = new Person[3]
            {
                new Customer()
                {
                    FirstName="İsmail",
                },
                new Student()
                {
                    FirstName="Ersin",
                },
                new Person() // Burada inherit ettiğimiz class olmasına rağmen kullanabiliyoruz interface olsaydı kullanamazdık.
                {
                    FirstName="Yusuf",
                },
            };

            foreach (Person person in persons)
            {
                Console.WriteLine(person.FirstName);
            }

            Console.ReadLine();
        }
    }

    class Person
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    interface IPerson
    {
        // Interface tanımladık

    }

    class Customer : Person,IPerson // burada inheritance'dan sonra istediğimiz kadar INTERFACE ekleyebiliriz.
    {
        public string City { get; set; }

    }

    class Student : Person
    {
        public string Department { get; set; }
    }
}
