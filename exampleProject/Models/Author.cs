using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static exampleProject.Controllers.StudentsController;

namespace exampleProject.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        [Required]       
        public string Name { get; set; }
        [Required] 
        public string SurName { get; set; }

        public virtual ICollection<AuthorToBook> AuthorsToBooks { get; set; }

    }
}
