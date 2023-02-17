using Domain.Aggregates.Product.Interfaces.IRepository;
using Domain.Aggregates.ProductGroup.Commands.Command;
using Domain.Common;
using FluentValidation.Results;
using MediatR;

namespace Domain.Aggregates.ProductGroup.Commands.Handler
{
    public class ProductGroupCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductGroupCommand, ValidationResult>,
        IRequestHandler<UpdateProductGroupCommand, ValidationResult>,
        IRequestHandler<RemoveProductGroupCommand, ValidationResult>
    {
        private readonly IProductGroupCommandRepository _productGroupRepository;

        public ProductGroupCommandHandler(IProductGroupCommandRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewProductGroupCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productGroup = new Product.Models.ProductGroup(message.GroupName, message.Description);

            if (await _productGroupRepository.GetById(productGroup.Id) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            _productGroupRepository.Add(productGroup);

            return await Commit(_productGroupRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProductGroupCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productGroup = new Product.Models.ProductGroup(message.GroupName, message.Description);

            var existingCustomer = await _productGroupRepository.GetById(productGroup.Id);

            if (existingCustomer != null && existingCustomer.Id != productGroup.Id)
            {
                if (!existingCustomer.Equals(productGroup))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _productGroupRepository.Update(productGroup);

            return await Commit(_productGroupRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProductGroupCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productGroup = await _productGroupRepository.GetById(message.Id);

            if (productGroup is null)
            {
                AddError("The productGroup doesn't exists.");
                return ValidationResult;
            }

            _productGroupRepository.Remove(productGroup);

            return await Commit(_productGroupRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _productGroupRepository.Dispose();
        }
    }
}