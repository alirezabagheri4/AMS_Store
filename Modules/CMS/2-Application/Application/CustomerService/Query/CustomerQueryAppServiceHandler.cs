using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Common;

namespace Application.CustomerService.Query
{
    public class CustomerQueryAppServiceHandler : ICustomerQueryAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public CustomerQueryAppServiceHandler(IMapper mapper,
            ICustomerQueryRepository customerQueryRepository)
        {
            _mapper = mapper;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerQueryRepository.GetAll());
        }

        public async Task<CustomerViewModel> GetById(long id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerQueryRepository.GetById(id));
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
