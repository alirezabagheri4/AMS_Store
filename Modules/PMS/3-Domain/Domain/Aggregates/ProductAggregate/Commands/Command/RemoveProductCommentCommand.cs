using Domain.Aggregates.ProductAggregate.Commands.Validations;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class RemoveProductCommentCommand:ProductCommentCommand
    {
        public RemoveProductCommentCommand(long Id)
        {
            this.Id = Id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductCommentValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
