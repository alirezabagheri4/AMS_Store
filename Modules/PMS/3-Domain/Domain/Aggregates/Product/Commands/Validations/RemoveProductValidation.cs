using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.ProductComment.Commands.Validations;

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