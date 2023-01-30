using Domain.Aggregates.CustomerAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
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

//add relation one to one in product config
//builder.HasOne(c=>c.Discount).WithOne().HasForeignKey<Discount>(x=>x.ProductId);

//add relation one to many in product config
//builder.HasMany(c=>c.Comments).WithOne().HasForeignKey(x=>x.ProductId);