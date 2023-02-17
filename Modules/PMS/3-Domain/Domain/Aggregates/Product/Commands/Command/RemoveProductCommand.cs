using Domain.Aggregates.Product.Commands.Validations;

namespace Domain.Aggregates.Product.Commands.Command
{
    public class RemoveProductCommand:ProductCommand
    {
        public RemoveProductCommand(long productId)
        {
            this.Id = Id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
