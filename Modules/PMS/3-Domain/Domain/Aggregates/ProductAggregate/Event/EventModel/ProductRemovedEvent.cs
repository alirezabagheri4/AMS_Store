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