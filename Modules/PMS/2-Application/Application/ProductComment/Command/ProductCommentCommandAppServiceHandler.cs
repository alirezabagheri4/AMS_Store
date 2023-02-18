using Application.ProductComment.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.ProductComment.Commands.Command;
using Domain.Aggregates.ProductComment.Interface;
using Domain.Common;
using FluentValidation.Results;

namespace Application.ProductComment.Command
{
    public class ProductCommentCommandAppServiceHandler : IProductCommentCommandAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ProductCommentCommandAppServiceHandler(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Register(ProductCommentViewModel productCommentViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommentCommand>(productCommentViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ProductCommentViewModel productCommentViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommentCommand>(productCommentViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(long id)
        {
            var removeCommand = new RemoveProductCommentCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

