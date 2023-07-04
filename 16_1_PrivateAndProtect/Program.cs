using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_1_AccessModifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    // Private bir değişken sadece tanımlandığı blok içerisinde geçerlidir.
    // Protected private gibi çalışır ANCAK inherit edildiği sınıflarda kullanabiliriz.

    class Customer
    {
        protected int Id { get; set; }
        public void Save()
        {
            int id;
        }

        public void Delete()
        {
            
        }
    }

    class Student : Customer
    {
        public void Save2()
        {
            Id = 1; 
            
        }
    }

    //İnternal bir class bağlı bulunduğu proje (assembly) içerisinde referans ihtiyacı olmadan kullanılabilir. Aynı proje içerisinde herhangi bir sıkıntı olmadan kullanabiliriz.
    internal class Course
    {
        public string Name { get; set; }

        private class NestedClass
        {

        }
    }

    //Public internal'ın bir üst seviyesidir, farklı bir proje üzerinden bu class'a erişilebilir anlamına gelir yani her yerden erişebiliriz bu class'a
    public class MyPublicClass
    {

    }

}
