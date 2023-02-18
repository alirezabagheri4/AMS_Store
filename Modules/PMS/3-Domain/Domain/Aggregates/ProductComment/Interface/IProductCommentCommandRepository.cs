using Domain.Aggregates.Product.Interfaces.IRepository;

namespace Domain.Aggregates.ProductComment.Interface
{
    public interface IProductCommentCommandRepository : IRepository<Models.ProductComment>
    {
        void Add(Models.ProductComment customer);
        void Update(Models.ProductComment customer);
        void Remove(Models.ProductComment customer);
        void RemoveById(long id);
    }
}
