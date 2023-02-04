﻿using Domain.Common;
using MediatR;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.CustomerAggregate.Models;
using Domain.Events.EventModel;

namespace Domain.Aggregates.CustomerAggregate.Commands.Handlers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<UpdateCustomerCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<RemoveCustomerCommand, FluentValidation.Results.ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(RegisterNewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.LastName, message.FirstName, message.PhoneNumber, message.NationalCode);
            var address = new Address(message.City, message.DetailAddress);
            customer.Address = address;
            if (await _customerRepository.GetByNationalCode(customer.NationalCode) != null)
            {
                AddError("The customer NationalCode has already been taken.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.FirstName, 
                customer.LastName, customer.PhoneNumber,customer.NationalCode));

            _customerRepository.Add(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(UpdateCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Customer(message.LastName, message.FirstName, message.PhoneNumber, message.NationalCode);
            var address = new Address(message.City, message.DetailAddress);
            customer.Address = address;

            var existingCustomer = await _customerRepository.GetById(customer.Id);

            if (existingCustomer != null && existingCustomer.Id != customer.Id)
            {
                if (!existingCustomer.Equals(customer))
                {
                    AddError("The customer .. has already been taken.");
                    return ValidationResult;
                }
            }

            customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.FirstName,
                customer.LastName, customer.PhoneNumber, customer.NationalCode));
            _customerRepository.Update(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(RemoveCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            _customerRepository.Remove(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}