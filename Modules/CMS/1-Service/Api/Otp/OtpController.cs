using Application.Interface;
using Application.ViewModel;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Otp
{
    public class OtpController
    {
        private readonly ICustomerCommandAppServiceHandler _customerCommandAppService;

        public OtpController(ICustomerCommandAppServiceHandler customerCommandAppService)
        {
            _customerCommandAppService = customerCommandAppService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> SendOtp(RegisterNewCustomerCommand customer)
        {
            var result = await _customerCommandAppService.Register(customer);
            return result;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> VerifyOtp(RegisterNewCustomerCommand customer)
        {
            var result = await _customerCommandAppService.Register(customer);
            return result;
        }
    }
}
