using Constructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Constructor, bir sınıf NEW'lendiğinde çalışacak bir kod bloğudur.
            CustomerManager manager = new CustomerManager(); //parantez açıp kapatmamız o sınıfın parametresiz bir şekilde contrustor'ın çalışması anlamına gelir.
            manager.Add();
            manager.List();

            Product product = new Product { Id = 1, Name = "Laptop" };
            Product product1 = new Product();
            Product product2 = new Product(12, "Bilgisayar");

            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();

            PersonManager personManager = new PersonManager("Product");
            personManager.Add();

            Teacher.Number = 10;

            Utilities.Validate();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        //örneğin sayfalama işlemi yapacağız burada 2 tana constructor tanımladık, sayı verilirse verilen sayı kadar verilmezse 15 olacak kadar sayfalama yapmak için.
        private int _count = 15; // private bir field method değilse "_"alt çizgi kullanılarak tanımlanır.
        public CustomerManager(int count)
        {
            _count = count;
        }

        public CustomerManager()
        {

        }
        public void List()
        {
            Console.WriteLine("Listed {0} items.", _count);
        }
        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }

    class Product
    {
        public Product()
        {

        }
        private int _id;
        private string _name;
        public Product(int id, string name)
        {
            _id = id;

            _name = name;

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to Database!");
        }
    }

    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to File!");
        }
    }

    class EmployeeManager
    {
        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {

            _logger = logger;

        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added!");
        }
    }

    class BaseClass
    {
        private string _entity;
        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} message", _entity);
        }
    }
    class PersonManager : BaseClass
    {
        public PersonManager(string entity):base(entity)
        {
            
        }
        public void Add()
        {
            Console.WriteLine("Added!");
            Message();
        }
    }
    //Static nesne ne demek? Static nesnelerin instance'sini oluşturamayız. Sınıfı yani aşağıdaki NEW'leyemeyiz.
    // Static de arka tarafta bir nesne oluşuyor ve herkes tarafndan kullanılıyor bu yüzden newlenemez.
    //Static nesneler ortak nesnelerdir. Herkesin ortak kullanacağı, biri değişince herkeste değişen değişkenler istiyorsak kullanabiliriz.
    static class Teacher
    {
        public static int Number { get; set; }
    }

    static class Utilities
    {
        static Utilities()
        {
            
        }
        public static void Validate()
        {
            Console.WriteLine("Validation is done.");
        }
    }

    //Class'ı statik yapmayıp metodları static yapabiliriz. Ne anlama geliyor?
    //static olarak tanımladığımız metodu instance kullanmadan çağırabiliriz.
    //Static direkt sınıf üzerinden çağırılırken static olmayan instance üzerinden çağırılır.
    class Manager
    {
        public static void DoSomething()
        {
            Console.WriteLine("Done");
        }

        public void DoSometgin2()
        {
            Console.WriteLine("Done 2");
        }
    }
    
}



