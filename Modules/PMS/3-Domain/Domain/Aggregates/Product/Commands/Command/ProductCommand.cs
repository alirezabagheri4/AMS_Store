using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Models;

namespace Domain.Aggregates.Product.Commands.Command
{
    public class ProductCommand: Common.Command
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public eProductState ProductState { get; set; }

        public long Price { get; set; }

        public ProductDescription ProductDescription { get; set; }

        public ProductGroup.Models.ProductGroup ProductGroupId { get; set; }
    }
}
