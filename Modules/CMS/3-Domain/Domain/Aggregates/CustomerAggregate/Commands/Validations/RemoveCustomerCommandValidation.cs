using Domain.Aggregates.CustomerAggregate.Commands.Command;

namespace Domain.Aggregates.CustomerAggregate.Commands.Validations
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}