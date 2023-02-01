using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.ProductAggregate
{
    public enum eProductState
    {
        Unknown = 0,
        Active=1,
        DeActive=2
    }
}
