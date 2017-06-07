using StudentsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebAPI.IRepository
{
    public interface IStudentRepository : IDisposable
    {
        IList<StudentDetails> GetStudents();
        StudentDetails GetStudent(int id);

        bool EditStudent(Student student);

        bool SaveStudent(Student student);

        object DeleteStudent(int id);

    }
}
