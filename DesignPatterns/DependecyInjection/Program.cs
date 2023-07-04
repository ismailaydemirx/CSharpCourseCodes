using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependecyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IOC Container önemli konu araştır.
            ProductManager productManager = new ProductManager(new NhProductDal()); // MVC'de bunu daha iyi yapıyoruz. bağımlılığı minimuma indiriyoruz burada istediğimiz dal ile çalışacağımızı belirtiyoruz.
            productManager.Save();

            Console.ReadLine();
        }
    }



    interface IProductDal
    {
        void Save();
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef.");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh.");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal) // Productmanager'ın Constructor'ına IProductDal'ı istiyoruz bu sayede yeni ekleyeceğimiz Dal(Data Access Layer)'ı da rahatlıkla kullanabiliriz. bağımlılığı kaldırdık.
        {
            _productDal = productDal;
        }
        public void Save()
        {
            //Business Code
            // ProductDal producDal = new ProductDal(); // YASAKK! şu anda bunu yaptığımız için ProductDal'a bağımlıyız ve bu durumu biz istemiyoruz.
            _productDal.Save();
        }
    }
}
