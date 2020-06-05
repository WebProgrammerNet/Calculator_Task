using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_RB.Models;

namespace Task_RB.DAL
{
    public class CalcResultConfiguration : IEntityTypeConfiguration<CalcResult>
    {
        public void Configure(EntityTypeBuilder<CalcResult> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(n => n.Insert_Date).IsRequired();
            builder.Property(t => t.Value).HasMaxLength(300).IsRequired();
            builder.Property(i => i.CalcFunctionId).IsRequired();
            builder.ToTable("CalcResults");
        }
    }
}
