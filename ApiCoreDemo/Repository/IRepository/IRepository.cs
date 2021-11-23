using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreDemo.Repository.IRepository
{
    public interface IRepository<TEntity> : IDisposable
         where TEntity : class
    {
        public TEntity Get();

         Task<IEnumerable<TEntity>> GetAll();

        //public Task Create(TEntity entity);

        //void Update(TEntity entity);

        //void Delete(TEntity entity);

        public void SaveChanges();
    }
}
