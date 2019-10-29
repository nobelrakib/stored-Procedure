using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core;
using WebApi.Store;
using WebApi.Store.Services;
namespace webapiservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnBookController : ControllerBase
    {
        private IReturnBookService _IReturnBookService;

        public ReturnBookController(IReturnBookService _IReturnBookService)
        {
            this._IReturnBookService = _IReturnBookService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string[] input)
        {
            //_IReturnBookService.ReturnBook(int.Parse(input[0]), input[1]);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] string[] input)
        {
            _IReturnBookService.ReturnBook(int.Parse(input[0]), input[1]);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
