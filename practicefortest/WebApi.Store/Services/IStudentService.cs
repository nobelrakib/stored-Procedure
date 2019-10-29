using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace WebApi.Store.Services
{
    public interface IStudentService
    {
        void InsertStudent(int id, string name);
        Student GetStudentInfo(int id);
        void DeleteStudent(int id);

    }
}
