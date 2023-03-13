using Domain.Aggregates.ProductGroup.Commands.Validations;

namespace Domain.Aggregates.ProductGroup.Commands.Command
{
    public class UpdateProductGroupCommand : ProductGroupCommand
    {
        public UpdateProductGroupCommand(string groupName, string description, long Id)
        {
            this.Description = description;
            this.GroupName = groupName;
            this.Id = Id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductGroupValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
