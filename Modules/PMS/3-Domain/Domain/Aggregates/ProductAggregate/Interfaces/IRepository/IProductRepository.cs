using Domain.Aggregates.ProductAggregate.Models;

namespace Domain.Aggregates.ProductAggregate.Interfaces.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetById(long id);
        Task<IEnumerable<Product>> GetAll();
        void Add(Product customer);
        void Update(Product customer);
        void Remove(Product customer);
        void RemoveById(long id);
    }
}
