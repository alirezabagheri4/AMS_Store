using Domain.Aggregates.ProductGroup.Commands.Command;
using FluentValidation;

namespace Domain.Aggregates.ProductGroup.Commands.Validations
{
    public class ProductGroupValidation<T> : AbstractValidator<T> where T : ProductGroupCommand
    {
        protected void ValidateGroupName()
        {
            RuleFor(c => c.GroupName)
                .NotEmpty().WithMessage("Please ensure you have entered the GroupName")
                .Length(2, 50).WithMessage("The GroupName must have between 2 and 50 characters");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Description")
                .Length(2, 150).WithMessage("The Description must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                //.NotEqual(null).WithMessage("Please ensure you have entered the ProductGroupId")
                .NotEqual(0).WithMessage("Please ensure you have entered the ProductGroupId Not Equal 0")
                .Must(ValidateIdCode)
                ;
        }

        protected static bool ValidateIdCode(long id) => id > 0;
    }
}

