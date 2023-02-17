namespace Domain.Aggregates.Product.Interfaces.IRepository
{
    public interface IProductRepository : IRepository<Models.Product>
    {
        Task<Models.Product> GetById(long id);
        Task<IEnumerable<Models.Product>> GetAll();
        void Add(Models.Product customer);
        void Update(Models.Product customer);
        void Remove(Models.Product customer);
        void RemoveById(long id);
    }
}
