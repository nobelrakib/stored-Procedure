using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApi.Core
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double Fine { get; set; }
        public  IList<StudentBook> Books { get; set; }
    }
}
