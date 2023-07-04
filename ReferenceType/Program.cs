using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceTypeAndValueType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array'ler referans tiptir.

            int number1 = 10;
            int number2 = 20;
            number2 = number1;
            number1 = 30;

            Console.WriteLine(number2);

            string[] cities1 = new string[] { "Ankara", "Adana", "Afyon" };//101
            string[] cities2 = new string[] { "Bursa", "Bolu", "Balıkesir" };//102 -> 101 oluyor. 102 boşa düşüyor. GarbageCollector 102'yi kullanılmadığı içinn toplayıp atacak.
            cities2 = cities1;
            cities1[0] = "İstanbul";
            Console.WriteLine(cities1[0]);

            DataTable dataTable;
            DataTable dataTable1 = new DataTable();
            dataTable = dataTable1;

            Console.ReadLine();
        }
    }
}
