using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketApi.Store3;
using Newtonsoft.Json;
namespace StockMarket.Api3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Company3Controller : ControllerBase
    {
        private ICompanyService3 _companyService;
        public Company3Controller(ICompanyService3 _companyService)
        {
            this._companyService = _companyService;
        }

        [HttpGet]
        public ActionResult<List<Company3>> Get()
        {
            var k =_companyService.Get();
            return Ok(JsonConvert.SerializeObject(k, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // GET: api/Company3/5
        [HttpGet("{symbol}")]
        public ActionResult<Company3> Get(string symbol)
        {
            var k= _companyService.Get(symbol);
            return Ok(JsonConvert.SerializeObject(k, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // POST: api/Company3
        [HttpPost]
        public void Post([FromBody] string[] input)
        {
            _companyService.Create(input[0], input[1]);
        }

        // PUT: api/Company3/5
        [HttpPut]
        public void Put([FromBody] string[] input)
        {
            _companyService.Update(input[0], input[1]);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{symbol}")]
        public void Delete(string symbol)
        {
            _companyService.Delete(symbol);
        }
    }
}
