using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsWebAPI.Models
{
    public class Mark
    {
        public int MarkId { get; set; }


        public int StudentId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public int Score { get; set; }

        public Student Student { get; set; }
    }
}