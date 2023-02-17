using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class AddressViewModel
    {
        [Key]
        public long Id { get; private set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string? City { get; private set; }

        [MinLength(2)]
        [MaxLength(200)]
        public string? DetailAddress { get; private set; }
    }
}
