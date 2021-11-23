using ApiCoreDemo.DTO;
using ApiCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiCoreDemo.Repository.IRepository
{

    public interface IOO010000_MRepository 
    {
        public Task Create(O010000M O010000M, O010000MDTO data);
    }
}
