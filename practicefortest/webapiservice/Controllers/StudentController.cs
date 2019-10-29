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
    public class StudentController : ControllerBase
    {
        private IStudentService _IstudentService;
        private IStudentFine _IstudentFine;
        public StudentController(IStudentService _IstudentService, IStudentFine _IstudentFine)
        {
            this._IstudentService = _IstudentService;
            this._IstudentFine = _IstudentFine;
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
        public void Post(Student student)
        {
            _IstudentService.InsertStudent(student.StudentId, student.Name);
        }

        // PUT api/values/5
        [HttpPut("/api/Student/Recevefine")]
        public void put([FromBody] string[] input)
        {
            _IstudentFine.ReciveFine(int.Parse(input[0]), int.Parse(input[1]));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _IstudentService.DeleteStudent(id);
        }
        [HttpGet("/api/Student/checkfine/{id}")]
        public ActionResult<int> checkfine(int id)
        {

            return _IstudentFine.CheckFine(id);

        }
    }
}
