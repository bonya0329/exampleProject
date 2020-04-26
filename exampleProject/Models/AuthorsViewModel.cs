using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exampleProject.Models
{
    public class AuthorsViewModel
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<CheckBoxViewModel> Books { get; set; }
    }
}
