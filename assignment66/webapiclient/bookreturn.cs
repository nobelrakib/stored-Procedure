using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace webapiclient
{
    class bookreturn
    {
        public static void returnbook()
        {
            var studentbook = new studentbook();
            Console.WriteLine("Please enter student Id: _");
            
            String id = Console.ReadLine();
            int id1 = int.Parse(id);
            studentbook.studentId = id1;
            Console.WriteLine("Please enter barcode: _");
            String c = Console.ReadLine();
            studentbook.bookbarcode = c;
            Console.WriteLine("Please enter fineamount: _");
            
            String fine = Console.ReadLine();
            string[] input = { id , c, fine };
            var s2 = new PutObject();
            s2.Update(studentbook, "/studentbooks");
        }

        }
    

    }

