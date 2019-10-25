using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
namespace WebApi.Store
{
    public interface Ibookservices
    {
         book ShowBooks(string barcode);
        //book ShowBooks(string barcode);
         void AddBook(book book);
        List<book> GetAllBook();
        void DeleteBook(string Barcode);
        void UpdateBooktitle(string barcode, string title);
        void UpdateBookauthor(string barcode, string title);
        bool UpdateBookbarcode(string barcode);
        bool UpdateBookedition(string barcode, string title);
        bool updatebookcopycount(string barcode, int copy);
    }
}
