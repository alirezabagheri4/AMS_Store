using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.CustomerAggregate.Models;
using Domain.Aggregates.OtpAggregate.Models;

namespace Application.AutoMapper
{
    public class CustomerDomainToViewModelMappingProfile : Profile
    {
        public CustomerDomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<SendOtpResponse, SendOtpResponseViewModel>();
        }
    }
}
