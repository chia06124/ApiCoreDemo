using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCoreDemo.Models;
using ApiCoreDemo.Repository.IRepository;
using ApiCoreDemo.Service.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCoreDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OOController : ControllerBase
    {
        private readonly IBirthdayCityService _IBirthdayCityService;
        public OOController(IBirthdayCityService IBirthdayCityService)
        {
            _IBirthdayCityService = IBirthdayCityService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ViwHsoabirthCity>> GetBirthdayCity()
        {
            return  await _IBirthdayCityService.GetAll();
        }

    }
}
