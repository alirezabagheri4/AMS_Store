using Domain.Aggregates.Product.Interfaces.IRepository;

namespace Domain.Aggregates.ProductGroup.Interface
{
    public interface IProductGroupCommandRepository : IRepository<Models.ProductGroup>
    {
        void Add(Models.ProductGroup customer);
        void Update(Models.ProductGroup customer);
        void Remove(Models.ProductGroup customer);
        void RemoveById(long id);
    }
}
