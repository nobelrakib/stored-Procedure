using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
using Microsoft.EntityFrameworkCore;
namespace WebApi.Store
{
    public class bookrespiratory: Ibookrespiratory
    {
        librarycontext _context;
        public bookrespiratory(librarycontext context)
        {
            _context = context;
        }

        public book ShowBooksDetails(string barcode)
        {
            return _context.Books.Where(x => x.barcode == barcode).FirstOrDefault();
        }
        public void AddBook(book book)
        {
            _context.Books.Add(new book
            {
                title = book.title,
                author = book.author,
                barcode = book.barcode,
                copycount = book.copycount,
                edition = book.edition
            });

           
        }
        public List<book> GetAllBook()
        {
            return _context.Books.ToList();
        }
        public void DeleteBook(string Barcode)
        {
            _context.Books.Remove(_context.Books.Where(i => i.barcode == Barcode).FirstOrDefault());
            
        }
        public bool UpdateBooktitle(string barcode, string title)
        {

            var Findbook = _context.Books.Where(i => i.barcode == barcode).FirstOrDefault();

            if (Findbook != null)
            {
               ;
                Findbook.title = title;

                //_context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateBookauthor(string barcode, string writer)
        {

            var Findbook = _context.Books.Where(i => i.barcode== barcode).FirstOrDefault();

            if (Findbook != null)
            {
                Findbook.author = writer;

               // _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool updatebookbarcode( string barcode)
        {

            var Findbook = _context.Books.Where(i => i.barcode == barcode).FirstOrDefault();

            if (Findbook != null)
            { 
                Findbook.barcode = barcode;
               

               // _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool updatebookcopycount(string barcode, int copy)
        {

            var Findbook = _context.Books.Where(i => i.barcode == barcode).FirstOrDefault();

            if (Findbook != null)
            {
                Findbook.copycount = copy;


                //_context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool updatebookedition(string barcode, string edition)
        {

            var Findbook = _context.Books.Where(i => i.barcode == barcode).FirstOrDefault();

            if (Findbook != null)
            {
                Findbook.edition = edition;


                //_context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

       
    }
}
