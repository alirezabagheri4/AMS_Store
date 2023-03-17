using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Models;

namespace Domain.Aggregates.Product.ValueObjects
{
    public class ProductDto
    {
        public int Id { get; set; }

        public long ProductGroupId { get; set; }

        public string Name { get; set; }

        public eProductState ProductState { get; set; }

        public long Price { get; set; }

        public string ProductDescriptionText { get; set; }
    }
}
