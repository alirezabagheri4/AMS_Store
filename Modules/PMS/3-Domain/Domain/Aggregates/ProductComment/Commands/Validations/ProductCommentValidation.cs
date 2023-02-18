using Domain.Aggregates.ProductComment.Commands.Command;
using FluentValidation;

namespace Domain.Aggregates.ProductComment.Commands.Validations
{
    public class ProductCommentValidation<T> : AbstractValidator<T> where T : ProductCommentCommand
    {
        protected void ValidateCommentText()
        {
            RuleFor(c => c.CommentText)
                .NotEmpty().WithMessage("Please ensure you have entered the CommentText")
                .Length(2, 50).WithMessage("The ProductName must have between 2 and 50 characters");
        }

        protected void ValidateProductId()
        {
            RuleFor(c => c.ProductId)
                .NotEqual(null)
                .NotEqual(0)
                .Must(ValidateIdCode);
        }

        protected void ValidateCustomerId()
        {
            RuleFor(c => c.CustomerId)
                .NotEqual(null)
                .NotEqual(0)
                .Must(ValidateIdCode);
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(null)
                .NotEqual(0)
                .Must(ValidateIdCode);
        }

        protected static bool ValidateIdCode(long id) => id > 0;
    }
}

