using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.ProductComment.Commands.Command;

namespace Application.AutoMapper.ProductComment
{
    public class ProductCommentViewModelToDomainMappingProfile : Profile
    {
        public ProductCommentViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCommentViewModel, RegisterNewProductCommentCommand>()
                .ConstructUsing(c =>
                    new RegisterNewProductCommentCommand(c.ProductId, c.CustomerId, c.CommentText));

            CreateMap<ProductCommentViewModel, UpdateProductCommentCommand>()
                .ConstructUsing(c =>
                    new UpdateProductCommentCommand(c.ProductId, c.CustomerId, c.CommentText));

            CreateMap<ProductCommentViewModel, RemoveProductCommentCommand>()
                .ConstructUsing(c =>
                    new RemoveProductCommentCommand(c.Id));
        }
    }
}
