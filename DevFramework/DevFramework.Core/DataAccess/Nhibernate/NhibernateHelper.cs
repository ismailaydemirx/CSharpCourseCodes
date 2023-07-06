using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevFramework.Core.DataAccess.Nhibernate
{
    public abstract class NhibernateHelper : IDisposable
    {

        private static ISessionFactory _sessionFactory;

        public virtual ISessionFactory SessionFactory { get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); } }

        protected abstract ISessionFactory InitializeFactory(); // Bu metodu abstract yapmamızın sebebi NhibernateHelper sınıfımızı implemente eden kişi kendi kodlarını yazacak.

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession(); // Kişi nasıl bir session gönderdiyse ona göre bir session açtırıyoruz burada.
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this); // Finalizasyon işleminin engellennmesini sağlıyor.
                                       // Finalizasyon bir nesnenin bellekten temizlenmesiyle ilgili bir süreçtir.
                                       // Bu süreçte nesnenin Finalize() yöntemi çağrılır ve bellekten kaldırılır.
        }
    }
}
