using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Models.Model;

namespace MyProject.Models.Configuration;

public class ProductBillConfiguration : IEntityTypeConfiguration<ProductBill>
{
    public void Configure(EntityTypeBuilder<ProductBill> builder)
    {
        builder.ToTable("ProductBill");

        builder.HasOne<Product>(p => p.Product)
            .WithMany(s => s.ProductBills)
            .HasForeignKey(sc => sc.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Bill>(b => b.Bill)
            .WithMany(s => s.ProductBills)
            .HasForeignKey(sc => sc.BillId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}