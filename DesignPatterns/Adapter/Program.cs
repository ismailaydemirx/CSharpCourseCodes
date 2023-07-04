using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        ILogger _logger; 
        public ProductManager(ILogger logger) // Dependency Injection. ILogger bağımlılığımızı belirledik. Gevşek bir bağımlılık değiştirebiliriz.
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User data.");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}",message);
        }
    }

    // Nuget'den indirdiğimizi varsayıyoruz.
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net, {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        private Log4Net _log4Net;

        public void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net, {0}",message);
        }
    }
}
