using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_RB.Models;

namespace Task_RB.DAL
{
    public class CalcDbContext : DbContext
    {
        public CalcDbContext(DbContextOptions<CalcDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CalcFunction>().HasData(
                  new CalcFunction { Id = 1, Insert_Date = DateTimeOffset.UtcNow },
                  new CalcFunction { Id = 2, Insert_Date = DateTimeOffset.UtcNow },
                  new CalcFunction { Id = 3, Insert_Date = DateTimeOffset.UtcNow },
                  new CalcFunction { Id = 4, Insert_Date = DateTimeOffset.UtcNow }
           );

            //Fluent Api
            modelBuilder.ApplyConfiguration(new CalcFunctionConfiguration());
            modelBuilder.ApplyConfiguration(new CalcResultConfiguration());

            modelBuilder.Entity<CalcResult>().HasOne(t => t.CalcFunction)
                 .WithMany(u => u.CalcResults).HasForeignKey(t => t.CalcFunctionId).OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<CalcFunction> CalcFunctions { get; set; }
        public DbSet<CalcResult> CalcResults { get; set; }
    }
}
