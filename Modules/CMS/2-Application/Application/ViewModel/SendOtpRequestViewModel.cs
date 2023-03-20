using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel
{
    public class SendOtpRequestViewModel
    {
        [MinLength(10, ErrorMessage = "MinLength PhoneNumber=10")]
        [MaxLength(13, ErrorMessage = "MaxLength PhoneNumber=13")]
        [Required(ErrorMessage = "The PhoneNumber is Required")]
        public string PhoneNumber { get; set; }
    }
}
