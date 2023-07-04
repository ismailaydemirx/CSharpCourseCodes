using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExceptionIntro();
            //TryCatch();
            // Method
            //ActionDemo();

            //Console.WriteLine(Topla(2,4));

            Func<int, int, int> add = Topla;//parametrelerimiz sırasıyla; parametre, parametre, çıktı:  1. ve 2. siz şu an bizim Topla(int x,int y) metodumuz için yapacağımızdan 1. ve 2. ler tipler 3. sü de geri dönüş değeri
            Console.WriteLine(add(3,5)); // yukarıda delege olduğu için Topla'yı metod olarak çağırmadık FUNC<> olan add'e atadık burada da add e metod atandığı için topla yerine ona değerler gönderdik.

            Func<int> getRandomNumber = delegate ()// böyle bir func görürsek, parametresiz metodlara delege yapıyor olarak anlayabiliriz.
            {
                Random random = new Random();
                return random.Next(1,100);
            };

            
            Func<int> getRandomNumber2=()=>new Random().Next(1,100); // burada da lamda kullanarak func tanımladık.

            Console.WriteLine(getRandomNumber());
            Thread.Sleep(1000); // 1 saniyelik durdurma işlemi.
            Console.WriteLine(getRandomNumber2());
            Console.ReadLine();
        }

        static int Topla(int x, int y)
        {
            return x + y;
        }


        private static void ActionDemo()
        {
            HandleException(() => // () ben parametresiz bir kod göndereceğim "=>" O kod bloğunun karşılığı da "{}"buradaki kod kümesi
            {
                Find();
            });
        }

        private static void TryCatch()
        {
            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void HandleException(Action action) // action da biz bir kod bloğu gönderiyoruz ve Invoke diyerek o kod bloğunu çalıştırıyoruz.
        {
            try
            {
                action.Invoke(); // gönderdiğimiz parametreyi çalıştırıyoruz yani biz yukarıda Find(); göndermiştik Invoke etmek çalıştırmak oluyor.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> { "engin", "derin", "salih" };

            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFoundException("Record not found.");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

        private static void ExceptionIntro()
        {
            // Try catch de önce try içerisindeki kodu dener hata verirse catch kısmına geçer.
            try
            {
                string[] students = new string[3]
                {
                        "ismail",
                        "engin",
                        "derin",
                };

                students[3] = "Ahmet";
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException); // InnerException daha fazla hata hakkında daha fazla detay verir.
                Console.WriteLine(ex.Message);
            }
        }
    }
}
