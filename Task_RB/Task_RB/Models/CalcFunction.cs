using System;
using System.Collections.Generic;

namespace Task_RB.Models
{
    public class CalcFunction
    {
        public int Id { get; set; }
        public DateTimeOffset Insert_Date { get; set; }
        public virtual ICollection<CalcResult> CalcResults { get; set; }
    }
}