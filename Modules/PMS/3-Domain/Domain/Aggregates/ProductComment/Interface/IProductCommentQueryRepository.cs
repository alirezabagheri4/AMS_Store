using Domain.Aggregates.Product.Interfaces.IRepository;

namespace Domain.Aggregates.ProductComment.Interface
{
    public interface IProductCommentQueryRepository : IRepository<Models.ProductComment>
    {
        Task<Models.ProductComment> GetById(long id);
        Task<IEnumerable<Models.ProductComment>> GetAll();
    }
}
