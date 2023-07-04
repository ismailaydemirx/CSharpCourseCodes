using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Intro();
            string sentence = "My name is Ismail Aydemir";

            var result = sentence.Length;
            var result2 = sentence.Clone();
            sentence = "She's name is Lütfiye";

            bool result3 = sentence.EndsWith("r");
            bool result4 = sentence.StartsWith("");

            var result5 = sentence.IndexOf("name"); // bulamazsa -1 döndürür. metin içerisinde ifade aramak için kullanılır.
            var result6 = sentence.IndexOf(" "); // burada boşluğu arattık. IndexOf bulduğu ilk yerin değerini döndürür.
            var result7 = sentence.LastIndexOf(" "); // aramaya sondan başlar.
            var result8 = sentence.Insert(0, "Hello, "); // burada 0 yazdığımız en başa Hello, yazdırdık
            var result9 = sentence.Substring(3,5); // burada 3. indexten sonra 5 tane karaktere kadar seçtik. Yani parça parça alabiliyoruz menti
            var result10 = sentence.ToLower();// harfleri küçültür
            var result11 = sentence.ToUpper();// harfleri BÜYÜTÜR.
            var result12 = sentence.Replace(" ", "_"); // boşluk yeirne alttan tire koyduk.
            var result13 = sentence.Remove(2,4); // 2. indexten itibaren 4 karakteri sildik            Console.WriteLine(result5);

            Console.WriteLine(result6);
            Console.WriteLine(result7);
            Console.WriteLine(result8);
            Console.WriteLine(result9);

            Console.WriteLine(result3);
            Console.WriteLine(result4);

            Console.WriteLine(result2);
            Console.ReadLine();
        }

        private static void Intro()
        {
            string city = "Istanbul"; // string olsa dahi char array olarak tutulur
            //Console.WriteLine(city[0]);
            foreach (var item in city)
            {
                Console.WriteLine(item);
            }
            string city2 = "Ankara";

            Console.WriteLine(String.Format("{0} {1}", city, city2));
        }
    }
}
