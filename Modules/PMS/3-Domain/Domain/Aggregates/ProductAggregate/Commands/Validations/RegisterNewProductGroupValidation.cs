﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Commands.Command;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations;

internal class RegisterNewProductGroupValidation : ProductGroupValidation<ProductGroupCommand>
{
    public RegisterNewProductGroupValidation()
    {
        ValidateGroupName();
        ValidateDescription();
        ValidateId();
    }
}