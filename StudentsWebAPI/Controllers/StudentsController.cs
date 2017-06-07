using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentsWebAPI.Models;
using StudentsWebAPI.IRepository;
using StudentsWebAPI.Filters;

namespace StudentsWebAPI.Controllers
{
    [AuthenticationFilter]
    [ExceptionHandler]
    public class StudentsController : ApiController
    {
        private IStudentRepository studentRepository;

        public StudentsController(IStudentRepository _studentRepo)
        {
            studentRepository = _studentRepo;
        }

        // GET: api/v1/Students
        public IList<StudentDetails> GetStudents()
        {
            return studentRepository.GetStudents();

        }

        // GET: api/v1/Students/5
        [ResponseType(typeof(StudentDetails))]
        public IHttpActionResult GetStudent(int id)
        {
            var student = studentRepository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // PUT: api/v1/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (studentRepository.EditStudent(student))
            {
                return StatusCode(HttpStatusCode.OK);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/v1/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (studentRepository.SaveStudent(student))
            {
                return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
            }
            else
            {
                return BadRequest("Email Already Exist");
            }
   
        }

        // DELETE: api/v1/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {

            Student student = (Student)studentRepository.DeleteStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

    }
}