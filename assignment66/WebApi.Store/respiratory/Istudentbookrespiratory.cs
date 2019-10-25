using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Store
{
    public interface Istudentbookrespiratory
    {
         DateTime getreturnbook(string barcode, int id);
        DateTime getissuedate(string barcode, int id);
        void returnbook(int id, string barcode);
        void bookissue(int id, string barcode);
        void calculatefine(DateTime returndate, DateTime issuedate, string barcode, int id);
    }
}
