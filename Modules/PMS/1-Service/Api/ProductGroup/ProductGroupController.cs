using Api.Framework;
using Application.ProductGroup.Interface;
using Application.ViewModel;
using Domain.Aggregates.ProductGroup.Commands.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProductGroup
{
    [Route("PMS-ProductGroup")]
    public class ProductGroupController : ApiController
    {
        private readonly IProductGroupCommandAppServiceHandler _productGroupCommandAppService;
        private readonly IProductGroupQueryAppServiceHandler _productGroupQueryAppService;

        public ProductGroupController(IProductGroupCommandAppServiceHandler productGroupCommandAppService,
            IProductGroupQueryAppServiceHandler productGroupQueryAppService)
        {
            _productGroupCommandAppService = productGroupCommandAppService;
            _productGroupQueryAppService = productGroupQueryAppService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProductGroupViewModel>> Get()
        {
            var result = await _productGroupQueryAppService.GetAll();
            return result;
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ProductGroupViewModel> Get(long id)
        {
           return await _productGroupQueryAppService.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("GetListSubProductGroup/{id:guid}")]
        public async Task<IEnumerable<ProductGroupViewModel>> GetListSubProductGroup(long id)
        {
            return await _productGroupQueryAppService.GetListSubProductGroupById(id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductGroupViewModel productGroupViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _productGroupCommandAppService.Register(productGroupViewModel));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductGroupViewModel productGroupViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _productGroupCommandAppService.Update(productGroupViewModel));
        }

        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            return CustomResponse(await _productGroupCommandAppService.Remove(id));
        }
    }
}
