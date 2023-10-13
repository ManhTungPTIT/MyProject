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
    public class KPIsConfiguration : IEntityTypeConfiguration<KPIs>
    {
        public void Configure(EntityTypeBuilder<KPIs> builder)
        {
            builder.ToTable("KPI");

            builder.HasOne<Employees>(s => s.Employees)
                .WithMany(g => g.KPIs)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
