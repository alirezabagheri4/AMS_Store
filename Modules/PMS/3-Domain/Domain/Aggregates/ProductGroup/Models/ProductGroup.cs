using Domain.Aggregates.Product.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.ProductGroup.Models
{
    public class ProductGroup : BaseEntity, IAggregateRoot
    {
        public string GroupName { get; set; }

        public string Description { get; set; }

        public long ParentProductGroupId { get; set; } 

        public ICollection<Product.Models.Product> Products { get; set; }

        public ProductGroup(string groupName, string description)
        {
            GroupName = groupName;
            Description = description;
        }

        public ProductGroup(string groupName, string description,long id)
        {
            GroupName = groupName;
            Description = description;
            ParentProductGroupId = id;
        }

        public ProductGroup()
        {
        }
    }
}
