using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Store.Services
{
     public interface IIssueBookService
    {
        void BookIssue(int id, string barcode);
    }
}
