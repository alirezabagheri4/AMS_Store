using Domain.Aggregates.ProductAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Persistence.Configurations;

internal class ProductCommentConfig : IEntityTypeConfiguration<ProductComment>
{
    public void Configure(EntityTypeBuilder<ProductComment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().HasColumnName("Id");

        builder.Property(x => x.CommentText).HasMaxLength(100).IsRequired();
        builder.Property(x => x.SubmitDate).IsRequired();

        builder.ToTable("ProductComment", "PMS");
    }
}