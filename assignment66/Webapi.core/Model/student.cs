using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Core
{
    public class student
    {
        
            public int id { get; set; }
            public int studentId { get; set; }
            public string Name { get; set; }
            public int fine { get; set; } = 0;
            public IList<studentbook> books { get; set; }

        
    }
}
