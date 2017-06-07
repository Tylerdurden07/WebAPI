using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsWebAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public List<Mark> Marks { get; set; }
    }
}