using Domain.Aggregates.CustomerAggregate.Commands.Command;

namespace Domain.Aggregates.CustomerAggregate.Commands.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidatePhoneNumber();
            ValidateEmail();
            ValidateId();
            ValidateNationalCode();
            ValidateCity();
            ValidateDetailAddress();
        }
    }
}