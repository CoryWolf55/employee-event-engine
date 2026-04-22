using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Engine_EEE
{
    public class TimeEntry
    {
        public ClockType Type { get; set; }
        public DateTime Time { get; set; }
    }

    public enum ClockType
    {
        In,
        Out
    }
}
