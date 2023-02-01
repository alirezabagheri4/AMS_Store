using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Persistence.Configurations
{
    internal class ProductDescription : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.SubmitDate).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();

            builder.Ignore(x => x.IsChange);

            builder.HasIndex(c => new { c.Id, c.LastName }).IsUnique();

            builder.HasOne(c => c.Address).WithOne().HasForeignKey<Address>(c => c.Id);
            builder.ToTable("Customer", "CMS");
        }
    }
}
