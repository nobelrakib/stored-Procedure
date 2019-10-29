using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebApi.Store.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        LibraryContext _context;
        public StudentRepository(LibraryContext context)
        {
            _context = context;
        }
        public Student GetStudentById(int id)
        {
            return  _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
        }
        public void AddStudent(int id,string name)
        {
            _context.Students.Add(new Student
            {
                StudentId = id,
                Name = name
            }); 
        }
        public void DeleteStudentById(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}
