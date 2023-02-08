using Domain.Aggregates.ProductAggregate.Commands.Validations;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class RegisterNewProductCommentCommand : ProductCommentCommand
    {
        public RegisterNewProductCommentCommand(long productId, long customerId, string commentText)
        {
            this.CustomerId = customerId;
            this.ProductId = productId;
            this.CommentText = commentText;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommentValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
