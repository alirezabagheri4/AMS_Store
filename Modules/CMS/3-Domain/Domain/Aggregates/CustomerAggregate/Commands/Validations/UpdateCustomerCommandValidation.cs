using Domain.Aggregates.CustomerAggregate.Commands.Command;

namespace Domain.Aggregates.CustomerAggregate.Commands.Validations
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            {
                ValidateFirstName();
                ValidateLastName();
                ValidatePhoneNumber();
                ValidateEmail();
                ValidateNationalCode();
                ValidateCity();
                ValidateDetailAddress();
            }
        }
    }
}