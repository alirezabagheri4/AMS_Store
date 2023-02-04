﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Commands.Command;

namespace Domain.Aggregates.ProductAggregate.Commands.Validations
{
    public class UpdateProductGroupValidation:ProductGroupValidation<ProductGroupCommand>
    {
        public UpdateProductGroupValidation()
        {
            ValidateGroupName();
            ValidateDescription();
            ValidateId();
        }
    }
}
