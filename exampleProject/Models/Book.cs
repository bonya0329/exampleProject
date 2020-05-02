using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exampleProject.Models
{
    public class Book
    {
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual ICollection<AuthorToBook> AuthorsToBooks { get; set; }

    }
}
