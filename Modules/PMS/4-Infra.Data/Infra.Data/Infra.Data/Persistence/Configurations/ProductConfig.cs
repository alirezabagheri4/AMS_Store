using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate;
using Domain.Aggregates.ProductAggregate.@enum;
using Domain.Aggregates.ProductAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Persistence.Configurations;

internal class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().HasColumnName("Id");

        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.ProductState).IsRequired().HasDefaultValue(eProductState.Unknown);
        builder.Property(x => x.SubmitDate).IsRequired().HasDefaultValue(DateTime.Now);

        builder.HasIndex(c => new { c.Id }).IsUnique();
        builder.HasIndex(c => new { c.Name }).IsUnique();

        //one to one
        builder.HasOne(product => product.ProductDescription).WithOne().HasForeignKey<ProductDescription>(c => c.ProductId);
        builder.HasOne(product => product.ProductGroup).WithOne().HasForeignKey<ProductGroup>(c => c.Products);

        //one to many
        builder.HasMany(product => product.ProductComments).WithOne().HasForeignKey(comment => comment.ProductId);


        builder.ToTable("Product", "PMS");
    }
}