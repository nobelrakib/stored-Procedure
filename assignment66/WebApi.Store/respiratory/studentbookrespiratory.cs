using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
using Microsoft.EntityFrameworkCore;
namespace WebApi.Store
{
    public class studentbookrespiratory : Istudentbookrespiratory
    {
        librarycontext _context;
        public studentbookrespiratory(librarycontext context)
        {
            _context = context;
        }
        public void bookissue(int id, string barcode)
        {
            var b = _context.Books.Where(x => x.barcode == barcode).FirstOrDefault();
            var s = _context.Students.Where(x => x.studentId == id).FirstOrDefault();
            if (b != null && s != null)
            {
                if (b.copycount > 0)
                {
                    _context.studentbooks.Add(new studentbook()
                    {
                        studentId = id,
                        bookbarcode = barcode,
                        book = b,
                        student = s,
                        issuedate = DateTime.Now

                    });
                    b.copycount -= 1;
                }
                
                
            }
            
           
        }
        public void returnbook(int id, string barcode)
        {
            var a = _context.Students.Where(x => x.studentId == id ).FirstOrDefault();
            var sb = _context.studentbooks.Where(x => x.studentId ==a.id && x.bookbarcode == barcode).FirstOrDefault();
            var b = _context.Books.Where(x => x.barcode == barcode).FirstOrDefault();
            if (sb != null)
            {
                DateTime value = new DateTime(2019, 10, 30);
                sb.returneDate = value;
                
               calculatefine(sb.returneDate, sb.issuedate, barcode, id);

                b.copycount = 1 + b.copycount;
                
            }
            
        }
        public DateTime getreturnbook(string barcode, int id)
        {
            var a = _context.Students.Where(x => x.studentId == id).FirstOrDefault();
            var sb = _context.studentbooks.Where(x => x.studentId == a.id && x.bookbarcode == barcode).FirstOrDefault();
            return sb.returneDate;
        }
        public DateTime getissuedate(string barcode, int id)
        {
            var a = _context.Students.Where(x => x.studentId == id).FirstOrDefault();
            var sb = _context.studentbooks.Where(x => x.studentId == a.id && x.bookbarcode == barcode).FirstOrDefault();
            return sb.issuedate;
        }
        public void calculatefine(DateTime returndate, DateTime issuedate, string barcode, int id)
        {
            var sb = _context.Students.Where(x => x.studentId == id).FirstOrDefault();
            var dif = (returndate - issuedate).Days;
            if (dif > 7)
            {
                var fine = (dif - 7) * 10;
                sb.fine = fine; //_context.SaveChanges();
            }
            else
            {
                sb.fine = 0; //_context.SaveChanges(); }
                
            }

        }
    }
}

