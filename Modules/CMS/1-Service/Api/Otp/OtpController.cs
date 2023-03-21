using Application.Interface;
using Application.ViewModel;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Otp
{
    [Route("CMS/Otp")]
    public class OtpController
    {
        private readonly IOtpAppServiceHandler _otpAppServiceHandler;

        public OtpController(IOtpAppServiceHandler otpAppServiceHandler)
        {
            _otpAppServiceHandler = otpAppServiceHandler;
        }

        [AllowAnonymous]
        [HttpPost("SendOtp")]
        public async Task<SendOtpResponseViewModel> SendOtp(SendOtpRequestViewModel  requestViewModel)
        {
            var result = await _otpAppServiceHandler?.SendOtp(requestViewModel);
            return result;
        }

        [AllowAnonymous]
        [HttpPost("VerifyOtp")]
        public async Task<VerifyOtpResponseViewModel> VerifyOtp(VerifyOtpRequestViewModel requestViewModel)
        {
            var result = await _otpAppServiceHandler?.VerifyOtp(requestViewModel);
            return result;
        }
    }
}
