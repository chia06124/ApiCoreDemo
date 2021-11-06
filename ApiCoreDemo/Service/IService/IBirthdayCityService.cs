using ApiCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreDemo.Service.IService
{
    public interface IBirthdayCityService
    {
        public Task<IEnumerable<ViwHsoabirthCity>> GetAll();
    }
}
