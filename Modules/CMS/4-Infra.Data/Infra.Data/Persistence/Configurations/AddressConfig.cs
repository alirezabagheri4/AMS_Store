using Domain.Aggregates.CustomerAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.Configurations
{
    internal class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.DetailAddress).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => new { c.Id }).IsUnique();

            builder.ToTable("Customer", "CMS");
        }
    }
}
