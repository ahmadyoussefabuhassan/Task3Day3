using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task3Day3.Domain.Products;

namespace Task3Day3.Infrastructure.Configurations
{
    public sealed class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name)
                .HasConversion(n => n.Value, t => new Name(t))
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(pro => pro.Price)
                 .HasConversion(p => p.Value, p => new Price(p))
                 .IsRequired()
                 .HasColumnType("decimal(18,2)");
        }
    }
}
