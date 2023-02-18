using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.ProductComment.Commands.Command;

namespace Domain.Aggregates.ProductComment.Commands.Validations
{
    public class UpdateProductCommentValidation : ProductCommentValidation<UpdateProductCommentCommand>
    {
        public UpdateProductCommentValidation()
        {
            ValidateCommentText();
            ValidateCustomerId();
            ValidateProductId();
            ValidateId();
        }
    }
}