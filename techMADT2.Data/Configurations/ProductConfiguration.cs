using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using techMADT2.Core.Entities;

namespace techMADT2.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150);

            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.ProductCode).HasMaxLength(50);
            builder.HasOne(p => p.Category)
       .WithMany(c => c.Products)
       .HasForeignKey(p => p.CategoryId)
       .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
