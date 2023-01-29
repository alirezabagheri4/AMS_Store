namespace Domain.CustomerAggregate.Commands.Command
{
    public class CustomerCommand : Common.Command
    {
        public long Id { get;protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string NationalCode { get; protected set; }

        public string City { get; protected set; }

        public string DetailAddress { get; protected set; }

        public string EmailAddress { get; protected set; }
    }
}
