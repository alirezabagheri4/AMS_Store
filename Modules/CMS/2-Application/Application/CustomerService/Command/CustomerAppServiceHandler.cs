using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Common;
using FluentValidation.Results;

namespace Application.CustomerService.Command
{
    public class CustomerAppServiceHandler : ICustomerCommandAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly IMediatorHandler _mediator;

        public CustomerAppServiceHandler(IMapper mapper,
            ICustomerCommandRepository customerCommandRepository,
            ICustomerQueryRepository customerQueryRepository,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _customerCommandRepository = customerCommandRepository;
            _mediator = mediator;
            _customerQueryRepository= customerQueryRepository;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerQueryRepository.GetAll());
        }

        public async Task<CustomerViewModel> GetById(long id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerQueryRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(CustomerViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(CustomerViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCustomerCommand>(customerViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(long id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

