using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.@enum;
using Domain.Aggregates.ProductAggregate.Models;

namespace Domain.Aggregates.ProductAggregate.Event.EventModel
{
    public class ProductRegisteredEvent : Framework.Event
    {
        public ProductRegisteredEvent(string name, eProductState productState, long price,
            ProductDescription description,long productGroup)
        {
            Name = name;
            ProductState = productState;
            Price = price;
            ProductDescription = description;
            ProductGroupId = productGroup;
        }
        public string Name { get; set; }

        public eProductState ProductState { get; set; }

        public long Price { get; set; }

        public ProductDescription ProductDescription { get; set; }

        public long ProductGroupId { get; set; }
    }
}