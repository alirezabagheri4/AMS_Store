using Api.Framework;
using Application.Interface;
using Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("PMS/ProductComment")]
    public class ProductCommentController : ApiController
    {
        private readonly IProductCommentCommandAppServiceHandler _ProductCommentCommandAppService;
        private readonly IProductCommentQueryAppServiceHandler _ProductCommandQueryAppService;

        public CustomerController(ICustomerCommandAppServiceHandler customerCommandAppService,
            ICustomerQueryAppServiceHandler customerQueryAppService)
        {
            _customerCommandAppService = customerCommandAppService;
            _customerQueryAppService = customerQueryAppService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> Get(RegisterNewCustomerCommand customer)
        {
            var result = await _customerQueryAppService.GetAll();
            return result;
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<CustomerViewModel> Get(long id)
        {
            var result = await _customerQueryAppService.GetById(id);
            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerViewModel customerViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _customerCommandAppService.Register(customerViewModel));
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerViewModel customerViewModel)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _customerCommandAppService.Update(customerViewModel));
        }

        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            return CustomResponse(await _customerCommandAppService.Remove(id));
        }
    }
}
