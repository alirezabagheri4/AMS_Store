using Domain.Aggregates.CustomerAggregate.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.CustomerAggregate.Models
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }

        public string NationalCode { get; private set; }

        public int IsChange { get; private set; }

        public Address? Address { get; set; }

        public Customer(string lastName, string firstName, string phoneNumber, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            SubmitDate = DateTime.Now;
        }

        public Customer()
        {

        }
    }
}
