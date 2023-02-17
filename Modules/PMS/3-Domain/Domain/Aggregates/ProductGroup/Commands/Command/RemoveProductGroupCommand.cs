using Domain.Aggregates.ProductGroup.Commands.Validations;

namespace Domain.Aggregates.ProductGroup.Commands.Command
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
