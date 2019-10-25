using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
namespace WebApi.Store
{
    public class libraryservice:Ilibraryservice
    {
        //private Ibookrespiratory _Ibookrespiratory;
        //private Istudentrespiratory _Istudentrespiratory;
        //private Istudentbookrespiratory _Istudentbookrespiratory;
        private unitofwork unitofwork;
        public libraryservice(unitofwork unitofwork)
        {
            this.unitofwork = unitofwork;
        }
        //public libraryservice(Ibookrespiratory Bookrespiratory, Istudentrespiratory Studentrespiratory, Istudentbookrespiratory Studentbookrespiratory)
        //{
        //    _Ibookrespiratory = Bookrespiratory;
        //    _Istudentrespiratory = Studentrespiratory;
        //    _Istudentbookrespiratory = Studentbookrespiratory;
        //}
        public void bookissue(int id,string barcode)
        {
            unitofwork.Studentbookrespiratory.bookissue(id, barcode);
            unitofwork.Save();
        }
        public void returnbook(int id, string barcode)
        {
            unitofwork.Studentbookrespiratory.returnbook(id, barcode);
            unitofwork.Save();
        }

    }
}
