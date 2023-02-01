using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Commands.Command;
using Domain.Aggregates.ProductAggregate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Persistence.Configurations
{
    internal class ProductCommentConfig : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().HasColumnName("Id");
            builder.Property(x => x.CommentText).HasMaxLength(100).IsRequired();
            builder.Property(x => x.SubmitDate).IsRequired();

            //one to many
            builder.HasOne(productComment => productComment.Product).WithMany().HasForeignKey(product => product.Product);

            builder.ToTable("ProductComment", "PMS");
        }
    }
}
