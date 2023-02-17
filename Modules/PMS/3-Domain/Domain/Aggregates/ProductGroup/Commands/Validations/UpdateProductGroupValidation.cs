using Domain.Aggregates.ProductGroup.Commands.Command;

namespace Domain.Aggregates.ProductGroup.Commands.Validations
{
    public class UpdateProductGroupValidation:ProductGroupValidation<ProductGroupCommand>
    {
        public UpdateProductGroupValidation()
        {
            ValidateGroupName();
            ValidateDescription();
            ValidateId();
        }
    }
}
