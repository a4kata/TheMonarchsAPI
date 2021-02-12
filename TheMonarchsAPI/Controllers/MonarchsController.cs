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
        private IGovernmentDataService _gdp;

        public MonarchsController(IGovernmentDataService gdp)
        {
            _gdp = gdp;
        }

        [Route("GetMonarchs_All")]
        [HttpGet()]
        public async Task<List<Monarch>> GetMonarchs_AllAsync() => (List<Monarch>)await _gdp.GetAll<Monarch>();

        [Route("GetMostCommonName")]
        [HttpGet()]
        public async Task<string> GetMostCommonNameAsync() => await _gdp.GetMostCommonRulerName();

        [Route("GetLongestRuledHouse")]
        [HttpGet()]
        public async Task<string> GetLongestRuledHouseAsync() => await _gdp.GetLongestRuledHouse();

        [Route("GetLongestRuledMonarch")]
        [HttpGet()]
        public async Task<string> GetLongestRuledMonarchAsync() => await _gdp.GetLongestRuled();

        [Route("GetMonarchsCount")]
        [HttpGet()]
        public async Task<string> GetMonarchsCountAsync() => await _gdp.GetCount();


    }
}
