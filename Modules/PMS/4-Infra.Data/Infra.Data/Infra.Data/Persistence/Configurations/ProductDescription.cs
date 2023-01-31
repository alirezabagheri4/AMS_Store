using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Configurations
{
    internal class ProductDescription : IEntityTypeConfiguration<Product>
    {
    }
}
