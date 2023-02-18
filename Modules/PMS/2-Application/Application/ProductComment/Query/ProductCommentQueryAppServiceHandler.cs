using Application.ProductComment.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.ProductComment.Interface;
using Domain.Common;

namespace Application.ProductComment.Query
{
    public class ProductCommentQueryAppServiceHandler: IProductCommentQueryAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IProductCommentQueryRepository _productCommentQueryRepository;
        private readonly IMediatorHandler _mediator;

        public ProductCommentQueryAppServiceHandler(IMapper mapper,
            IProductCommentQueryRepository productCommentQueryRepository,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productCommentQueryRepository = productCommentQueryRepository;
        }

        public async Task<IEnumerable<ProductCommentViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductCommentViewModel>>(await _productCommentQueryRepository.GetAll());
        }

        public async Task<ProductCommentViewModel> GetById(long id)
        {
            return _mapper.Map<ProductCommentViewModel>(await _productCommentQueryRepository.GetById(id));
        }
    }
}
