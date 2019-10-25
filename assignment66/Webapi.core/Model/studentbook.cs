using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Core
{
    public class studentbook
    {   
       // public int id { get; set; }
        public int bookId { get; set; }
        public int studentId { get; set; }
        public string bookbarcode { get; set; }
        public book book { get; set; }
        public student student { get; set; }
        public DateTime issuedate { get; set; }
        public DateTime returneDate { get; set; }
    }
}

