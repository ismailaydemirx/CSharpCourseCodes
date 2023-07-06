using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess
{
    //Aşağıdaki satır, "IEntityRepository" arabirimine bir sınıf kısıtlaması ekler.
    //Kısıtlama, "T" tür parametresinin bir sınıf olması gerektiğini ve aynı zamanda "IEntity" arabirimini uygulaması ve parametresiz bir yapıcı metodu olması gerektiğini belirtir.
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        // burada delegate yöntemi kullanarak filtre ifadesi aracılığıyla belirli koşullara uyan varlık listesini getirir.
        // Filtre parametresi, LINQ ifadeleri kullanılarak bir varlık üzerinde özelleştirlmiş bir filtre oluşturmanızı sağlar.
        // Varsayılan olarak filtre parametresi boş olabilir ve bu durumda tüm varlıkları getirecektir.
        List<T> GetList(Expression<Func<T,bool>>filter=null);


        // Filtre ifadesi aracılığıyla belirli bir koşula uyan TEK bir varlığı getirir.
        // Yine filtre parametresi kullanarak bir varlık üzerinde özelleştirilmiş bir filtre oluşturulabilir.
        // Varlık olarak, filtre parametresi boş olabilir ve bu durumda tüm varlıkları getirecektir.
        T Get(Expression<Func<T, bool>> filter = null); 
        
        T Add(T entity); // nesne EKLEME işlemi
        T Update(T entity); // nesne GÜNCELLEME işlemi
        void Delete(T entity); // nesne SİLME işlemi



    }
}
