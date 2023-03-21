using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Enum;

namespace Application.ViewModel
{
    public class VerifyOtpResponseViewModel
    {
        public string PhoneNumber { get; set; }

         public VerifyOtpResponseCodeEnum OtpResponseCodeEnum { get; set; } 
    }
}
