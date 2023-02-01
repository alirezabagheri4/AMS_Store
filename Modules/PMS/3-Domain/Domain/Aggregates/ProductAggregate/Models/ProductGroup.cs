using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.ProductAggregate.Models
{
    public class ProductGroup : BaseEntity, IAggregateRoot
    {
        public string GroupName { get; set; }

        public string Description { get; set; }
    }
}
