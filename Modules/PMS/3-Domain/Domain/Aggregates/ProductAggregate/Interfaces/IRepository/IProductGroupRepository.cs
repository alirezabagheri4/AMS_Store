using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Models;

namespace Domain.Aggregates.ProductAggregate.Interfaces.IRepository
{
    public interface IProductGroupRepository : IRepository<ProductGroup>
    {
        Task<ProductGroup> GetById(long id);
        Task<IEnumerable<ProductGroup>> GetAll();
        void Add(ProductGroup customer);
        void Update(ProductGroup customer);
        void Remove(ProductGroup customer);
        void RemoveById(long id);
    }
}
