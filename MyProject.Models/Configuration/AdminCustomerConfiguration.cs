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
    public class AdminCustomerConfiguration : IEntityTypeConfiguration<AdminCustomers>
    {
        public void Configure(EntityTypeBuilder<AdminCustomers> builder)
        {
            builder.ToTable("AdminCustomer");

            builder.HasOne<Admin>(sc => sc.Admin)
                .WithMany(s => s.AdminCustomers)
                .HasForeignKey(sc => sc.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Customers>(sc => sc.Customers)
                .WithMany(s => s.AdminCustomers)
                .HasForeignKey(sc => sc.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
