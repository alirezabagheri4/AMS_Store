using Domain.Aggregates.ProductGroup.Commands.Command;

namespace Domain.Aggregates.ProductGroup.Commands.Validations
{
    internal class RemoveProductGroupValidation : ProductGroupValidation<RemoveProductGroupCommand>
    {
        public RemoveProductGroupValidation()
        {
            ValidateId();
        }
    }
}