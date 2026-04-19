using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Engine_EEE
{
    //Simply a parent class for employees
    internal class Employee
    {
        int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
