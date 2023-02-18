using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ProductService.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.ProductComment.Interface;
using Domain.Common;

namespace Application.ProductService.Query
{
    public class ProductQueryAppServiceHandler: IProductQueryAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IProductCommentQueryRepository _productQueryRepository;
        private readonly IMediatorHandler _mediator;

        public ProductQueryAppServiceHandler(IMapper mapper,
            IProductCommentQueryRepository productQueryRepository,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productQueryRepository = productQueryRepository;
        }

        public async Task<IEnumerable<ProductGroupViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductGroupViewModel>>(await _productQueryRepository.GetAll());
        }

        public async Task<ProductCommentViewModel> GetById(long id)
        {
            return _mapper.Map<ProductCommentViewModel>(await _productQueryRepository.GetById(id));
        }
    }
}
