using Domain.Aggregates.ProductAggregate.Commands.Validations;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class RemoveProductGroupCommand:ProductGroupCommand
    {
        public RemoveProductGroupCommand(long id)
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductGroupValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
