using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace exampleProject.Models
{
    public class StudentAddress
    {
        [Key]
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual Student Student { get; set; }
    }
}
