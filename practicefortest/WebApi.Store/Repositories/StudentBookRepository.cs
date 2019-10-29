using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Core;
namespace WebApi.Store.Repositories
{
    public class StudentBookRepository : IStudentBookRepository
    {
        LibraryContext _context;
        public StudentBookRepository(LibraryContext context)
        {
            _context = context;
        }
        public void IssueBook(int id,string barcode,Student student,Book book)
        {
            _context.StudentBooks.Add(new StudentBook()
            {
                StudentId = id,
                bookbarcode = barcode,
                Book = book,
                Student = student,
                IssueDate = DateTime.Now
            });
        }
        public StudentBook GetRecordofStudentBook(int studentid,string barcode)
        {
            return _context.StudentBooks.
            Where(x => x.StudentId == studentid && x.bookbarcode == barcode).FirstOrDefault();
        }
    }
}
