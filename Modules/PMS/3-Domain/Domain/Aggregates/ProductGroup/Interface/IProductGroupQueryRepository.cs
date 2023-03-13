using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.Product.Interfaces.IRepository;

namespace Domain.Aggregates.ProductGroup.Interface
{
    public interface IProductGroupQueryRepository : IRepository<Models.ProductGroup>
    {
        Task<Models.ProductGroup> GetById(long id);
        Task<IEnumerable<Models.ProductGroup>> GetAll();
        Task<IEnumerable<Models.ProductGroup>> GetListSubProductGroupById(long id);
    }
}
