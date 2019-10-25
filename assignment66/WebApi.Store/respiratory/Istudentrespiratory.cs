using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
namespace WebApi.Store
{
    public interface Istudentrespiratory
    {
        List<student> GetAllStudent();
         student GetStudent(int Id);
         void EnrollStudent(int id, string name);
        bool UpdateStudentInfo(int id, student student);
        void DeleteStudentInfo(int id);
        void getfine(int Id, int fine);
        double checkfine(int Id);
    }
}
