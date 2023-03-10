using Application.ViewModel;
using AutoMapper;

namespace Application.AutoMapper.ProductComment
{
    public class ProductCommentDomainToViewModelMappingProfile : Profile
    {
        public ProductCommentDomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Aggregates.ProductComment.Models.ProductComment, ProductCommentViewModel>();
        }
    }
}
