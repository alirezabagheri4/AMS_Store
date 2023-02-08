using Domain.Aggregates.ProductAggregate.Commands.Command;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations
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
            ValidateProductGroupId();
        }
    }
}