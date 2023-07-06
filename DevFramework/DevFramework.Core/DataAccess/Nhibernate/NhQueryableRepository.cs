using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.Nhibernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        // Session açabilmemiz için Nhibernate'e ihtiyacımız var.
        private NhibernateHelper _nhibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NhibernateHelper nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }
        public IQueryable<T> Table => this.Entities;

        public virtual IQueryable<T> Entities
        {
            get { return _entities ?? _nhibernateHelper.OpenSession().Query<T>(); }
        }
    }
}
