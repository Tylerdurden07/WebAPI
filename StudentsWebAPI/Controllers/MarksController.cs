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
    public class MarksController : ApiController
    {
        private IMarkRepository markRepository;



        public MarksController(IMarkRepository _markRepository)
        {
            markRepository = _markRepository;
        }

        // GET: api/Marks
        public IList<MarkDetails> GetMarks()
        {
            return markRepository.GetMarks();
        }

        // GET: api/v1/Marks/5
        [ResponseType(typeof(Mark))]
        public IHttpActionResult GetMark(int id)
        {
            var mark = markRepository.GetMark(id);
            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }

        // PUT: api/v1/Marks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMark(Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (markRepository.EditMark(mark))
            {
                return StatusCode(HttpStatusCode.OK);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: api/v1/Marks
        [ResponseType(typeof(Mark))]
        public IHttpActionResult PostMark(Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            markRepository.SaveMark(mark);

            return CreatedAtRoute("DefaultApi", new { id = mark.MarkId }, mark);
        }

        // DELETE: api/v1/Marks/5
        [ResponseType(typeof(Mark))]
        public IHttpActionResult DeleteMark(int id)
        {
            Mark mark =(Mark) markRepository.DeleteMark(id);
            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }
    }
}