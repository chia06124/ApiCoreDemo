using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using ApiCoreDemo.ActionFilter1;
using ApiCoreDemo.DTO;
using ApiCoreDemo.Models;
using ApiCoreDemo.Repository.IRepository;
using ApiCoreDemo.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCoreDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OOController : ControllerBase
    {
        private readonly IBirthdayCityService _IBirthdayCityService;
        private readonly IOO010000_MService _IOO010000_MService;
        public OOController(IBirthdayCityService IBirthdayCityService, IOO010000_MService IOO010000_MService)
        {
            _IBirthdayCityService = IBirthdayCityService;
            _IOO010000_MService = IOO010000_MService;
        }
        [HttpGet]
        [AuthorizationFilter]
        public async Task<IEnumerable<ViwHsoabirthCity>> GetBirthdayCity()
        {
            return  await _IBirthdayCityService.GetAll();
        }

        [HttpPost]
        [AuthorizationFilter]
        public async Task SetApplyDataAsync([FromBody] O010000MDTO data)
        {
            if (data.FormID != null)
            {
                await _IOO010000_MService.Create(data);
            }
        }

    }
}
