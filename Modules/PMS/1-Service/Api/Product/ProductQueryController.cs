using Api.Framework;
using Application.ProductService.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Product
{
    [Route("PMS/ProductQuery")]
    public class ProductQueryController : ApiController
    {
        private readonly IProductQueryAppServiceHandler _productQueryAppService;

        public ProductQueryController(IProductCommandAppServiceHandler productCommandAppService,
            IProductQueryAppServiceHandler productQueryAppService)
        {
            _productQueryAppService = productQueryAppService;
        }

        [AllowAnonymous]
        [HttpGet("GetAllProduct")]
        public async Task<IEnumerable<ProductViewModel>> GetAllProduct()
        {
            return await _productQueryAppService.GetAllProduct();
        }

        [AllowAnonymous]
        [HttpGet("GetAllProductTitle")]
        public async Task<IEnumerable<ProductTitleViewModel>> GetAllProductTitle()
        {
            return await _productQueryAppService.GetAllProductTitle();
        }

        [AllowAnonymous]
        [HttpGet("GetProductById/{id:long}")]
        public async Task<ProductViewModel> GetProductById(long id)
        {
            var result = await _productQueryAppService.GetProductById(id);
            return result;
        }

        [AllowAnonymous]
        [HttpGet("GetProductTitleById/{id:long}")]
        public async Task<ProductTitleViewModel> GetProductTitleById(long id)
        {
            var result = await _productQueryAppService.GetProductTitleById(id);
            return result;
        }

        [AllowAnonymous]
        [HttpGet("GetActiveProduct")]
        public async Task<IEnumerable<ProductViewModel>> GetActiveProduct()
        {
            return await _productQueryAppService.GetActiveProduct();
        }

        [AllowAnonymous]
        [HttpGet("GetActiveProductTitle")]
        public async Task<IEnumerable<ProductTitleViewModel>> GetActiveProductTitle()
        {
            return await _productQueryAppService.GetActiveProductTitle();
        }

        [AllowAnonymous]
        [HttpGet("GetProductByProductState")]
        public async Task<IEnumerable<ProductViewModel>> GetProductByProductState()
        {
            return await _productQueryAppService.GetProductByProductState();
        }

        [AllowAnonymous]
        [HttpGet("GetProductTitleByProductState")]
        public async Task<IEnumerable<ProductTitleViewModel>> GetProductTitleByProductState()
        {
            return await _productQueryAppService.GetProductTitleByProductState();
        }

        //[AllowAnonymous]
        //[HttpGet("GetProductByName")]
        //public async Task<IEnumerable<ProductViewModel>> GetAllActiveProduct()
        //{
        //    return await _productQueryAppService.GetAllProductTitle();
        //}

        //[AllowAnonymous]
        //[HttpGet("GetProductTitleByName")]
        //public async Task<IEnumerable<ProductViewModel>> GetAllActiveProduct()
        //{
        //    return await _productQueryAppService.GetAllProductTitle();
        //}

        //[AllowAnonymous]
        //[HttpGet("GetProductAdvancedSearch")]
        //public async Task<IEnumerable<ProductViewModel>> GetAllActiveProduct()
        //{
        //    return await _productQueryAppService.GetAllProductTitle();
        //}

        //[AllowAnonymous]
        //[HttpGet("GetProductTitleAdvancedSearch")]
        //public async Task<IEnumerable<ProductViewModel>> GetAllActiveProduct()
        //{
        //    return await _productQueryAppService.GetAllProductTitle();
        //}
    }
}
