﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Commands.Validations;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class RemoveProductCommand:ProductCommand
    {
        public RemoveProductCommand(long productId)
        {
            this.Id = Id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
