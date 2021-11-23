using ApiCoreDemo.DTO;
using ApiCoreDemo.Models;
using ApiCoreDemo.Repository;
using ApiCoreDemo.Repository.IRepository;
using ApiCoreDemo.Service.IService;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiCoreDemo.Service
{
    public class OO010000_MService: IOO010000_MService
    {
        private readonly IOO010000_MRepository _IOO010000_MRepository;

        public OO010000_MService(IOO010000_MRepository iOO010000_MRepository)
        {
            _IOO010000_MRepository = iOO010000_MRepository;
        }


        public async Task Create(O010000MDTO data)
        {
            O010000M objO010000M = new O010000M();
            objO010000M.FormId = data.FormID.ToString();
            objO010000M.FormNo = data.FormNo.ToString();
            objO010000M.CreateUser = "Lily1123";
            objO010000M.CreateDate = DateTime.Now;
            await  _IOO010000_MRepository.Create(objO010000M,data);
        }
    }
}
