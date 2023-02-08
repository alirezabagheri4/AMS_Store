using Domain.Aggregates.ProductAggregate.Commands.Command;
using FluentValidation;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations
{
    public class ProductCommentValidation<T> : AbstractValidator<T> where T : ProductCommentCommand
    {
        protected void ValidateCustomerId()
        {
            RuleFor(c => c.CustomerId)
                .NotEqual(null).WithMessage("Please ensure you have entered the CustomerId")
                .NotEqual(0).WithMessage("Please ensure you have entered the CustomerId")
                .Must(ValidateIdCode);
        }

        protected void ValidateProductId()
        {
            RuleFor(c => c.ProductId)
                .NotEqual(null).WithMessage("Please ensure you have entered the ProductId")
                .NotEqual(0).WithMessage("Please ensure you have entered the ProductId")
                .Must(ValidateIdCode);
        }

        protected void ValidateProductName()
        {
            RuleFor(c => c.CommentText)
                .NotEmpty().WithMessage("Please ensure you have entered the CommentText")
                .Length(2, 100).WithMessage("The CommentText must have between 2 and 100 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(null).WithMessage("Please ensure you have entered the Id")
                .NotEqual(0).WithMessage("Please ensure you have entered the Id")
                .Must(ValidateIdCode);
        }

        protected static bool ValidateIdCode(long id) => id > 0;
    }
}

