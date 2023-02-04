using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class ProductGroupCommand: Common.Command
    {
        public long Id { get; set; }

        public string GroupName { get; set; }

        public string Description { get; set; }
    }
}
