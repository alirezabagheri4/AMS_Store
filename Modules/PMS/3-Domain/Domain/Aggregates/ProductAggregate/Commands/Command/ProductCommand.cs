using Domain.Aggregates.ProductAggregate.@enum;
using Domain.Aggregates.ProductAggregate.Models;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class ProductCommand: Common.Command
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public eProductState ProductState { get; set; }

        public long Price { get; set; }

        public ProductDescription ProductDescription { get; set; }

        public long ProductGroupId { get; set; }
    }
}
