using System;
using WebApi.Core;
namespace webapiclient
{
    class studentinformation
    {
        public static void studentinfo()
        {
            student student = new student();
            Console.WriteLine("Please enter student Id: _");
            int id;
            String s = Console.ReadLine();
            
            int.TryParse(s, out id);
            student.studentId = id;
            Console.WriteLine("Please enter student Name: _");
            String s1 = Console.ReadLine();
            student.Name = s1;
            var s2 = new PostObject();
            s2.Insert(student, "/students");
        }
    }
}
