using Domain.Aggregates.Product.Commands.Validations;
using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Models;

namespace Domain.Aggregates.Product.Commands.Command
{
    public class UpdateProductCommand:ProductCommand
    {
        public UpdateProductCommand(string name, eProductState productState,
            long price, string productDescription, long productGroupId)
        {
            this.Name = name;
            this.ProductState = productState;
            this.Price = price;
            this.ProductDescription = productDescription;
            this.ProductGroupId = ProductGroupId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
