using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.ProductAggregate.Event.EventModel
{
    public class ProductRemovedEvent : Framework.Event
    {
        public ProductRemovedEvent(long id)
        {
            Id = id;
            AggregateId = id;
        }

        public long Id { get; set; }
    }
}