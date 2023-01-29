using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Common;
using Domain.CustomerAggregate.Commands.Command;
using Domain.CustomerAggregate.Interfaces.IRepository;
using FluentValidation.Results;

namespace Application.CustomerService.Command
{
    public class CustomerAppServiceHandler : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler _mediator;

        public CustomerAppServiceHandler(IMapper mapper,
            ICustomerRepository customerRepository,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll());
        }

        public async Task<CustomerViewModel> GetById(long id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(id));
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

