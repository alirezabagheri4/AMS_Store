using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OtpAggregate.Interface
{
    public interface IExternalOtpService
    {
        void SendOtp(string receptor, string otp);
    }
}
