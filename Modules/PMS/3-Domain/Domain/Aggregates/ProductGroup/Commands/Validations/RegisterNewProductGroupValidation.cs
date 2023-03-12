using Domain.Aggregates.ProductGroup.Commands.Command;

namespace Domain.Aggregates.ProductGroup.Commands.Validations;

internal class RegisterNewProductGroupValidation : ProductGroupValidation<ProductGroupCommand>
{
    public RegisterNewProductGroupValidation()
    {
        ValidateGroupName();
        ValidateDescription();
    }
}