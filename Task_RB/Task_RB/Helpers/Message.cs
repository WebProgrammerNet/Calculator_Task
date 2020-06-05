using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_RB.Helpers
{
    public static class Message
    {
        public static string Info(Number number, int method, int calcresult)
        {
            string result = null;
            if (method == 1)
            {
                 result = $"Required CalcMethodtype : Add;  {number.Number_1} + {number.Number_2} = {calcresult}";
            }
            if (method == 2)
            {
                 result = $"Required CalcMethodtype : Subtract;  {number.Number_1} - {number.Number_2} = {calcresult}";
            }
            if (method == 3)
            {
                 result = $"Required CalcMethodtype : Multiply;  {number.Number_1} * {number.Number_2} = {calcresult}";
            }
            if (method == 4)
            {
                result = $"Required CalcMethodtype : Divide;  {number.Number_1} : {number.Number_2} = {calcresult}";
            }
            return result;
        }
    }
}
