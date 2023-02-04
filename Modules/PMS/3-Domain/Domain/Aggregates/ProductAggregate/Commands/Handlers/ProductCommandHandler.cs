using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Commands.Command;
using Domain.Aggregates.ProductAggregate.Interfaces.IRepository;
using Domain.Aggregates.ProductAggregate.Models;
using Domain.Common;
using MediatR;

namespace Domain.Aggregates.ProductAggregate.Commands.Handlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<UpdateProductCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<RemoveProductCommand, FluentValidation.Results.ValidationResult>
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(RegisterNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = new Product(message.Name, message.ProductState, message.Price,
                message.ProductDescription.ProductDescriptionText, message.ProductGroupId);

            //if (await _customerRepository.GetByNationalCode(customer.NationalCode) != null)
            //{
            //    AddError("The customer e-mail has already been taken.");
            //    return ValidationResult;
            //}

            //customer.AddDomainEvent(new CustomerRegisteredEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _productRepository.Add(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = new Product(message.Name, message.ProductState, message.Price,
                message.ProductDescription.ProductDescriptionText, message.ProductGroupId);

            var existingCustomer = await _productRepository.GetById(message.Id);

            if (existingCustomer != null && existingCustomer.Id != message.Id)
            {
                if (!existingCustomer.Equals(product))
                {
                    AddError("The product has already been taken.");
                    return ValidationResult;
                }
            }

            customer.AddDomainEvent(new CustomerUpdatedEvent(customer.Id, customer.Name, customer.Email, customer.BirthDate));

            _productRepository.Update(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(RemoveProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _customerRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            //customer.AddDomainEvent(new CustomerRemovedEvent(message.Id));

            _customerRepository.Remove(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}