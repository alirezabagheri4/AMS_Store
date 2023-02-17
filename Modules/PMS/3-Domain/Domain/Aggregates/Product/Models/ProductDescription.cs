using Domain.Aggregates.Product.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.Product.Models
{
    public class ProductDescription : BaseEntity, IAggregateRoot
    {
        public long ProductId { get; set; }

        public string ProductDescriptionText { get; set; }
    }
}
