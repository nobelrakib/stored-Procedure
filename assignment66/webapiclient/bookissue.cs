using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace webapiclient
{
    class bookissue
    {
        public static void issuebook()
        {
            var studentbook = new studentbook();
            Console.WriteLine("Please enter student Id: _");
            int id;
            String s = Console.ReadLine(); int.TryParse(s, out id);
            studentbook.studentId = id;
            Console.WriteLine("Please enter barcode: _");
            String c = Console.ReadLine();
            studentbook.bookbarcode = c;
            var s2 = new PostObject();
            s2.Insert(studentbook, "/studentbooks");
        }
    }
}

