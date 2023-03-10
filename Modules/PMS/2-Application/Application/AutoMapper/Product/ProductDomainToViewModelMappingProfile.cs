using Application.ViewModel;
using AutoMapper;

namespace Application.AutoMapper.Product
{
    public class ProductDomainToViewModelMappingProfile : Profile
    {
        public ProductDomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Aggregates.Product.Models.Product, ProductViewModel>();
        }
    }
}
