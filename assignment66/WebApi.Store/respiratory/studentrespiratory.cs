using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core;
using Microsoft.EntityFrameworkCore;
namespace WebApi.Store
{
    public class studentrespiratory: Istudentrespiratory
    {
        librarycontext _context;
        public studentrespiratory(librarycontext context)
        {
            _context = context;
        }
        public List<student> GetAllStudent()
        {
            return _context.Students.ToList();
        }

        public student GetStudent(int Id)
        {
            return _context.Students.Where(x => x.studentId == Id).FirstOrDefault();
        }

        public void EnrollStudent(int id, string name)
        {

            _context.Students.Add(new student
            {
                studentId = id,
                Name = name,
                fine = 0
            });
           
            
          

        }

        public bool UpdateStudentInfo(int id, student student)
        {
            var targetStudent = _context.Students.Where(x => x.studentId == id).FirstOrDefault();

            if (targetStudent != null)
            {
              //  targetStudent.studentId = student.studentId;
                targetStudent.Name = student.Name;
                targetStudent.fine = student.fine;

               
                return true;
            }
            else
                return false;
        }

        public void DeleteStudentInfo(int id)
        {
            var readStudent = _context.Students.Where(x => x.studentId == id).FirstOrDefault();

            _context.Students.Remove(readStudent);

            _context.SaveChanges();
        }
        public void getfine(int Id, int fine)
        {
            var s = _context.Students.Where(x => x.studentId == Id).SingleOrDefault();
            if (fine > s.fine)
            {
                s.fine = 0;
                //sb.returneDate = DateTime.Now;
                //b.copycount = 1 + b.copycount;
                
            }
            else
            {
                s.fine = s.fine - fine;
                //sb.returneDate = DateTime.Now;
                //b.copycount = 1 + b.copycount;
                
            }
        }
        public double checkfine(int Id)
        {
            var student = _context.Students.Where(x => x.studentId == Id).FirstOrDefault();
            return student.fine;

        }
    }
}
