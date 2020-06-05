using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_RB.DAL;
using Task_RB.Models;

namespace Task_RB.Helpers
{
    public static class Extensions
    {
        public async static Task WriteDbContext(this CalcDbContext _db, int id, string message)
        {
            CalcResult calcResult = new CalcResult()
            {
                Insert_Date = DateTimeOffset.UtcNow,
                Value = message,
                CalcFunctionId = id
            };
            await _db.CalcResults.AddAsync(calcResult);
            await _db.SaveChangesAsync();
        }

    }
}
