using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_For_Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Veri kümesini dolaşmak için döngüler kullanılır.

            // Girilen bir sayının asal olup olmadığını bulma
            int num = -1;
            while (num!=0)
            {
                Console.WriteLine();
                Console.WriteLine("Asal Sayı Hesaplama Uygulamasına Hoş Geldiniz!");
                Console.WriteLine("Çıkış için '0' yazabilirsiniz.");
                Console.WriteLine();
                Console.Write("Bir Sayı Girin: ");
                num = int.Parse(Console.ReadLine());
                if (num == 0)
                {
                    Console.WriteLine("Uygulamadan çıktınız iyi günler!");
                }
                else if (IsPrimeNumber(num))
                {
                    Console.WriteLine("Girdiğiniz: " + num + " sayısı asal bir sayıdır.");
                }
                else
                {
                    Console.WriteLine("Girdiğiniz: " + num + " sayısı asal bir sayı değildir.");
                }
               
            }
            
            Console.ReadLine();


        }

        private static bool IsPrimeNumber(int number)
        {
            bool result = true;

            for ( int i = 2; i< number-1; i++ )
            {
                if (number % i == 0)
                {
                    result = false;
                    i = number;
                }
            }
            return result;
        }

        /*
           string[] myList = new string[3] { "ismail","aydemir","ktü"};

           foreach(string lst in myList)
           {
               Console.Write(lst+" ");
           }
           */

        /*
        int num2 = 100;

        do
        {
            Console.WriteLine(num2);
            num2--;
        }while(num2 > 0);
        */


        /*
        int number = 100;
        while (number >= 0)
        {
            Console.WriteLine(number);
            number--;
        }
        */


        /*
        for (int i = 0; i <= 100; i++)
        {
            Console.WriteLine(i);
        }
        */
    }
}
