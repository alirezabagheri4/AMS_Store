using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.CustomerAggregate.Commands.Command;

namespace Application.AutoMapper
{
    public class CustomerViewModelToDomainMappingProfile : Profile
    {
        public CustomerViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Id, c.FirstName,
                        c.LastName, c.PhoneNumber, c.NationalCode, c.City, c.DetailAddress, c.Email));

            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.FirstName,
                    c.LastName, c.PhoneNumber, c.NationalCode, c.City, c.DetailAddress, c.Email));

            CreateMap<CustomerViewModel, RemoveCustomerCommand>()
                .ConstructUsing(c => new RemoveCustomerCommand(c.Id));
        }
    }
}
