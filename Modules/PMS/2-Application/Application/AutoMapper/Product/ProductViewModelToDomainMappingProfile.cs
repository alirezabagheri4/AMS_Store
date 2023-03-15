using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Models;

namespace Application.AutoMapper.Product
{
    public class ProductViewModelToDomainMappingProfile : Profile
    {
        public ProductViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(c =>
                    new RegisterNewProductCommand(c.Name, (eProductState)c.ProductState, c.Price,
                   c.ProductDescriptionText,c.ProductGroupId 
                    ));

            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(c =>
                    new UpdateProductCommand(c.Name, (eProductState)c.ProductState, c.Price,
                    c.ProductDescriptionText,c.ProductGroupId
                    ));

            CreateMap<ProductViewModel, RemoveProductCommand>()
                .ConstructUsing(c =>
                    new RemoveProductCommand(c.Id));
        }
    }
}
