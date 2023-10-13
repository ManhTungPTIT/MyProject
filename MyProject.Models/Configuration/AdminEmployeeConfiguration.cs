using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Configuration
{
    public class AdminEmployeeConfiguration : IEntityTypeConfiguration<AdminEmployees>
    {
        public void Configure(EntityTypeBuilder<AdminEmployees> builder)
        {
            builder.ToTable("AdminEmployee");

            builder.HasOne<Admin>(s => s.Admin)
                .WithMany(s => s.AdminEmployees)
                .HasForeignKey(sc => sc.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Employees>(s => s.Employee)
                .WithMany(s => s.AdminEmployees)
                .HasForeignKey(sc => sc.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
