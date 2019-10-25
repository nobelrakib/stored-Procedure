using System;
using WebApi.Core;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;
namespace webapiclient
{
    class Program
    {
        static void Main(string[] args)
        {

            var messege = new messege();
            Console.WriteLine(messege.multiline);
            choice();
        }
        
        
            public static void choice()
            {
            
            int num;
            string s = Console.ReadLine();
            int.TryParse(s, out num);
            if (num == 2) { var bookinformation = new bookinformation(); bookinformation.bookinfo(); }
            else if (num == 1) { var studentinformation = new studentinformation(); studentinformation.studentinfo(); }
            else if (num == 3) { var bookissue = new bookissue(); bookissue.issuebook(); }
            else if (num == 4) { var bookreturn = new bookreturn(); bookreturn.returnbook(); }
            else if (num == 5)  { var fine = new fine(); fine.CheckFine(); } 
            else if (num == 6) { var givefine = new givefine();givefine.recievefine(); }



        }
        
    }
}
