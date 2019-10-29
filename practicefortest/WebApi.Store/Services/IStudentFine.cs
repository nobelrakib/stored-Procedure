using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Store.Services
{
    public interface IStudentFine
    {
        int CheckFine(int id);
        void ReciveFine(int id, int fine);
    }
}
