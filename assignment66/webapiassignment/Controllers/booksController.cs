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
    public class booksController : ControllerBase
    {
        private Ibookservices _Ibookservices;

        public booksController(Ibookservices Bookservices)
        {
            _Ibookservices = Bookservices;
        }
        [HttpGet]
       
        // GET api/values
        [HttpGet]
        public ActionResult<List<book>> Get()
        {
            return _Ibookservices.GetAllBook();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<book> Get(string id)
        {
            return _Ibookservices.ShowBooks(id);
        }
        // POST api/values
        [HttpPost("/api/books")]
        public void Post([FromBody] book Book)
        {
            _Ibookservices.AddBook(Book);
        }
        // PUT api/values/5
        [HttpPut("/api/books/putauthor")]
        public  void Putauthor([FromBody] book book)
        {
            _Ibookservices.UpdateBooktitle(book.barcode, book.title);
        }
        [HttpPut("/api/books/puttitle")]
        public void Puttitle([FromBody] book book)
        {
            _Ibookservices.UpdateBooktitle(book.barcode,book.title);
        }
        // DELETE api/values/5
        [HttpDelete]
        public void Delete(book book)
        {
            _Ibookservices.DeleteBook(book.barcode);
        }

    }
}
