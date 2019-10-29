using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace WebApi.Store.Services
{
    public class BookService : IBookService
    {
        private Iunitofwork unitofwork;
        public BookService(Iunitofwork unitofwork)
        {
            this.unitofwork = unitofwork;
        }
        public void InsertBook(Book book)
        {
            unitofwork._BookRepository.AddBook(book);
            unitofwork.Save();
        }
        public Book GetBookInfo(string barcode)
        {
            var book = unitofwork._BookRepository.GetBookByBarcode(barcode);
            if (book == null)
                throw new InvalidOperationException("book barcode is missing!!!");
            else return book;
        }
        public void DeleteBook(string barcode)
        {
            var book = unitofwork._BookRepository.GetBookByBarcode(barcode);
            if (book == null)
                throw new InvalidOperationException("book barcode is missing!!!");
            else
            {
                unitofwork._BookRepository.DeleteBookByBarcode(book);
                unitofwork.Save();
            }
        }
    }
}
