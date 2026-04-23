using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Engine_EEE
{
    public class Employee
    {
        
        private int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int HourlyRate { get; set;  }

        public List<TimeEntry> TimeEntries { get; set; } = new();
    }
}
