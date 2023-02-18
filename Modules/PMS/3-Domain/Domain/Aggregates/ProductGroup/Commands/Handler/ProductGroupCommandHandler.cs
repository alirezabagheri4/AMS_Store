using Domain.Aggregates.Product.Interfaces.IRepository;
using Domain.Aggregates.ProductGroup.Commands.Command;
using Domain.Aggregates.ProductGroup.Interface;
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
        private readonly IProductGroupCommandRepository _productGroupCommandRepository;
        private readonly IProductGroupQueryRepository _productGroupQueryRepository;

        public ProductGroupCommandHandler(IProductGroupCommandRepository productGroupCommandRepository,
            IProductGroupQueryRepository productGroupQueryRepository)
        {
            _productGroupCommandRepository= productGroupCommandRepository;
            _productGroupQueryRepository = productGroupQueryRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewProductGroupCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productGroup = new Models.ProductGroup(message.GroupName, message.Description);

            if (await _productGroupQueryRepository.GetById(productGroup.Id) != null)
            {
                AddError("The customer e-mail has already been taken.");
                return ValidationResult;
            }

            _productGroupCommandRepository.Add(productGroup);

            return await Commit(_productGroupCommandRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProductGroupCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productGroup = new Models.ProductGroup(message.GroupName, message.Description);

            var existingCustomer = await _productGroupQueryRepository.GetById(productGroup.Id);

            if (existingCustomer != null && existingCustomer.Id != productGroup.Id)
            {
                if (!existingCustomer.Equals(productGroup))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            _productGroupCommandRepository.Update(productGroup);

            return await Commit(_productGroupCommandRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProductGroupCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productGroup = await _productGroupQueryRepository.GetById(message.Id);

            if (productGroup is null)
            {
                AddError("The productGroup doesn't exists.");
                return ValidationResult;
            }

            _productGroupCommandRepository.Remove(productGroup);

            return await Commit(_productGroupCommandRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _productGroupCommandRepository.Dispose();
            _productGroupCommandRepository.Dispose();
        }
    }
}