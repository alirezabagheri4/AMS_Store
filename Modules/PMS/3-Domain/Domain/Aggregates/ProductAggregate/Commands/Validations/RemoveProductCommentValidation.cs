using Domain.Aggregates.ProductAggregate.Commands.Command;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations
{
    internal class RemoveProductCommentValidation : ProductCommentValidation<RemoveProductCommentCommand>
    {
        public RemoveProductCommentValidation()
        {
            ValidateId();
        }
    }
}