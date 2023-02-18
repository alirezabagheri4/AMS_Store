using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.ProductComment.Commands.Command;

namespace Domain.Aggregates.ProductComment.Commands.Validations
{
    public class RegisterNewProductCommandValidation : ProductCommentValidation<RegisterNewProductCommentCommand>
    {
        public RegisterNewProductCommandValidation()
        {
            ValidateCommentText();
            ValidateCustomerId();
            ValidateProductId();
            ValidateId();
        }
    }
}