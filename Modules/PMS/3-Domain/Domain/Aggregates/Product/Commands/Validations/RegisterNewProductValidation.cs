using Domain.Aggregates.Product.Commands.Command;

namespace Domain.Aggregates.Product.Commands.Validations
{
    public class RegisterNewProductValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductValidation()
        {
            ValidateProductName();
            ValidateProductState();
            ValidatePrice();
            ValidateProductDescriptionText();
            ValidateProductDescription_ProductId();
            //ValidateId();
        }
    }
}