using LibraryWithWebApi.Client.WebRequestProcess;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace webapiclient
{
    class fine
    {
        public void CheckFine()
        {
            student student = new student();

            Console.WriteLine("Check Fine");
            Console.WriteLine("===============================");

            Console.Write("Please Enter Student Id : ");
            int id = int.Parse(Console.ReadLine());

            //var check = new GetObject();
            //check.Read(student, "/students/checkfine");
            var check = new CheckFine();
             Console.WriteLine("Your total Fine is = " + check.GetFine(id));

        }
    }
}
