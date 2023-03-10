using Domain.Aggregates.Product.Commands.Command;

namespace Domain.Aggregates.Product.Commands.Validations
{
    public class UpdateProductValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            ValidateProductName();
            ValidateProductState();
            ValidatePrice();
            ValidateProductDescriptionText();
            ValidateProductDescription_ProductId();
            ValidateId();
        }
    }
}