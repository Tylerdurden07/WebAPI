using StudentsWebAPI.IRepository;
using StudentsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebAPI.Repository
{
    public class StudentRepository : IStudentRepository , IDisposable
    {
        private ApplicationDbContext db;

        public StudentRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IList<StudentDetails> GetStudents()
        {
            return db.Students.Select(p => new StudentDetails
            {
                StudentId = p.StudentId,
                Name = p.Name,
                Department = p.Department,
                Age = p.Age,
                Email=p.Email,
                Marks = p.Marks.ToList()
            }).ToList();
        }

        public StudentDetails GetStudent(int id)
        {
            if (StudentExists(id))
            {
                return db.Students.Where(s => s.StudentId == id).Select(p => new StudentDetails
                {
                    StudentId = p.StudentId,
                    Name = p.Name,
                    Department = p.Department,
                    Age = p.Age,
                    Email=p.Email,
                    Marks = p.Marks.ToList()
                }).First();
            }

            return null;
        }

        public bool EditStudent(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.StudentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public bool SaveStudent(Student student)
        {
            if (!EmailExist(student.Email))
            {
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public object DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return null;
            }

            db.Students.Remove(student);
            db.SaveChanges();
            return student;
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentId == id) > 0;
        }

        private bool EmailExist(string emailId)
        {
            return db.Students.Count(e => e.Email == emailId) > 0;
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
