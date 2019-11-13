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
    public class StockController : ControllerBase
    {
        // GET: api/Stock
        private IStockService3 _StockService;
        public StockController(IStockService3 _StockService)
        {
            this._StockService = _StockService;
        }
        [HttpGet("{symbol}")]
        public ActionResult<List<StockRecord3>> Get(string symbol)
        {
            var k = _StockService.Get(symbol);
            return Ok(JsonConvert.SerializeObject(k, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // GET: api/Stock/5
        [HttpGet("/api/Stock/{Symbol}/{first}/{last}")]
        public ActionResult<List<StockRecord3>> Get(string symbol,DateTime first,DateTime last)
        {
            var k = _StockService.Get(symbol,first,last);
            return Ok(JsonConvert.SerializeObject(k, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // POST: api/Stock
        [HttpPost]
        public void Post([FromBody] string []input)
        {
            _StockService.Create(Convert.ToInt32(input[0]), Convert.ToDateTime(input[1]), Convert.ToInt32(input[2]), Convert.ToInt32(input[3]));
        }

        // PUT: api/Stock/5
        [HttpPut]
        public void Put( [FromBody] string[]input)
        {
            _StockService.Update(input[0], Convert.ToInt32(input[1]));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{symbol}")]
        public void Delete(string symbol)
        {
            _StockService.Delete(symbol);
        }
        [HttpDelete("/api/Stock/{symbol}/{date}")]
        public void Delete(string symbol,DateTime date)
        {
            _StockService.Delete(symbol,date);
        }
    }
}
