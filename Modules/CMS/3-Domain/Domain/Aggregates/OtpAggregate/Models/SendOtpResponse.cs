using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.OtpAggregate.Models.@enum;

namespace Domain.Aggregates.OtpAggregate.Models
{
    public class SendOtpResponse
    {
        public string PhoneNumber { get; set; }
        public EOtpResponseCode OtpResponseCodeEnum { get; set; }
    }
}
