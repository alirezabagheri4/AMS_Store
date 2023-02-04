using Domain.Framework;

namespace Domain.Events.EventModel;

public class CustomerRemovedEvent : Event
{
    public CustomerRemovedEvent(long id)
    {
        Id = id;
        AggregateId = id;
    }

    public long Id { get; set; }
}