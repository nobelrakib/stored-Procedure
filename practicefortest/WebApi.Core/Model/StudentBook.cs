using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core
{
    public class StudentBook
    {
       // public int StudentBookId { get; set; }
        public int StudentId { get; set;}
        public string bookbarcode { get; set;}
        public Book Book { get; set;}
        public Student Student { get; set;}
        public DateTime IssueDate { get; set;}
        public DateTime ReturneDate { get; set;}
    }
}
