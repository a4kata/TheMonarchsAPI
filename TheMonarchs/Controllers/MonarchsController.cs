using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMonarchs.Implementation;
using TheMonarchs.Interfaces;
using TheMonarchs.Models;

namespace TheMonarchs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonarchsController : Controller
    {
        private MonarchService _ms;

        public MonarchsController()
        {
            _ms = new MonarchService();
        }

        [Route("GetMonarchs_All")]
        [HttpGet()]
        public async Task<List<Monarch>> GetMonarchs_AllAsync()
        {
            return  (List<Monarch>)await _ms.GetAll<Monarch>();
        }

        [Route("GetMostCommonName")]
        [HttpGet()]
        public async Task<string> GetMostCommonNameAsync()
        {
            return await _ms.GetMostCommonRulerName();
        }

        [Route("GetLongestRuledHouse")]
        [HttpGet()]
        public async Task<string> GetLongestRuledHouseAsync()
        {
            return await _ms.GetLongestRuledHouse();
        }

        [Route("GetLongestRuledMonarch")]
        [HttpGet()]
        public async Task<string> GetLongestRuledMonarchAsync()
        {
            return await _ms.GetLongestRuled();
        }

        [Route("GetMonarchsCount")]
        [HttpGet()]
        public async Task<string> GetMonarchsCountAsync()
        {
            return await _ms.GetMonarchsCount();
        }
        

    }
}
