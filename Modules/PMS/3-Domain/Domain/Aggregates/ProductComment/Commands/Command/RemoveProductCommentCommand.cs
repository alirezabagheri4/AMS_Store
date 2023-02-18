using Domain.Aggregates.ProductComment.Commands.Validations;

namespace Domain.Aggregates.ProductComment.Commands.Command
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
