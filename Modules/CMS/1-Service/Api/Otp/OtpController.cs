using Application.Interface;
using Application.ViewModel;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Otp
{
    public class OtpController
    {
        private readonly IOtpAppServiceHandler _otpAppServiceHandler;

        public OtpController(IOtpAppServiceHandler otpAppServiceHandler)
        {
            _otpAppServiceHandler = otpAppServiceHandler;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<SendOtpResponseViewModel> SendOtp(SendOtpRequestViewModel command)
        {
            var result = await _otpAppServiceHandler.SendOtp(command);
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
