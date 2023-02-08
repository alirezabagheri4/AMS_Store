using Domain.Aggregates.ProductAggregate.Models;

namespace Domain.Aggregates.ProductAggregate.Interfaces.IRepository
{
    public interface IProductCommentRepository : IRepository<ProductComment>
    {
        Task<ProductComment> GetById(long id);
        Task<IEnumerable<ProductComment>> GetAll();
        void Add(ProductComment customer);
        void Update(ProductComment customer);
        void Remove(ProductComment customer);
        void RemoveById(long id);
    }
}
