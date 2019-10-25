using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace webapiclient
{
    class bookinformation
    {
        public static void bookinfo()
        {
            var book = new book();
            
            Console.WriteLine("Please enter bookname: _");
            String n = Console.ReadLine();
            book.title = n;
            Console.WriteLine("Please enter edition: _");
            String e = Console.ReadLine();
            book.edition = e;
            Console.WriteLine("Please enter barcode: _");
            String c = Console.ReadLine();
            book.barcode = c;
            int count;
            String copy = Console.ReadLine();
            int.TryParse(copy, out count);
            book.copycount = count;
            var s2 = new PostObject();
            s2.Insert(book, "/books");

        }
    }
}
