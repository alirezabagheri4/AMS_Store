using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using Application.ViewModel.Enum;
using AutoMapper;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.OtpAggregate.Interface;

namespace Application.OtpService
{
    public class OtpAppServiceHandler : IOtpAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IExternalOtpService _externalOtpService;

        public OtpAppServiceHandler(IMapper mapper,
            IExternalOtpService externalOtpService)
        {
            _mapper = mapper;
            _externalOtpService = externalOtpService;
        }
        public async Task<SendOtpResponseViewModel> SendOtp(SendOtpRequestViewModel requestViewModel)
        {
            var otp = _externalOtpService.GenerateOtp(requestViewModel.PhoneNumber);
            return _mapper.Map<SendOtpResponseViewModel>
            (await _externalOtpService.SendOtp(requestViewModel.PhoneNumber, otp));
        }

        public async Task<VerifyOtpResponseViewModel> VerifyOtp(VerifyOtpRequestViewModel requestViewModel)
        {

            var result = await _externalOtpService
                .VerifyOtp(requestViewModel.PhoneNumber, requestViewModel.CodeEntered);
            return new VerifyOtpResponseViewModel()
            {
                OtpResponseCodeEnum = VerifyOtpResponseCodeEnum.Ok, PhoneNumber = requestViewModel.PhoneNumber
            };
        }
    }
}
