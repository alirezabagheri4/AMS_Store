using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Commands.Command;
using Domain.Aggregates.ProductAggregate.Interfaces.IRepository;
using Domain.Aggregates.ProductAggregate.Models;
using Domain.Common;
using FluentValidation.Results;
using MediatR;

namespace Domain.Aggregates.ProductAggregate.Commands.Handlers
{
    internal class ProductCommentHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommentCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<UpdateProductCommentCommand, FluentValidation.Results.ValidationResult>,
        IRequestHandler<RemoveProductCommentCommand, FluentValidation.Results.ValidationResult>
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public ProductCommentHandler(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewProductCommentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productComment = new ProductComment(message.ProductId, message.CustomerId, message.CommentText);

            _productCommentRepository.Add(productComment);

            return await Commit(_productCommentRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProductCommentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var productComment = new ProductComment(message.ProductId, message.CustomerId, message.CommentText);

            var existingCustomer = await _productCommentRepository.GetById(productComment.Id);

            if (existingCustomer != null && existingCustomer.Id != productComment.Id)
            {
                if (!existingCustomer.Equals(productComment))
                {
                    AddError("The customer productComment has already been taken.");
                    return ValidationResult;
                }
            }

            _productCommentRepository.Update(productComment);

            return await Commit(_productCommentRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProductCommentCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = await _productCommentRepository.GetById(message.Id);

            if (product is null)
            {
                AddError("The product doesn't exists.");
                return ValidationResult;
            }

            _productCommentRepository.Remove(product);

            return await Commit(_productCommentRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _productCommentRepository.Dispose();
        }
    }
}