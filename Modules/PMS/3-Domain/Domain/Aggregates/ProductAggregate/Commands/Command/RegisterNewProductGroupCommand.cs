using Domain.Aggregates.ProductAggregate.Commands.Validations;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class RegisterNewProductGroupCommand:ProductGroupCommand
    {
        public RegisterNewProductGroupCommand(string groupName, string description)
        {
            this.Description = description;
            this.GroupName = groupName;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductGroupValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
