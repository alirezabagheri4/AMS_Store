namespace Domain.Aggregates.CustomerAggregate.Models
{
    public class Address
    {
        public long Id { get; private set; }

        public string City { get; private set; }

        public string DetailAddress { get; private set; }

        public Address(string city, string DetailAddress)
        {
            City = city;
            this.DetailAddress = DetailAddress;
        }

        public Address()
        {

        }
    }
}
