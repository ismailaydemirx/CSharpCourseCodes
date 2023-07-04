using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    // class lar ve abstract sınıflar da generic olabilir. Bir güzel kullanım da generic leri bir method yani fonksiyon için de kullanabiliriz.
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "izmir", "Adana");
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }

            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirstName = "İsmail" }, new Customer { FirstName = "Ersin" });
            foreach (var s in result2)
            {
                Console.WriteLine(s.FirstName);
            }


            Console.ReadLine();
        }
        class Utilities
        {
            public List<T> BuildList<T>(params T[] items)
            {
                return new List<T>(items);
            }
        }
    }
    class Product : IEntity
    {

    }
    interface IProductDal : IRepository<Product>
    {

    }

    class Customer : IEntity
    {
        public string FirstName { get; set; }
    }

    interface ICustomerDal : IRepository<Customer>
    {

    }

    interface IStudentDal : IRepository<Student>
    {

    }
    class Student : IEntity
    {

    }
    interface IEntity
    {

    }
    interface IRepository<T> where T : class, IEntity, new()
        /*
            SADECE DEĞER TİPLERİNİ KOYMAK İSTESEYDİK. "where T : struct" yapabiliriz. struct DEĞER tiplere karşılık gelir.
            where T : class, IEntity, new() -> bu şöyle okunur: class referans tipinde olmalı, IEntity ondan implemente edilmeli ve new'lenebilir olmalı
            "new" ifadesi her zaman generic sınıf veya arabirim tanımının en sonuna konulmalıdır.
            IEntity isimli bir arabirim oluşturduk ve diğer sınıflara da bu arabirimleri ekledik. Böylece, bir nesne bu arabirimden türetilmiş olmalıdır.
            Buradaki "class" ifadesi, bir referans tipi olduğunu belirtir. Yani, bu generic yapının sadece sınıf türlerini kabul ettiğini gösterir. Başka bir deyişle, değer türleri (value types) kabul edilmez.
            Virgül ve "new()" ifadesi ise, generic yapının sadece new'lenebilir (instance alınabilir) türleri kabul ettiğini belirtir. Yani, bu türlerin bir yapıcı metodu (constructor) olmalıdır.
            "T" ise generic yapının kendisiyle belirtilen türe göre işlemler gerçekleştireceği temel türü temsil eder. Bunu generic yapılar sayesinde kolaylıkla yapabiliriz.
         */
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

    class ProductDal : IProductDal //"Bu şekilde, ProductDal sınıfı, IProductDal arabirimini uygulayarak, Product tipine özgü operasyonları gerçekleştirebilmektedir. Örneğin, void Custom(); gibi özel bir operasyonu yarın öbür gün CustomerDal sınıfı için eklemek istediğimizde, IProductDal arabirimini değiştirmek zorunda kalmadan CustomerDal sınıfına özel operasyonları ekleyebiliriz. Bu sayede, her bir varlık için farklı işlemleri destekleyen ayrı ayrı sınıflar oluşturarak kodumuzu daha esnek ve genişletilebilir hale getirebiliriz."
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }

    class CustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
