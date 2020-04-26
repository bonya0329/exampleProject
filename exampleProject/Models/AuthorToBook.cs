﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exampleProject.Models
{
    public class AuthorToBook
    {
        public int AuthorToBookID { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
