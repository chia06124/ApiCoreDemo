using ApiCoreDemo.Models;
using ApiCoreDemo.Repository.IRepository;
using ApiCoreDemo.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCoreDemo.Service
{
    public class BirthdayCityService: IBirthdayCityService
    {
        private readonly IBirthDayCityRepository _IBirthDayCityRepository;

        public BirthdayCityService(IBirthDayCityRepository birthDayCityRepository)
        {
            _IBirthDayCityRepository = birthDayCityRepository;
        }
        public async Task<IEnumerable<ViwHsoabirthCity>> GetAll()
        {
            return await _IBirthDayCityRepository.GetAll();
        }
    }
}
