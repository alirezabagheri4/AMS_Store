namespace Domain.Aggregates.Product.Interfaces.IRepository.ICommand
{
    public interface IProductCommandRepository : IRepository<Models.Product>
    {
        void Add(Models.Product customer);
        void Update(Models.Product customer);
        void Remove(Models.Product customer);
        void RemoveById(long id);
    }
}
