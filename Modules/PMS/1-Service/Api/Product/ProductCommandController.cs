using Api.Framework;
using Application.ProductService.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Product
{
    [Route("PMS/ProductCommand")]
    public class ProductCommandController : ApiController
    {
        private readonly IProductCommandAppServiceHandler _productCommandAppService;

        public ProductCommandController(IProductCommandAppServiceHandler productCommandAppService)
        {
            _productCommandAppService = productCommandAppService;
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
