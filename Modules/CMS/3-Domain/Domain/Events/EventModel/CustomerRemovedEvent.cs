using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Framework;

namespace Domain.Events.EventModel
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(long id)
        {
            Id = id;
            AggregateId = id;
        }

        public long Id { get; set; }
    }
}