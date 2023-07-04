using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Her şeyi ÇALIŞMA ANINDA YAPMAYA ÇALIŞMA! Ufak da olsa performans kaybı yaşanabilir. Reflection gerçekten ihtiyaç olduğu durumlarda kullanılmalıdır.
            //DortIslem dortIslem = new DortIslem(2,4);
            //Console.WriteLine(dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(3, 4));

            var tip = typeof(DortIslem);
            //                    cast işlemi yaptık 
            //DortIslem dortIslem = (DortIslem)Activator.CreateInstance(tip,6,7); // Çalışma anında oluşturduk. bu eşittir = DortIslem dortIslem = new DortIslem(2,4); yani bunu yaparak new işlemini yaptık
            //Console.WriteLine(dortIslem.Topla(3, 5));
            //Console.WriteLine(dortIslem.Topla2());

            var instance = Activator.CreateInstance(tip,7,3);

            MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");
            Console.WriteLine(methodInfo.Invoke(instance, null)); ; // GetMethod ile istediğimiz metoda ulaşabiliriz, Invoke ile de o metodu çalıştırabiliriz.
            // instance'ye şöyle diyebiliriz, Hangi örneğin "Topla2"sini çalıştırayım sorusunun cevabını veriyor aslında.

            Console.WriteLine("-------");
            var metodlar = tip.GetMethods();
            foreach (var info in metodlar)
            {
                Console.WriteLine("Method Info: {0}", info.Name);
                foreach (var parameters in info.GetParameters())
                {
                    Console.WriteLine("Parametre: {0}", parameters);
                }
                foreach (var atribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name: {0}", atribute);
                }
            }

            Console.ReadLine();
        }
    }

    class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1,int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public DortIslem()
        {
            
        }
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
        [MethodName("Çarpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }


    }

    class MethodNameAttribute:Attribute
    {
        public MethodNameAttribute(string name)
        {
            
        }
    }
}
