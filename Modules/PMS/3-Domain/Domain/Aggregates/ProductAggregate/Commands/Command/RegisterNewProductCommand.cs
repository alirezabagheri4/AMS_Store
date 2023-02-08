using Domain.Aggregates.ProductAggregate.Commands.Validations;
using Domain.Aggregates.ProductAggregate.@enum;
using Domain.Aggregates.ProductAggregate.Models;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand(string name, eProductState productState,
            long price, ProductDescription productDescription, long ProductGroupId)
        {
            this.Name = name;
            this.ProductState = productState;
            this.Price = price;
            this.ProductDescription = productDescription;
            this.ProductGroupId = ProductGroupId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}