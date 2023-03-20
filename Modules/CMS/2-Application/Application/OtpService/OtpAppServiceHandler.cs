using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.OtpAggregate.Interface;

namespace Application.OtpService
{
    internal class OtpAppServiceHandler : IOtpAppServiceHandler
    {
        private readonly IMapper _mapper;
        private readonly IExternalOtpService _externalOtpService;

        public OtpAppServiceHandler(IMapper mapper,
            IExternalOtpService externalOtpService)
        {
            _mapper = mapper;
            _externalOtpService = externalOtpService;
        }
        public async Task<SendOtpResponseViewModel> SendOtp(SendOtpRequestViewModel command)
        {
            string otp = _externalOtpService.GenerateOtp(command.PhoneNumber);
            return _mapper.Map<SendOtpResponseViewModel>
            (await _externalOtpService.SendOtp(command.PhoneNumber, otp));
        }

        public async Task<SendOtpResponseViewModel> VerifyOtp(SendOtpRequestViewModel command)
        {
            string otp = _externalOtpService.GenerateOtp(command.PhoneNumber);
            return _mapper.Map<SendOtpResponseViewModel>
            (await _externalOtpService.SendOtp(command.PhoneNumber, otp));
        }
    }
}
