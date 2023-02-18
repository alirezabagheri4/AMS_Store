namespace Domain.Aggregates.Product.Interfaces.IRepository.IQuery
{
    internal interface IProductGroupQueryRepository : IRepository<ProductGroup.Models.ProductGroup>
    {
        Task<ProductGroup.Models.ProductGroup> GetById(long id);
        Task<IEnumerable<ProductGroup.Models.ProductGroup>> GetAll();
    }
}
