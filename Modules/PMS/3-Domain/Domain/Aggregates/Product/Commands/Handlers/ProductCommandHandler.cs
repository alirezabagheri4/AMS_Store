using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.Product.Event.EventModel;
using Domain.Aggregates.Product.Interfaces.IRepository;
using Domain.Aggregates.Product.Interfaces.IRepository.ICommand;
using Domain.Aggregates.Product.Interfaces.IRepository.IQuery;
using Domain.Common;
using MediatR;

namespace Domain.Aggregates.Product.Commands.Handlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<UpdateProductCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<RemoveProductCommand, FluentValidation.Results.ValidationResult>
    {
        private readonly IProductCommandRepository _productRepository;
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductCommandHandler(IProductCommandRepository productRepository,IProductQueryRepository productQueryRepository)
        {
            _productRepository = productRepository;
            _productQueryRepository = productQueryRepository;
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(RegisterNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = new Models.Product(message.Name, message.ProductState, message.Price,
                message.ProductDescription.ProductDescriptionText, message.ProductGroupId);

            //if (await _productRepository.GetByName(product.name) != null)
            //{
            //    AddError("The product Name has already been taken.");
            //    return ValidationResult;
            //}

            product.AddDomainEvent(new ProductRegisteredEvent(product.Id,product.Name, product.ProductState, product.Price,
                product.ProductDescription,product.ProductGroup));

            _productRepository.Add(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = new Models.Product(message.Name, message.ProductState, message.Price,
                message.ProductDescription.ProductDescriptionText, message.ProductGroupId);

            var existingCustomer = await _productQueryRepository.GetById(message.Id);

            if (existingCustomer != null && existingCustomer.Id != message.Id)
            {
                if (!existingCustomer.Equals(product))
                {
                    AddError("The product has already been taken.");
                    return ValidationResult;
                }
            }

            product.AddDomainEvent(new ProductUpdatedEvent(product.Id, product.Name, product.ProductState, product.Price,
                product.ProductDescription, product.ProductGroup));

            _productRepository.Update(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<FluentValidation.Results.ValidationResult> Handle(RemoveProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = await _productQueryRepository.GetById(message.Id);

            if (product is null)
            {
                AddError("The customer doesn't exists.");
                return ValidationResult;
            }

            product.AddDomainEvent(new ProductRemovedEvent(message.Id));

            _productRepository.Remove(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}