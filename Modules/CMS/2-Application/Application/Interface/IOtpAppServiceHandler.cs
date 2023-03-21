using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.Interface
{
    public interface IOtpAppServiceHandler
    {
        Task<SendOtpResponseViewModel> SendOtp(SendOtpRequestViewModel command);
        Task<VerifyOtpResponseViewModel> VerifyOtp(VerifyOtpRequestViewModel command);
    }
}
