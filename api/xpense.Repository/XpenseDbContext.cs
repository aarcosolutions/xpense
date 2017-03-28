using Microsoft.EntityFrameworkCore;
using System;
using xpense.DataModel;

namespace xpense.Repository
{
    public class XpenseDbContext : BaseDbContext<XpenseDbContext>
    {
        public XpenseDbContext(DbContextOptions<XpenseDbContext> options):base(options)
        {

        }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeContactDetail> EmployeeContactDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //prefer keeping the singular table name 
            modelBuilder.Entity<Organisation>().ToTable("Organisation");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<EmployeeContactDetail>().ToTable("EmployeeContactDetail");
        }


    }
}
