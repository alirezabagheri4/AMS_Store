using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.Product.@enum;

namespace Application.AutoMapper.Product
{
    public class ProductViewModelToDomainMappingProfile : Profile
    {
        public ProductViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(c =>
                    new RegisterNewProductCommand(c.Name, (eProductState)c.ProductState, c.Price,
                    new Domain.Aggregates.Product.Models.ProductDescription
                    {
                        ProductDescriptionText = c.ProductDescriptionText
                    }, ConvertProductGroupModelToDomain(c.ProductGroup)
                    ));

            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(c =>
                    new UpdateProductCommand(c.Name, (eProductState)c.ProductState, c.Price,
                    new Domain.Aggregates.Product.Models.ProductDescription
                    {
                        ProductDescriptionText = c.ProductDescriptionText
                    },
                    ConvertProductGroupModelToDomain(c.ProductGroup)));

            CreateMap<ProductViewModel, RemoveProductCommand>()
                .ConstructUsing(c =>
                    new RemoveProductCommand(c.Id));
        }

        public Domain.Aggregates.ProductGroup.Models.ProductGroup ConvertProductGroupModelToDomain(ProductGroupViewModel viewModel)
        {
            return new Domain.Aggregates.ProductGroup.Models.ProductGroup(viewModel.GroupName, viewModel.Description);
        }
    }
}
