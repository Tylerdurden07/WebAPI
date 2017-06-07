using StudentsWebAPI.IRepository;
using StudentsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace StudentsWebAPI.Repository
{
    public class MarkRepository : IMarkRepository ,IDisposable
    {
        private ApplicationDbContext db;

        public MarkRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

       public IList<MarkDetails> GetMarks()
        {
            return db.Marks.Select(m => new MarkDetails
            {
                MarkId = m.MarkId,
                Subject = m.Subject,
                Score = m.Score,
                Student = m.Student

            }).ToList();
        }

        public MarkDetails GetMark(int id)
        {
            if (MarkExists(id))
            {
                return db.Marks.Where(m => m.MarkId == id).Select(m => new MarkDetails
                {
                    MarkId = m.MarkId,
                    Subject = m.Subject,
                    Score = m.Score,
                    Student = m.Student

                }).First();
            }
            return null;
        }

        public bool EditMark(Mark mark)
        {
            db.Entry(mark).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkExists(mark.MarkId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public void SaveMark(Mark mark)
        {
            db.Marks.Add(mark);
            db.SaveChanges();
            
        }

        public object DeleteMark(int id)
        {
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return null;
            }

            db.Marks.Remove(mark);
            db.SaveChanges();
            return mark;
        }


        private bool MarkExists(int id)
        {
            return db.Marks.Count(e => e.MarkId == id) > 0;
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