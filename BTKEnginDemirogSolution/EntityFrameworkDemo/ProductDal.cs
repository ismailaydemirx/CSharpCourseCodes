using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }
        }

        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product); // vertabanına veriyi ekledik.
                context.SaveChanges(); // şimdi de eklediğimiz veriyi kaydediyoruz.
            }
        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product); // burada entry ile context'e abone oluyoruz. Yani gelen product'a giriş yapıyoruz. Gönderdiğim product'ı vertabanındakiyle eşitliyor.
                entity.State = EntityState.Modified; // üstte id primary key olduğu için onunla direkt eşitledi ve burada da değiştirdik ve ekledik.
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product); // burada entry ile context'e abone oluyoruz. Yani gelen product'a giriş yapıyoruz. Gönderdiğim product'ı vertabanındakiyle eşitliyor.
                entity.State = EntityState.Deleted; // üstte id primary key olduğu için onunla direkt eşitledi ve burada da sildik.
                context.SaveChanges();
            }
        }

        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList(); // Veri tabanına where koşulunu burada atadık. Yalnız burada Products. dan sonra biz veritabanına sorguyu gönderdik yani veritabanına direkt sorgu gönderdik. SearchProducts(string key) metodunda ise veriyi aldık sonra sorguladık.Bu kullandığımız daha avantajlı çünkü sadece veritabanından ihtiyacımız olan datayı alıyoruz bu sayede tüm veriyi getirip içerisinde arama yapmıyoruz.
            }
        }

        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
            }
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice<=max).ToList();
            }
        }

        public List<Product> GetByID(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Products.Where(p=>p.Id==id).ToList();
                return result;
            }
        }
    }
}
