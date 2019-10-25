using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapiassignment;
using WebApi.Core;
using WebApi.Store;

namespace webapiassignment
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentbooksController : ControllerBase
    {
        private Ilibraryservice _Ilibraryservice;

        public studentbooksController(Ilibraryservice libraryservice)
        {
            _Ilibraryservice = libraryservice;
        }
        [HttpGet("/api/studentbooks")]
        public ActionResult<IEnumerable<string>> GetA()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("/api/studentbooks")]
        public void IssueBook([FromBody]studentbook studentbook)/// StudentID,Barcode 
        {
            _Ilibraryservice.bookissue(studentbook.studentId,studentbook.bookbarcode);

        }

        [HttpPut("/api/studentbooks")]

        public void ReturnBook([FromBody]studentbook studentbook)/// StudentID,Barcode 
        {
            _Ilibraryservice.returnbook(studentbook.studentId, studentbook.bookbarcode);
        }



    }
}
