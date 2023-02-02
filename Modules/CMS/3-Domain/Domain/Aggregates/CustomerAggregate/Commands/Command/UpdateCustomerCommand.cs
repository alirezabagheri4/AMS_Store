using Domain.Aggregates.CustomerAggregate.Commands.Validations;

namespace Domain.Aggregates.CustomerAggregate.Commands.Command
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(long Id, string FirstName, string LastName,
            string PhoneNumber, string NationalCode, long? DetailCustomerInfoId,
            string City, string DetailAddress, string EmailAddress)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.NationalCode = NationalCode;
            this.DetailAddress = DetailAddress;
            this.City = City;
            this.EmailAddress = EmailAddress;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}