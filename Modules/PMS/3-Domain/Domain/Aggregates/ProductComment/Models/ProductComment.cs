using Domain.Aggregates.Product.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.ProductComment.Models
{
    public class ProductComment : BaseEntity, IAggregateRoot
    {
        public long ProductId { get; set; }

        public long CustomerId { get; set; }

        public string CommentText { get; set; }

        public ProductComment()
        {

        }

        public ProductComment(long productId, long customerId, string commentText)
        {
            this.CommentText = commentText;
            this.CustomerId = customerId;
            this.ProductId = productId;
        }
    }
}
