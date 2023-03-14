namespace Domain.Aggregates.ProductGroup.Commands.Command
{
    public class ProductGroupCommand: Common.Command
    {
        public long Id { get; set; }

        public string GroupName { get; set; }

        public string Description { get; set; }

        public long ProductGroupId { get; set; }
    }
}
