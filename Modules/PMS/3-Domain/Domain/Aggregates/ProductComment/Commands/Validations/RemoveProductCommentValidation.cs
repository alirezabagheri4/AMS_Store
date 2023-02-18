using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.ProductComment.Commands.Command;

namespace Domain.Aggregates.ProductComment.Commands.Validations
{
    internal class RemoveProductCommentValidation : ProductCommentValidation<RemoveProductCommentCommand>
    {
        public RemoveProductCommentValidation()
        {
            ValidateId();
        }
    }
}