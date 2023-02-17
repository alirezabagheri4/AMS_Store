using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.Product.Models
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public eProductState ProductState { get; set; }

        public long Price { get; set; }

        public List<ProductComment> ProductComments{ get; set; }

        public ProductDescription ProductDescription { get; set; }

        public ProductGroup ProductGroup { get; set; }
        public long ProductGroupId { get; set; }

        public Product(string productName,eProductState productState,long price,string productDescription,long productGroup)
        {
            this.Name=productName;
            this.ProductState=productState;
            this.Price=price;
            this.ProductDescription = new  ProductDescription(){ProductDescriptionText = productDescription};
            this.ProductGroupId = productGroup;
        }

        public Product()
        {
        }
    }
}
