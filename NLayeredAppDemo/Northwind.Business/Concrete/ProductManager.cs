using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Abstract;
using Northwind.Business.Abstract;
using System.Data.Entity.Infrastructure;
using Northwind.Business.Concrete.ValidationRules.FluentValidation;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Northwind.Business.Utilities;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        //EfProductDal _productDal = new EfProductDal(); //Dependency oluşur.
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(),product);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {

            try
            {
                _productDal.Delete(product);
            }
            catch
            {
                throw new Exception("Silme işlemi gerçekleşemedi."); // bu yoğurma işini asla arayüzde vermemeliyiz. Eğer verirsek bu durum SOLID'e karşı bir durum olur.
            }
        }

        public List<Product> GetAll()
        {
            // Business code. Bir kişi datayı çekmek istiyor ama bu data o kişinin görebileceği bir data mı? Veya onun görebileceği bir data mı? Bunu kontrol etmek gerekir
            return _productDal.GetAll();

        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower())); // ToLower key sensitivite'yi kullanmayı unutma buna dikkat et.
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }
    }
}
