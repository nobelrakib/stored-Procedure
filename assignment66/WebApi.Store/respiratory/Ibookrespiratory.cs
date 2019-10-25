using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
namespace WebApi.Store
{
    public interface Ibookrespiratory
    {
        book ShowBooksDetails(string barcode);
        void AddBook(book book);
        List<book> GetAllBook();
        void DeleteBook(string Barcode);
        bool UpdateBooktitle(string barcode, string title);
        bool UpdateBookauthor(string barcode, string writer);
        bool updatebookbarcode(string barcode);
        bool updatebookcopycount(string barcode, int copy);
        bool updatebookedition(string barcode, string edition);
    }
}
