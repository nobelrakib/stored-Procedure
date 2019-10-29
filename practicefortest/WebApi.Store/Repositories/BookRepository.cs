using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebApi.Core;
namespace WebApi.Store.Repositories
{
    public class BookRepository : IBookRepository
    {
        LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }
        public Book GetBookByBarcode(string barcode)
        {
            return _context.Books.Where(x => x.Barcode == barcode).FirstOrDefault();
        }
        public void AddBook(Book book)
        {
            _context.Books.Add(new Book
            {
                Title = book.Title,
                Author = book.Author,
                Barcode = book.Barcode,
                CopyCount = book.CopyCount,
                Edition = book.Edition
            });
        }
        public void DeleteBookByBarcode(Book book)
        {
            _context.Books.Remove(book);
        }
    }
}
