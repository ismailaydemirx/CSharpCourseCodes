using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void MyDelegate(); //bunu elçilik gibi düşünebiliriz, bu elçi void olan ve parametre almayan operasyonlara delegelik yapıyor.
    public delegate void MyDelegate2(string text); // parametre alan ve void olan bir delegate tanımladık.
    public delegate int MyDelegate3(int num1,int num2);
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage; // üstteki Elçilik'di bu oluşturduğumuz myDelegate ise özel bir elçi. Yani 1 delegate den 1 den fazla delege işleri yapan delegate'ler oluşturabiliriz.
            myDelegate += customerManager.ShowAlert; // burada mesela üstteki mesaja ek bir mesaj daha verdik + operatörü ile yani bir nevi birleştirdik

            myDelegate -= customerManager.SendMessage; // burada sendmessage operasyonunu geri aldık. belirli bir dönemde belki o fonksiyonu çalıştırmak istemeyebiliriz bu özellik sayesinde geri çektik.

            MyDelegate2 myDelegate2 = customerManager.SendMessage2; // aşağıda yeni bir sendmessage2 ctor'u oluşturduk
            myDelegate2 += customerManager.ShowAlert2;

            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            var sonuc = myDelegate3(2,4); 
            myDelegate3 += matematik.Topla; // return olduğu için sadece 1 değeri döndürüyor yani burada yaptığımız en son işlem hangisi ise onu alır mesaj birleştirme gibi bir işlem yapamadık burada.
            Console.WriteLine(sonuc);

            myDelegate2("Hello"); // şimdi burada bizden veri girmemizi istiyor. Yani burada aynı delegeyi 2 operasyon için gönderdik!
            
            
            myDelegate();// üstte delegate ile bilgiyi aldık burada da çalıştırdık gibi düşünebiliriz eğer buradaki fonksiyonu çağırmazsak delegate çalışmayacak sadece bilgiyi almış olacak.
            


            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be careful!");
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
