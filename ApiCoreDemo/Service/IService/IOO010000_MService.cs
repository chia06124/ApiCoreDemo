using ApiCoreDemo.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiCoreDemo.Service.IService
{
    public interface IOO010000_MService
    {
        public  Task Create(O010000MDTO data);
    }
}
