using Domain.Aggregates.ProductAggregate.Commands.Command;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations;

public class RegisterNewProductCommentValidation : ProductCommentValidation<RegisterNewProductCommentCommand>
{
    public RegisterNewProductCommentValidation()
    {
        ValidateCustomerId();
        ValidateProductId();
        ValidateId();
        ValidateProductName();
    }
}