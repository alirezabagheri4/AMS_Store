using Domain.Aggregates.ProductAggregate.Commands.Command;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations
{
    internal class RemoveProductValidation : ProductValidation<RemoveProductCommand>
    {
        public RemoveProductValidation()
        {
            ValidateId();
        }
    }
}