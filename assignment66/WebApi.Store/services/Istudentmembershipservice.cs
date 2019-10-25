using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApi.Core;
namespace WebApi.Store
{
    public interface Istudentmembershipservice
    {
        List<student> StudentList();
        student ShowStudentProfile(int Id);
        void enrollment(int id, string name);
        void UpdateStudentinformation(int id, student student);
        void DeleteStudentInfo(int id);
        void getfine(int Id, int fine);
        double checkfine(int Id);
        void recievefine(int id,int money);
       // void enrollment((int, string) p);
    }
}
