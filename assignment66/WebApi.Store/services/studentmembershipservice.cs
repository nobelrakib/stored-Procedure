using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
namespace WebApi.Store
{
    public class studentmembershipservice: Istudentmembershipservice
    {
        private unitofwork unitofwork;
        public studentmembershipservice(unitofwork unitofwork)
        {
            this.unitofwork = unitofwork;
        }
        public List<student> StudentList()
        {
            return unitofwork.Studentrespiratory.GetAllStudent(); 
        }
        public student ShowStudentProfile(int Id)
        {
            return unitofwork.Studentrespiratory.GetStudent(Id);
        }
        public void enrollment(int id,string name)
        {
            unitofwork.Studentrespiratory.EnrollStudent(id, name);
            unitofwork.Save();
        }
        public void UpdateStudentinformation(int id, student student)
        {
            unitofwork.Studentrespiratory.UpdateStudentInfo(id, student);
            unitofwork.Save();
        }
        public void DeleteStudentInfo(int id)
        {
            unitofwork.Studentrespiratory.DeleteStudentInfo(id); unitofwork.Save();
        }
        public void getfine(int Id, int fine)
        {
            unitofwork.Studentrespiratory.getfine(Id,fine); unitofwork.Save();
        }
        public double checkfine(int Id)
        {
           
            return unitofwork.Studentrespiratory.checkfine(Id)   ;

        }
        public void recievefine(int id,int money)
        {
            var student= unitofwork.Studentrespiratory.GetStudent(id);
            if (student != null) student.fine = student.fine-money;
            if (student.fine < 0) student.fine = 0;
            unitofwork.Save();
        }

        //public void enrollment((int, string) p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
