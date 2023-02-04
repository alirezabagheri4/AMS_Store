using Domain.Aggregates.ProductAggregate.@enum;
using Domain.Aggregates.ProductAggregate.Models;

namespace Domain.Aggregates.ProductAggregate.Event.EventModel
{
    public class ProductUpdatedEvent : Framework.Event
    {
        public ProductUpdatedEvent(long id, string name, eProductState productState, long price,
            ProductDescription description, long productGroup)
        {
            Name = name;
            ProductState = productState;
            Price = price;
            ProductDescription = description;
            ProductGroupId = productGroup;
            Id = id;
        }
        public long Id { get; set; }

        public string Name { get; set; }

        public eProductState ProductState { get; set; }

        public long Price { get; set; }

        public ProductDescription ProductDescription { get; set; }

        public long ProductGroupId { get; set; }
    }
}