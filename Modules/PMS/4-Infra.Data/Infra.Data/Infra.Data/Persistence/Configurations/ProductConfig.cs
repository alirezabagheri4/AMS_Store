﻿using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Models;
using Domain.Aggregates.ProductGroup.Models;
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
        builder.HasOne(product => product.ProductDescription);

        //one to many
        builder.HasMany(product => product.ProductComments).WithOne().HasForeignKey(comment => comment.ProductId);
        builder.HasOne(product => product.ProductGroup).WithMany(c => c.Products);


        builder.ToTable("Product", "PMS");
    }
}