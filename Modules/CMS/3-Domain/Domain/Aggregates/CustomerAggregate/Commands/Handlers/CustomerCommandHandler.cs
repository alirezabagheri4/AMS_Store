using Domain.Common;
using MediatR;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.CustomerAggregate.Models;

namespace Domain.Aggregates.CustomerAggregate.Commands.Handlers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<UpdateCustomerCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<RemoveCustomerCommand, FluentValidation.Results.ValidationResult>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public CustomerCommandHandler(ICustomerCommandRepository customerCommandRepository,ICustomerQueryRepository customerQueryRepository)
        {
            _customerCommandRepository = customerCommandRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.LastName, message.FirstName, message.PhoneNumber, message.NationalCode);
            var address = new Address(message.City, message.DetailAddress);
            customer.Address = address;
            if (await _customerQueryRepository.GetByNationalCode(customer.NationalCode) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            //customer.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _customerCommandRepository.Add(customer);

            return await Commit(_customerCommandRepository.UnitOfWork);
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.LastName, message.FirstName, message.PhoneNumber, message.NationalCode);
            var address = new Address(message.City, message.DetailAddress);
            customer.Address = address;

            var existingCustomer = await _customerQueryRepository.GetById(customer.Id);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            //customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _customerCommandRepository.Update(customer);

            return await Commit(_customerCommandRepository.UnitOfWork);
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerQueryRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            //customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            _customerCommandRepository.Remove(customer);

            return await Commit(_customerCommandRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _customerCommandRepository.Dispose();
            _customerCommandRepository.Dispose();

        }
    }
}