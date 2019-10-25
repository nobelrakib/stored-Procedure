using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;

namespace webapiclient
{
    class givefine
    {
        public void recievefine()
        {
            student student = new student();
            Console.WriteLine("Please enter student Id: _");
            int id;
            String s = Console.ReadLine();

            int.TryParse(s, out id);
            student.studentId = id;
            Console.WriteLine("give amount: _");
            int amount;
            String s1 = Console.ReadLine();

            int.TryParse(s1, out amount);
            student.fine = amount;
            var s2 = new PutObject();
            s2.Update(student, "/students/recievefine");
        }
    }
}
