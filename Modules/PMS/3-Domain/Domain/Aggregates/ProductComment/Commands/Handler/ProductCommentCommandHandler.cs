using Domain.Aggregates.Product.Interfaces.IRepository;
using Domain.Aggregates.ProductComment.Commands.Command;
using Domain.Aggregates.ProductComment.Interface;
using Domain.Common;
using FluentValidation.Results;
using MediatR;

namespace Domain.Aggregates.ProductComment.Commands.Handler
{
    public class ProductCommentCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommentCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<UpdateProductCommentCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<RemoveProductCommentCommand, FluentValidation.Results.ValidationResult>
    {
        private readonly IProductCommentQueryRepository _productCommentQueryRepository;
        private readonly IProductCommentCommandRepository _productCommentCommandRepository;

        public ProductCommentCommandHandler(IProductCommentQueryRepository productCommentQueryRepository,
            IProductCommentCommandRepository productCommentCommandRepository)
        {
            _productCommentCommandRepository= productCommentCommandRepository;
            _productCommentQueryRepository= productCommentQueryRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewProductCommentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productComment = new Models.ProductComment(message.ProductId, message.CustomerId, message.CommentText);

            _productCommentCommandRepository.Add(productComment);

            return await Commit(_productCommentCommandRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProductCommentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productComment = new Models.ProductComment(message.ProductId, message.CustomerId, message.CommentText);

            var existingCustomer = await _productCommentQueryRepository.GetById(productComment.Id);

            if (existingCustomer != null && existingCustomer.Id != productComment.Id)
            {
                if (!existingCustomer.Equals(productComment))
                {
                    AddError("The customer productComment has already been taken.");
                    return ValidationResult;
                }
            }

            _productCommentCommandRepository.Update(productComment);

            return await Commit(_productCommentCommandRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProductCommentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = await _productCommentQueryRepository.GetById(message.Id);

            if (product is null)
            {
                AddError("The product doesn't exists.");
                return ValidationResult;
            }

            _productCommentCommandRepository.Remove(product);

            return await Commit(_productCommentCommandRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _productCommentCommandRepository.Dispose();
            _productCommentQueryRepository.Dispose();
        }
    }
}