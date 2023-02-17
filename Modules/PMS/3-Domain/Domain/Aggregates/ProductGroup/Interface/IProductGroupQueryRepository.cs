using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.Product.Interfaces.IRepository;

namespace Domain.Aggregates.ProductGroup.Interface
{
    public interface IProductGroupQueryRepository : IRepository<Product.Models.ProductGroup>
    {
        Task<Product.Models.ProductGroup> GetById(long id);
        Task<IEnumerable<Product.Models.ProductGroup>> GetAll();
    }
}
