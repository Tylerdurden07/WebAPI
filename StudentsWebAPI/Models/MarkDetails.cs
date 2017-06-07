using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsWebAPI.Models
{
    public class MarkDetails
    {
        public int MarkId { get; set; }

        public string Subject { get; set; }

        public int Score { get; set; }

        public Student Student { get; set; }
    }
}