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
    public class studentsController : ControllerBase
    {
        private Istudentmembershipservice _Istudentmembershipservice;
       
        public studentsController(Istudentmembershipservice studentmembershipservice)
        {
            _Istudentmembershipservice = studentmembershipservice;
        }
        [HttpGet("/api/students")]
        public ActionResult<IEnumerable<string>> GetA()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values
        [HttpGet("/api/students/getlist")]
        public ActionResult<List<student>> Get()
        {
            return _Istudentmembershipservice.StudentList();
        }

        // GET api/values/5
       [HttpGet("/api/students/getone")]
        public ActionResult<student> Get([FromBody]student student)
        {
            return _Istudentmembershipservice.ShowStudentProfile(student.studentId);
        }

        // POST api/values
        [HttpPost("/api/students")]
        public void Post([FromBody] student student)
        {    
            
            _Istudentmembershipservice.enrollment(student.studentId, student.Name);
            
        }

        // PUT api/values/5
        [HttpPut("/api/students/put")]
        public void Put( [FromBody] student student1)
        {
            _Istudentmembershipservice.UpdateStudentinformation(student1.studentId, student1);
            
        }

        // DELETE api/values/5
        [HttpDelete("/api/students/delete")]
        public void Delete([FromBody]student student)
        {
              _Istudentmembershipservice.DeleteStudentInfo(student.studentId);
        }
        // PUT api/values/5
        [HttpPut("/api/students/getfine")]
        public void getfine( [FromBody]student student ) //id,fine
        {
            _Istudentmembershipservice.getfine(student.studentId, student.fine);
        }
        [HttpPut("/api/students/recievefine")]
        public void recievefine([FromBody]student student) //id,fine
        {
            _Istudentmembershipservice.recievefine(student.studentId, student.fine);
        }
        [HttpGet("{id}")]
        public ActionResult<double> checkfine(int id)
        {

            return _Istudentmembershipservice.checkfine(id);

        }
    }
}
