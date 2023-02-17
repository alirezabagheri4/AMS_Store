namespace Domain.Aggregates.Product.Interfaces.IRepository
{
    public interface IProductCommentQueryRepository : IRepository<Models.ProductComment>
    {
        Task<Models.ProductComment> GetById(long id);
        Task<IEnumerable<Models.ProductComment>> GetAll();
    }
}
