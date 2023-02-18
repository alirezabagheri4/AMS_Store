namespace Domain.Aggregates.Product.Interfaces.IRepository.ICommand
{
    internal interface IProductCommentCommandRepository : IRepository<ProductComment.Models.ProductComment>
    {
        void Add(ProductComment.Models.ProductComment customer);
        void Update(ProductComment.Models.ProductComment customer);
        void Remove(ProductComment.Models.ProductComment customer);
        void RemoveById(long id);
    }
}
