using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Database dataa = new Database(); // Database'ler new 'LENEMEZ!
            Database[] database = new Database[2]
            {
                new SqlServer(),
                new Oracle()
            };

            foreach (var data in database)
            {
                data.Add();
                data.Delete();
            }

            Console.ReadLine();
        }
    }

    abstract class Database
    {
        // Abstract Class dediğimiz aslında içi dolu olmayan virtual methodu gibi düşünebiliriz.
        public void Add() // Tamamlanmış method..
        {
            Console.WriteLine("Added by default");
        }

        public abstract void Delete(); // Tamamlanmamış method.
    }

    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Sql");
        }
    }

    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Oracle");
        }
    }
}

