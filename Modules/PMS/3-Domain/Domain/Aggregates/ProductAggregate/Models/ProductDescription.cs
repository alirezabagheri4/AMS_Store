using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.ProductAggregate.Models
{
    public class ProductDescription : BaseEntity, IAggregateRoot
    {
        public long ProductId { get; set; }

        public string ProductDescriptionText { get; set; }
    }
}
