using Microsoft.AspNetCore.Mvc;
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
        [Required]
        public string Address { get; set; }
        [Required]
        [Remote(action: "ValidateCity", controller: "StudentAddresses", ErrorMessage = "Please enter a valid city.")]
        public string City { get; set; }
        [Required]
        [Remote(action: "ValidateCountry", controller: "StudentAddresses", ErrorMessage = "Please enter a valid country.")]
        public string Country { get; set; }

        public virtual Student Student { get; set; }

    }
}
