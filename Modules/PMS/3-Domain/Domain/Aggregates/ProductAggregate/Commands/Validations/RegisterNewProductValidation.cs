using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Commands.Command;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations
{
    public class RegisterNewProductValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductValidation()
        {
            ValidateProductName();
            ValidateProductState();
            ValidatePrice();
            ValidateProductDescriptionText();
            ValidateProductDescription_ProductId();
            ValidateId();
            ValidateProductGroupId();
        }
    }
}