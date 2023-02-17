using Domain.Aggregates.CustomerAggregate.Commands.Validations;

namespace Domain.Aggregates.CustomerAggregate.Commands.Command
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        private readonly long? _detailCustomerInfoId;

        public UpdateCustomerCommand(long id, string firstName, string lastName,
            string phoneNumber, string nationalCode, /*long? detailCustomerInfoId*/
            string? city, string? detailAddress, string emailAddress)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.NationalCode = nationalCode;
            this.DetailAddress = detailAddress;
            this.City = city;
            this.EmailAddress = emailAddress;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}