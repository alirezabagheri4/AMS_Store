namespace Domain.Aggregates.Product.Interfaces.IRepository
{
    public interface IProductCommandQueryRepository : IRepository<Models.ProductComment>
    {
        void Add(Models.ProductComment customer);
        void Update(Models.ProductComment customer);
        void Remove(Models.ProductComment customer);
        void RemoveById(long id);
    }
}
