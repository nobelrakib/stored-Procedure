using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Store.Services
{
    public interface IReturnBookService 
    {
        void ReturnBook(int id, string barcode);
    }
}
