using Domain.Aggregates.Product.Models;

namespace Domain.Aggregates.Product.Interfaces.IRepository
{
    public interface IProductDescriptionRepository : IRepository<ProductDescription>
    {
        Task<ProductDescription> GetById(long id);
        Task<IEnumerable<ProductDescription>> GetAll();
        void Add(ProductDescription customer);
        void Update(ProductDescription customer);
        void Remove(ProductDescription customer);
        void RemoveById(long id);
    }
}
