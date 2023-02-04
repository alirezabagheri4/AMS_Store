using Domain.Aggregates.ProductAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Persistence.Configurations;

internal class ProductDescriptionConfig : IEntityTypeConfiguration<ProductDescription>
{
    public void Configure(EntityTypeBuilder<ProductDescription> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().HasColumnName("Id");

        builder.Property(x => x.ProductDescriptionText).HasMaxLength(200).IsRequired();

        builder.HasIndex(c => new { c.Id }).IsUnique();

        builder.ToTable("ProductDescription", "PMS");
    }
}