using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Framework;

namespace Domain.Events.EventModel
{
    public class CustomerUpdatedEvent : Event
    {
        public CustomerUpdatedEvent(long id, string name, string lastName,
            string phoneNumber, string nationalCode)
        {
            Id = id;
            FirstName = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            AggregateId = id;
        }
        public long Id { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }

        public string NationalCode { get; private set; }
    }
}