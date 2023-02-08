using Domain.Aggregates.ProductAggregate.Commands.Validations;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class UpdateProductGroupCommand : ProductGroupCommand
    {
        public UpdateProductGroupCommand(string groupName, string description)
        {
            this.Description = description;
            this.GroupName = groupName;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductGroupValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
