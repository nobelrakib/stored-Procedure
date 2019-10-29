using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace WebApi.Store.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void DeleteBookByBarcode(Book book);
        Book GetBookByBarcode(string barcode);
    }
}
