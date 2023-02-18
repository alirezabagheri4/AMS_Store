using Domain.Aggregates.Product.Models;

namespace Domain.Aggregates.Product.Interfaces.IRepository.ICommand
{
    internal interface IProductGroupCommandRepository : IRepository<ProductGroup.Models.ProductGroup>
    {
        void Add(ProductGroup.Models.ProductGroup customer);
        void Update(ProductGroup.Models.ProductGroup customer);
        void Remove(ProductGroup.Models.ProductGroup customer);
        void RemoveById(long id);
    }
}
