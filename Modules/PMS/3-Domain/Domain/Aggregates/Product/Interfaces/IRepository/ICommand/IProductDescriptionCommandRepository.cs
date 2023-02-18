using Domain.Aggregates.Product.Models;

namespace Domain.Aggregates.Product.Interfaces.IRepository.ICommand
{
    public interface IProductDescriptionCommandRepository : IRepository<ProductDescription>
    {
        void Add(ProductDescription customer);
        void Update(ProductDescription customer);
        void Remove(ProductDescription customer);
        void RemoveById(long id);
    }
}
