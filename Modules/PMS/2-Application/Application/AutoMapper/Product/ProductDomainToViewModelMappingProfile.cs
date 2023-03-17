using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.Product.ValueObjects;

namespace Application.AutoMapper.Product
{
    public class ProductDomainToViewModelMappingProfile : Profile
    {
        public ProductDomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Aggregates.Product.Models.Product, ProductViewModel>();
            CreateMap<Domain.Aggregates.Product.Models.Product, ProductTitleViewModel>();
            CreateMap<ProductDto, ProductViewModel>();
        }
    }
}
