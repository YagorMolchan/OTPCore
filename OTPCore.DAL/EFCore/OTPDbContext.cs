using Microsoft.EntityFrameworkCore;
using OTPCore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPCore.DAL.EFCore
{
    public class OTPDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public OTPDbContext(DbContextOptions<OTPDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Positions)
                .WithMany(p => p.Employees)
                .UsingEntity(ep => ep.ToTable("EmployeePositions"));
        }
    }
}
