using ApiCoreDemo.DTO;
using ApiCoreDemo.Models;
using ApiCoreDemo.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiCoreDemo.Repository
{
    public class OO010000_MRepository : Repository<O010000M>, IOO010000_MRepository
    {
        private EFDATAContext EFDATAContext;
        public OO010000_MRepository(EFDATAContext _EFDATAContext) : base(_EFDATAContext)
        {
            EFDATAContext = _EFDATAContext;
        }

        public async Task Create(O010000M objO010000M, O010000MDTO data)
        {
            EFDATAContext.O010000Ms.Add(objO010000M).CurrentValues.SetValues(data);
            await EFDATAContext.SaveChangesAsync();
        }
    }
}