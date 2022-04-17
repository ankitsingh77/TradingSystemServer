using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Calendar
    {
        public Guid Id { get; set; }
        public DateTime Date {get; set;}
        public bool IsHoliday { get; set; }
        public bool IsWeekend { get; set; }

    }
}
