using Domain.Aggregates.Product.Commands.Command;
using FluentValidation;

namespace Domain.Aggregates.Product.Commands.Validations
{
    public class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateProductName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the ProductName")
                .Length(2, 50).WithMessage("The ProductName must have between 2 and 50 characters");
        }

        protected void ValidateProductState()
        {
            RuleFor(c => c.ProductState)
                .NotNull().WithMessage("Please ensure you have entered the ProductState");
        }

        protected void ValidatePrice()
        {
            RuleFor(c => c.Price)
                .NotEmpty()
                .Must(ValidatePriceDetail)
                .WithMessage("The Price Is Invalid");
        }

        private bool ValidatePriceDetail(long arg) => arg > 0;

        protected void ValidateProductDescriptionText()
        {
            RuleFor(c => c.ProductDescription)
                .NotEmpty()
                .WithMessage("The ProductDescriptionText Is Invalid")
                .Length(2, 500).WithMessage("The ProductDescriptionText must have between 2 and 500 characters"); ;
        }

        protected void ValidateProductDescription_ProductId()
        {
            RuleFor(c => c.ProductGroupId)
                .NotNull()
                .WithMessage("The ProductDescription_ProductId Is Invalid - ProductDescription_ProductId NotNull");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(null)
                .NotEqual(0)
                .Must(ValidateIdCode);
        }

        //protected void ValidateProductGroup()
        //{
        //    RuleFor(c => c.ProductGroup)
        //        .NotEqual(null)
        //        .NotEqual(0)
        //        .Must(ValidateIdCode);
        //}

        protected static bool ValidateIdCode(long id) => id > 0;
    }
}

