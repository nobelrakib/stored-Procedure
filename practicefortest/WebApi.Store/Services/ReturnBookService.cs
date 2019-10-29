using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Store.Services
{
     public class ReturnBookService : IReturnBookService
    {
        private Iunitofwork unitofwork;
        public ReturnBookService(Iunitofwork unitofwork)
        {
            this.unitofwork = unitofwork;
        }
        public void ReturnBook(int id,string barcode)
        {
            var studentbook = unitofwork._StudentBookRepository.GetRecordofStudentBook(id, barcode);
            if(studentbook==null)
                throw new InvalidOperationException("book barcode is missing!!! or studentid is missing");
            else
            {
                studentbook.ReturneDate = DateTime.Now;
                var timediffrence = (studentbook.ReturneDate - studentbook.IssueDate).Days;
                if(timediffrence>7)
                {
                    var fine = (timediffrence - 7) * 10;
                    var student = unitofwork._StudentRepository.GetStudentById(id);
                    student.Fine = fine;
                }
                var book = unitofwork._BookRepository.GetBookByBarcode(barcode);
                book.CopyCount = book.CopyCount;
                unitofwork.Save();
            }
        }
    }
}
