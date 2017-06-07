using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsWebAPI.Models
{
    public class StudentDetails
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<Mark> Marks { get; set; }
    }
}