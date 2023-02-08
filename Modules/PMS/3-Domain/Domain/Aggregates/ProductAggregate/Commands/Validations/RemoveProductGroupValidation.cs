using Domain.Aggregates.ProductAggregate.Commands.Command;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations
{
    internal class RemoveProductGroupValidation : ProductGroupValidation<RemoveProductGroupCommand>
    {
        public RemoveProductGroupValidation()
        {
            ValidateId();
        }
    }
}