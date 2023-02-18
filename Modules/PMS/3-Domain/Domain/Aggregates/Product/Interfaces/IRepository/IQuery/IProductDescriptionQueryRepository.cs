using Domain.Aggregates.Product.Models;

namespace Domain.Aggregates.Product.Interfaces.IRepository.IQuery
{
    public interface IProductDescriptionQueryRepository : IRepository<ProductDescription>
    {
        Task<ProductDescription> GetById(long id);
        Task<IEnumerable<ProductDescription>> GetAll();
    }
}
