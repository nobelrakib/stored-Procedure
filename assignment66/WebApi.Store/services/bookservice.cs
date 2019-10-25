using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
namespace WebApi.Store
{
    public class bookservice : Ibookservices
    {
        private unitofwork unitofwork;
        public bookservice(unitofwork unitofwork)
        {
            this.unitofwork=unitofwork;
        }
        public book ShowBooks(string barcode)
        {
            return unitofwork.Bookrespiratory.ShowBooksDetails(barcode);
        }
        public void AddBook(book book)
        {
            unitofwork.Bookrespiratory.AddBook(book);
            unitofwork.Save();
        }
        public List<book> GetAllBook()
        {
            return unitofwork.Bookrespiratory.GetAllBook();
        }
        public void DeleteBook(string Barcode)
        {
            unitofwork.Bookrespiratory.DeleteBook(Barcode);unitofwork.Save();
        }
        public void UpdateBooktitle(string barcode, string title)
        {
             unitofwork.Bookrespiratory.UpdateBooktitle(barcode, title);
            unitofwork.Save();
        }
        public void UpdateBookauthor(string barcode, string title)
        {
            unitofwork.Bookrespiratory.UpdateBookauthor(barcode, title);
            unitofwork.Save();
        }
        public bool UpdateBookbarcode(string barcode)
        {
            return unitofwork.Bookrespiratory.updatebookbarcode(barcode);
        }
        public bool UpdateBookedition(string barcode, string title)
        {
            return unitofwork.Bookrespiratory.updatebookedition(barcode, title);
        }
        public bool updatebookcopycount(string barcode, int copy)
        {
            return unitofwork.Bookrespiratory.updatebookcopycount(barcode, copy);
        }
    }
}
