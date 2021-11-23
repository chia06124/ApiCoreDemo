using ApiCoreDemo.Models;
using ApiCoreDemo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreDemo.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EFDATAContext _EFDATAContext;
        public Repository(EFDATAContext efdataContext)
        {
            _EFDATAContext = efdataContext;
        }
        public TEntity Get()
        {
            return _EFDATAContext.Set<TEntity>().FirstOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _EFDATAContext.Set<TEntity>().ToListAsync();
        }

        public void SaveChanges()
        {
            _EFDATAContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._EFDATAContext != null)
                {
                    this._EFDATAContext.Dispose();
                }
            }
        }
    }
}
