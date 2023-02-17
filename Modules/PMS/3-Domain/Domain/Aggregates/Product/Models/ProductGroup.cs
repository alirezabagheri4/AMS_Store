using Domain.Aggregates.Product.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.Product.Models
{
    public class ProductGroup : BaseEntity, IAggregateRoot
    {
        public string GroupName { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }

        public ProductGroup(string groupName,string description)
        {
            GroupName=groupName;
            Description=description;
        }

        public ProductGroup()
        {
        }
    }
}
