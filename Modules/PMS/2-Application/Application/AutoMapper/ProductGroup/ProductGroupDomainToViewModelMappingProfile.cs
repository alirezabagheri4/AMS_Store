using Application.ViewModel;
using AutoMapper;

namespace Application.AutoMapper.ProductGroup;

public class ProductGroupDomainToViewModelMappingProfile : Profile
{
    public ProductGroupDomainToViewModelMappingProfile()
    {
        CreateMap<Domain.Aggregates.ProductGroup.Models.ProductGroup, ProductGroupViewModel>();
    }
}