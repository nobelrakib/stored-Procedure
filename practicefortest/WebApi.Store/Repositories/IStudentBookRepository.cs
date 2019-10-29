using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace WebApi.Store.Repositories
{
    public interface IStudentBookRepository
    {
        StudentBook GetRecordofStudentBook(int studentid, string barcode);
        void IssueBook(int id, string barcode, Student student, Book book);
    }
}
