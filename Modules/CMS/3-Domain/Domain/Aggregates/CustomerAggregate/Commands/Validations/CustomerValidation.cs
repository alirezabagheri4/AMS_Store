using DNTPersianUtils.Core;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using FluentValidation;

namespace Domain.Aggregates.CustomerAggregate.Commands.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please ensure you have entered the FirstName")
                .Length(2, 50).WithMessage("The FirstName must have between 2 and 50 characters");
        }

        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please ensure you have entered the LastName")
                .Length(2, 50).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidatePhoneNumber()
        {
            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .Must(ValidatePhoneNumberDetail)
                .WithMessage("The PhoneNumber Is Invalid");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("The EmailAddress Is Invalid");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(null)
                .NotEqual(0)
                .Must(ValidateIdCode);
        }

        protected void ValidateNationalCode()
        {
            RuleFor(c => c.NationalCode)
                .NotEmpty()
                .Must(ValidateNationalCodeDetail);
        }

        protected void ValidateCity()
        {
            RuleFor(c => c.NationalCode)
                .MaximumLength(200).WithMessage("The City must have less  200 characters");

        }

        protected void ValidateDetailAddress()
        {
            RuleFor(c => c.DetailAddress)
                .MaximumLength(200).WithMessage("The Address must have less  200 characters");
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }

        protected static bool ValidatePhoneNumberDetail(string phoneNumber)
        {
            //return phoneNumber.IsValidIranianPhoneNumber();
            return true;
        }
       
        protected static bool ValidateNationalCodeDetail(string nationalCode) => nationalCode.IsValidIranianNationalCode();
        protected static bool ValidateIdCode(long id) => id > 0;
    }
}

