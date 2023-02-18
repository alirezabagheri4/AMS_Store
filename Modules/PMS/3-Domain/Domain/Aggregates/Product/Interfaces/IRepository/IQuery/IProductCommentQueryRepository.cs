namespace Domain.Aggregates.Product.Interfaces.IRepository.IQuery
{
    internal interface IProductCommentQueryRepository : IRepository<Models.Product>
    {
        Task<Models.Product> GetById(long id);
        Task<IEnumerable<Models.Product>> GetAll();
    }
}
