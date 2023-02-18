using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ProductService.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.ProductComment.Commands.Command;
using Domain.Common;
using FluentValidation.Results;

namespace Application.ProductService.Command
{
    public class ProductCommandAppServiceHandler: IProductCommandAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ProductCommandAppServiceHandler(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Register(ProductViewModel productViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(productViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(long id)
        {
            var removeCommand = new RemoveProductCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
