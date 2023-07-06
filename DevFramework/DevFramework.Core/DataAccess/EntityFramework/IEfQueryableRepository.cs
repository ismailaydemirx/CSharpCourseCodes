using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class IEfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;
        public IEfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        //public IQueryable<T> Table
        //{
        //    get
        //    {
        //        return _entities;
        //    }
        //}
        // alttaki kod bu kodun daha kapalı versiyonu

        public IQueryable<T> Table => this.Entities; // yukarıdaki kod bu kodun daha açık versiyonu.

        protected virtual IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }
    }

}
