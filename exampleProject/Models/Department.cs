using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exampleProject.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
