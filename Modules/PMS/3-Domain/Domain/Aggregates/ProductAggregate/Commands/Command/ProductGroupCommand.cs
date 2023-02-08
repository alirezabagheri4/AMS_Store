namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class ProductGroupCommand: Common.Command
    {
        public long Id { get; set; }

        public string GroupName { get; set; }

        public string Description { get; set; }
    }
}
