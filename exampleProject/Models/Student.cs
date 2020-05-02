using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static exampleProject.Controllers.StudentsController;

namespace exampleProject.Models
{
    public class Student : IValidatableObject
    {
        public int StudentID { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        [OnlyStringAttribute]
        public string Name { get; set; }
        [Required]
        [OnlyStringAttribute]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string SurName { get; set; }
        [Required]
        [OnlyNumbersAttribute]
        public int Age { get; set; }

        public virtual StudentAddress StudentAddress { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.Age < 1 || this.Age > 150)
                errors.Add(new ValidationResult("Invalid age"));

            return errors;
        }
    }
}
