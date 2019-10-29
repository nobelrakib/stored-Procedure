using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Store.Repositories;
using WebApi.Core;
namespace WebApi.Store.Services
{
    public class StudentService : IStudentService
    {
        private Iunitofwork unitofwork;
        public StudentService(Iunitofwork unitofwork)
        {
            this.unitofwork = unitofwork;
        }
        public void InsertStudent(int id,string name)
        {
            unitofwork._StudentRepository.AddStudent(id, name);
            unitofwork.Save();
        }
        public Student GetStudentInfo(int id)
        {
           var student=unitofwork._StudentRepository.GetStudentById(id);
            // Student student = null;
            if (student == null)
            {
                throw new InvalidOperationException("student Id is missing!!!"); 
            }
           else return student;
        }
        public void DeleteStudent(int id)
        {
            var student = unitofwork._StudentRepository.GetStudentById(id);
            if (student == null)
                throw new InvalidOperationException("student Id is missing!!!");
            else
            {
                unitofwork._StudentRepository.DeleteStudentById(student);
                unitofwork.Save();
            }
        }
    }
}
