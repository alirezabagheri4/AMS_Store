using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Commands.Command;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Configurations
{
    internal class ProductCommentConfig : IEntityTypeConfiguration<ProductComment>
    {
    }
}
