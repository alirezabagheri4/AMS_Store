using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ProductService.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.Product.Interfaces.IRepository.IQuery;
using Domain.Aggregates.ProductComment.Interface;
using Domain.Common;

namespace Application.ProductService.Query
{
    public class ProductQueryAppServiceHandler: IProductQueryAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMediatorHandler _mediator;

        public ProductQueryAppServiceHandler(IMapper mapper,
            IProductQueryRepository productQueryRepository,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productQueryRepository = productQueryRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProduct()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productQueryRepository.GetAll());
        }

        public async Task<IEnumerable<ProductTitleViewModel>> GetAllProductTitle()
        {
            return _mapper.Map<IEnumerable<ProductTitleViewModel>>(await _productQueryRepository.GetAllProductTitle());
        }

        public async Task<ProductViewModel> GetProductById(long id)
        {
            return _mapper.Map<ProductViewModel>(await _productQueryRepository.GetById(id));
        }

        public async Task<IEnumerable<ProductViewModel>> GetActiveProduct()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productQueryRepository.GetActiveProduct());
        }

        public async Task<IEnumerable<ProductTitleViewModel>> GetActiveProductTitle()
        {
            return _mapper.Map<IEnumerable<ProductTitleViewModel>>(await _productQueryRepository.GetActiveProductTitle());
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductByProductState()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productQueryRepository.GetProductByProductState());

        }

        public async Task<IEnumerable<ProductTitleViewModel>> GetProductTitleByProductState()
        {
            return _mapper.Map<IEnumerable<ProductTitleViewModel>>(await _productQueryRepository.GetProductTitleByProductState());
        }

        public async Task<ProductTitleViewModel> GetProductTitleById(long id)
        {
            return _mapper.Map<ProductTitleViewModel>(await _productQueryRepository.GetProductTitleById(id));
        }
    }
}
