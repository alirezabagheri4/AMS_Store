namespace Domain.Aggregates.ProductComment.Commands.Command
{
    public class UpdateProductCommentCommand:ProductCommentCommand
    {
        public UpdateProductCommentCommand(long productId, long customerId, string commentText)
        {
            this.CustomerId = customerId;
            this.ProductId = productId;
            this.CommentText = commentText;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommentValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
