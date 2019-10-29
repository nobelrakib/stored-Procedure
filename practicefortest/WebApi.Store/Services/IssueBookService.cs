using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Store.Services
{
    public class IssueBookService : IIssueBookService
    {
        private UnitofWork unitofwork;
        public IssueBookService(UnitofWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }
        public void BookIssue(int id,string barcode)
        {
            var student = unitofwork._StudentRepository.GetStudentById(id);
            var book = unitofwork._BookRepository.GetBookByBarcode(barcode);
            if (student == null || book == null)
            {
                throw new InvalidOperationException("book barcode is missing!!! or studentid is missing");
            }
            else
            {
                if (book.CopyCount > 0)
                {
                    unitofwork._StudentBookRepository.IssueBook(id, barcode, student, book);
                    book.CopyCount -= book.CopyCount;
                    unitofwork.Save();
                }
                else throw new InvalidOperationException("may be book is not in the stock");
            }
        }
    }
}
