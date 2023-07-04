using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Add();
            //var result = AddMethod(22);
            //Console.WriteLine("Result: " + result);

            //int number1 = 20;
            //int number2 = 100;
            //var result2 = Add2(ref number1, number2); // number1 'i ref yani referans tipinde gönderdiğimiz için onun değeri de değişir
            //Console.WriteLine(result2);
            //Console.WriteLine(number1); // ref tipinde göndermeseydik number1 20 olacaktı ancak ref tipinde gönderdik değeri aşağıdaki fonksiyonda verdiğimiz değere eşit oldu.
            // ref = değer tipindeki bir değişkeni referans tipe çevirir.
            // Ref in bir diğer alternatifi ise 'OUT' keyword'u dur. Farkı ise. Ref yaptığımızda degiskenin mutlaka bir değeri olmalı. OUT da degisken değerini vermek zorunda değiliz. Out kullandığımız için Method içinde ise o değişkene bir değer vermeliyiz.

            Console.WriteLine(Multiply(2, 3, 5));

            Console.WriteLine(Add4(2,4,5,285,85,4,5,2,3,64,6,7,8,4,48,9,9,566,75,675));

            Console.ReadLine();
        }




        static void Add()
        {
            Console.WriteLine("Added!!!");
        }

        static int AddMethod(int number1, int number2 = 30) // Default paramatreyi gerçek hayat uygulamalarında KDV olarak düşünebiliriz. Değer göndermezse KDV %18 olsun gönderirse 8 veya 1 ya da istenilen değer.
        {
            Console.WriteLine("Numbers are calculating...");
            var result = number2 + number1;
            return result;
        }

        static int Add2(ref int number1, int number2)
        {
            number1 = 30;
            return number1 + number2;
        }

        static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        static int Multiply(int number1, int number2, int number3)
        {
            return number1 * number2 * number3;
        }

        static int Add4(params int[] numbers) // params keyword ile istediğimiz kadar sayı gönderebiliriz.
        {
            return numbers.Sum(); // Sum metodu ile tüm sayıları toplayıp return ile geri yolladık.
        }
    }
}
