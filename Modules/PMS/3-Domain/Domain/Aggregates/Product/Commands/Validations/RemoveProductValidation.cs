using Domain.Aggregates.Product.Commands.Command;

namespace Domain.Aggregates.Product.Commands.Validations
{
    internal class RemoveProductValidation : ProductValidation<RemoveProductCommand>
    {
        public RemoveProductValidation()
        {
            ValidateId();
        }
    }
}