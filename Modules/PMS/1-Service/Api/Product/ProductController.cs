using Api.Framework;
using Application.ProductService.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Product
{
    [Route("PMS/Product")]
    public class ProductController : ApiController
    {
        private readonly IProductCommandAppServiceHandler _productCommandAppService;
        private readonly IProductQueryAppServiceHandler _productQueryAppService;

        public ProductController(IProductCommandAppServiceHandler productCommandAppService,
            IProductQueryAppServiceHandler productQueryAppService)
        {
            _productCommandAppService = productCommandAppService;
            _productQueryAppService = productQueryAppService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
           return await _productQueryAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ProductViewModel> Get(long id)
        {
            var result = await _productQueryAppService.GetById(id);
            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel productViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _productCommandAppService.Register(productViewModel));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductViewModel productViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _productCommandAppService.Update(productViewModel));
        }

        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            return CustomResponse(await _productCommandAppService.Remove(id));
        }
    }
}
