using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exampleProject.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public virtual ICollection<AuthorToBook> AuthorsToBooks { get; set; }
    }
}
