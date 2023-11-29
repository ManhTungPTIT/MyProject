using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Models.Model;

namespace MyProject.Models.Configuration;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bill");

        builder.HasOne<Customers>(c => c.Customers)
            .WithMany(b => b.Bills)
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Employees>(b => b.Employees)
            .WithMany(e => e.Bills)
            .HasForeignKey(sc => sc.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}