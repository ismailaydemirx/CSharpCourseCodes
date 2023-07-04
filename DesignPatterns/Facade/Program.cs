using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged.");
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached.");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked.");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Validate : IValidate
    {
        public void ValidateUser()
        {
            Console.WriteLine("User Validated");
        }
    }

    interface IValidate
    {
        void ValidateUser();
    }

    
    class CustomerManager
    {
        private CrossCuttonConcernsFacade _cuttonConcernsFacade;
        public CustomerManager()
        {
            _cuttonConcernsFacade = new CrossCuttonConcernsFacade();
        }

        public void Save()
        {
            _cuttonConcernsFacade.Logging.Log();
            _cuttonConcernsFacade.Caching.Cache();
            _cuttonConcernsFacade.Authorize.CheckUser();
            _cuttonConcernsFacade.Validate.ValidateUser();
            Console.WriteLine("Saved.");
        }
    }

    class CrossCuttonConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validate;

        public CrossCuttonConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();  
            Validate = new Validate();
        }
    }
}
