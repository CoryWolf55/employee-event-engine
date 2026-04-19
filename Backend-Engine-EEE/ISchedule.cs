using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Engine_EEE
{
    internal interface ISchedule
    {
         List<Day> days { get; set; }
        void EditDay(Day day, Task task);
    }
}
