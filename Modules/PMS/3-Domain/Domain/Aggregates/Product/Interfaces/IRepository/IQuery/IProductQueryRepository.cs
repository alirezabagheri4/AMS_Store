using Domain.Aggregates.Product.ValueObjects;

namespace Domain.Aggregates.Product.Interfaces.IRepository.IQuery
{
    public interface IProductQueryRepository : IRepository<Models.Product>
    {
        Task<ProductDto> GetById(long id);
        Task<Models.Product> GetProductById(long id);
        Task<Models.Product> GetProductTitleById(long id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<IEnumerable<Models.Product>> GetAllProductTitle();
        Task<IEnumerable<ProductDto>> GetActiveProduct();
        Task<IEnumerable<Models.Product>> GetActiveProductTitle();
        Task<IEnumerable<ProductDto>> GetProductByProductState();
        Task<IEnumerable<Models.Product>> GetProductTitleByProductState();
    }
}
