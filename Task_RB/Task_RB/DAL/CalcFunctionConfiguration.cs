using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_RB.Models;

namespace Task_RB.DAL
{
    public class CalcFunctionConfiguration : IEntityTypeConfiguration<CalcFunction>
    {
        public void Configure(EntityTypeBuilder<CalcFunction> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(n => n.Insert_Date).IsRequired();
            builder.ToTable("CalcFunctions");
        }
    }
}
