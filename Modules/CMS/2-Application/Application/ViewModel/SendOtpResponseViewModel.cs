using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Enum;

namespace Application.ViewModel
{
    public class SendOtpResponseViewModel
    {
        public string PhoneNumber { get; set; }
        public  OtpResponseCodeEnum OtpResponseCodeEnum { get; set; }
    }
}
