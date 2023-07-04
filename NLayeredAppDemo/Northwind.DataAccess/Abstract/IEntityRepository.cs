using Northwind.Entities.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetProduct(Expression<Func<T, bool>> filter); // filter'i bilerek null bırakmadık çünkü eğer bir product'ı get edecekse mutlaka bir özelliğine göre get etmeli boş bir şeye göre get ederse tüm veriler anlamına gelir.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
