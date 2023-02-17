using Api.Framework;
using Application.ProductComment.Interface;
using Application.ViewModel;
using Domain.Aggregates.ProductComment.Commands.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.ProductComment
{
    [Route("PMS/ProductComment")]
    public class ProductCommentController : ApiController
    {
        private readonly IProductCommentCommandAppServiceHandler _ProductCommentCommandAppService;
        private readonly IProductCommentQueryAppServiceHandler _ProductCommandQueryAppService;

        public ProductCommentController(IProductCommentCommandAppServiceHandler productCommentCommandAppService,
            IProductCommentQueryAppServiceHandler productCommentQueryAppService)
        {
            _ProductCommentCommandAppService = productCommentCommandAppService;
            _ProductCommandQueryAppService = productCommentQueryAppService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProductCommentViewModel>> Get(RegisterNewProductCommentCommand customer)
        {
            var result = await _ProductCommandQueryAppService.GetAll();
            return result;
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ProductCommentViewModel> Get(long id)
        {
            var result = await _ProductCommandQueryAppService.GetById(id);
            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCommentViewModel customerViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _ProductCommentCommandAppService.Register(customerViewModel));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductCommentViewModel customerViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _ProductCommentCommandAppService.Update(customerViewModel));
        }

        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            return CustomResponse(await _ProductCommentCommandAppService.Remove(id));
        }
    }
}
