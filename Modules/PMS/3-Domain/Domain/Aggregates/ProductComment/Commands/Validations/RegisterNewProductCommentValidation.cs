using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.ProductComment.Commands.Command;

namespace Domain.Aggregates.ProductComment.Commands.Validations
{
    public class RegisterNewProductCommentValidation : ProductCommentValidation<RegisterNewProductCommentCommand>
    {
        public RegisterNewProductCommentValidation()
        {
            ValidateCommentText();
            ValidateCustomerId();
            ValidateProductId();
            ValidateId();
        }
    }
}