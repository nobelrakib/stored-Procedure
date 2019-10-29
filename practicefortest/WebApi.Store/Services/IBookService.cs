using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace WebApi.Store.Services
{
     public interface IBookService
    {
        void InsertBook(Book book);
        Book GetBookInfo(string barcode);
        void DeleteBook(string barcode);
    }
}
