using Domain.Aggregates.ProductGroup.Commands.Validations;

namespace Domain.Aggregates.ProductGroup.Commands.Command
{
    public class RegisterNewProductGroupCommand:ProductGroupCommand
    {
        public RegisterNewProductGroupCommand(string groupName, string description,long id,long productGroupId)
        {
            this.Description = description;
            this.GroupName = groupName;
            this.Id = id;
            this.ProductGroupId= productGroupId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductGroupValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
