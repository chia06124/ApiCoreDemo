using ApiCoreDemo.Models;
using ApiCoreDemo.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreDemo.Repository
{
    public class BirthDayCityRepository : Repository<ViwHsoabirthCity>, IBirthDayCityRepository
    {
        public BirthDayCityRepository(EFDATAContext _EFDATAContext) : base(_EFDATAContext)
        {
        }
    }

}
