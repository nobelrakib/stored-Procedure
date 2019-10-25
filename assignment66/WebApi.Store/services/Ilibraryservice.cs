using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Store
{
    public interface Ilibraryservice
    {
        void bookissue(int id, string barcode);
        void returnbook(int id, string barcode);
    }
}
