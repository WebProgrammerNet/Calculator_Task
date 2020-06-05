using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_RB.Models
{
    public class CalcResult
    {
        public int Id { get; set; }
        public DateTimeOffset Insert_Date { get; set; }
        public string  Value { get; set; }
        public int CalcFunctionId { get; set; }
        public virtual  CalcFunction CalcFunction { get; set; }
    }
}
