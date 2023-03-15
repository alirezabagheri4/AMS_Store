using Domain.Aggregates.Product.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.Product.Models
{
    public class ProductDescription : BaseEntity, IAggregateRoot
    {
        public string ProductDescriptionText { get; set; }

        public ProductDescription(long productId, string productDescriptionText)
        {
            ProductDescriptionText=productDescriptionText;
        }

        public ProductDescription(string productDescriptionText)
        {
            ProductDescriptionText = productDescriptionText;
        }

        public ProductDescription()
        {
        }
    }
}
