using exampleProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static exampleProject.Controllers.StudentsController;

namespace exampleProject.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        [OnlyStringAttribute]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        [OnlyStringAttribute]
        public string LastName { get; set; }
        [Required]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }

    }
}
