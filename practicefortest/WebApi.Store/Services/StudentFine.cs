using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Store.Services
{
    public class StudentFine : IStudentFine
    {
        private UnitofWork unitofwork;
        public StudentFine(UnitofWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }
        public int CheckFine(int id)
        {
            var student = unitofwork._StudentRepository.GetStudentById(id);
            if (student == null)
                throw new InvalidOperationException("student id is missing");
            return student.StudentId;
        }
        public void ReciveFine(int id,int fine)
        {
            var student = unitofwork._StudentRepository.GetStudentById(id);
            if (student == null)
                throw new InvalidOperationException("student id is missing");
            else
            {
                if (fine > student.Fine)
                    throw new InvalidOperationException("student fine is invalid");
                else
                {
                    student.Fine = fine;
                    unitofwork.Save();
                }
            }
        }
    }
}
