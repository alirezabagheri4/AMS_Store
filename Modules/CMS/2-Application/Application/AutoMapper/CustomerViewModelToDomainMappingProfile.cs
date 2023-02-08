using AutoMapper;

namespace Application.AutoMapper
{
    public class CustomerViewModelToDomainMappingProfile : Profile
    {
        public CustomerViewModelToDomainMappingProfile()
        {
            //CreateMap<CustomerViewModel, AddCustomerCommand>()
            //    .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            //CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            //    .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}
