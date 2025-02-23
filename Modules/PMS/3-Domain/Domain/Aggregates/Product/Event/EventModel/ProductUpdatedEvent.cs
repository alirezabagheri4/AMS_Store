﻿using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Models;

namespace Domain.Aggregates.Product.Event.EventModel
{
    public class ProductUpdatedEvent : Framework.Event
    {
        public ProductUpdatedEvent(long id, string name, eProductState productState, long price,
            ProductDescription description, ProductGroup.Models.ProductGroup productGroup)
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

        public ProductGroup.Models.ProductGroup ProductGroupId { get; set; }
    }
}