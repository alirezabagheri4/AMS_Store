using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ProductGroup.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.ProductComment.Interface;
using Domain.Common;

namespace Application.ProductGroup.Query
{
    public class ProductGroupQueryAppServiceHandler: IProductGroupQueryAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IProductCommentQueryRepository _productGroupQueryRepository;
        private readonly IMediatorHandler _mediator;

        public ProductGroupQueryAppServiceHandler(IMapper mapper,
            IProductCommentQueryRepository productGroupQueryRepository,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productGroupQueryRepository = productGroupQueryRepository;
        }

        public async Task<IEnumerable<ProductGroupViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductGroupViewModel>>(await _productGroupQueryRepository.GetAll());
        }

        public async Task<ProductCommentViewModel> GetById(long id)
        {
            return _mapper.Map<ProductCommentViewModel>(await _productGroupQueryRepository.GetById(id));
        }
    }
}
