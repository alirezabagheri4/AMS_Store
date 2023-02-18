using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ProductGroup.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.ProductComment.Commands.Command;
using Domain.Aggregates.ProductGroup.Commands.Command;
using Domain.Common;
using FluentValidation.Results;

namespace Application.ProductGroup.Command
{
    public class ProductGroupCommandAppServiceHandler: IProductGroupCommandAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public ProductGroupCommandAppServiceHandler(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Register(ProductGroupViewModel productGroupViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductGroupCommand>(productGroupViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ProductGroupViewModel productGroupViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductGroupCommand>(productGroupViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(long id)
        {
            var removeCommand = new RemoveProductGroupCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
