using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.OtpAggregate.Models;

namespace Domain.Aggregates.OtpAggregate.Interface
{
    public interface IExternalOtpService
    {
        Task<SendOtpResponse> SendOtp(string receptor, string otp);
        string GenerateOtp(string phoneNumber);

        Task<bool> VerifyOtp(string phoneNumber, string input);
    }
}
