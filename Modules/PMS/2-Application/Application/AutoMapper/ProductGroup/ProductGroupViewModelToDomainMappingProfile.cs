using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.ProductGroup.Commands.Command;

namespace Application.AutoMapper.ProductGroup;

public class ProductGroupViewModelToDomainMappingProfile : Profile
{
    public ProductGroupViewModelToDomainMappingProfile()
    {
        CreateMap<ProductGroupViewModel, RegisterNewProductGroupCommand>()
            .ConstructUsing(c =>
                new RegisterNewProductGroupCommand(c.GroupName, c.Description,c.Id,c.ProductGroupId));

        CreateMap<ProductGroupViewModel, UpdateProductGroupCommand>()
            .ConstructUsing(c =>
                new UpdateProductGroupCommand(c.GroupName, c.Description , c.Id));

        CreateMap<ProductGroupViewModel, RemoveProductGroupCommand>()
            .ConstructUsing(c =>
                new RemoveProductGroupCommand(c.Id));
    }
}