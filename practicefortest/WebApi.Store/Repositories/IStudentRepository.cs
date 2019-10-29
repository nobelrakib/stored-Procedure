using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
namespace WebApi.Store.Repositories
{
     public interface IStudentRepository
     {
        Student GetStudentById(int id);
        void AddStudent(int id, string name);
        void DeleteStudentById(Student student);

     }
}
