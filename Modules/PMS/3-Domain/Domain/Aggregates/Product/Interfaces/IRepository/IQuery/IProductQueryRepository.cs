namespace Domain.Aggregates.Product.Interfaces.IRepository.IQuery
{
    public interface IProductQueryRepository : IRepository<Models.Product>
    {
        Task<Models.Product> GetById(long id);
        Task<IEnumerable<Models.Product>> GetAll();
    }
}
