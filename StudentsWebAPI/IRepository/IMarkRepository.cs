using StudentsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsWebAPI.IRepository
{
    public interface IMarkRepository : IDisposable
    {
        IList<MarkDetails> GetMarks();
        MarkDetails GetMark(int id);
        bool EditMark(Mark mark);
        void SaveMark(Mark mark);
        object DeleteMark(int id);
    }
}
