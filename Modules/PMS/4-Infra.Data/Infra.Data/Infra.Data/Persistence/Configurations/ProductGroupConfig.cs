using Domain.Aggregates.ProductAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Persistence.Configurations;

internal class ProductGroupConfig : IEntityTypeConfiguration<ProductGroup>
{
    public void Configure(EntityTypeBuilder<ProductGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().HasColumnName("Id");

        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        builder.Property(x => x.GroupName).HasMaxLength(30).IsRequired();
        builder.Property(x => x.SubmitDate).IsRequired();

        builder.HasIndex(c => new { c.Id }).IsUnique();

        //builder.HasMany(productGroup => productGroup.Products).WithOne().HasForeignKey(Product => Product.ProductGroup);

        builder.ToTable("ProductGroup", "PMS");
    }
}