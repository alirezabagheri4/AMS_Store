using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Domain.Aggregates.CustomerAggregate.Models;

namespace Application.ViewModel
{
    public class CustomerViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The FirstName is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName { get;  set; }

        [Required(ErrorMessage = "The LastName is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string LastName { get;  set; }

        [Required(ErrorMessage = "The PhoneNumber is Required")]
        public string PhoneNumber { get;  set; }

        [Required(ErrorMessage = "The NationalCode is Required")]
        public string NationalCode { get;  set; }

        public AddressViewModel AddressviewModel { get; set; }
    }
}
