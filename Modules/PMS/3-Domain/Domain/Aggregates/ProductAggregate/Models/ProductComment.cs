using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.ProductAggregate.Interfaces;
using Domain.Framework;

namespace Domain.Aggregates.ProductAggregate.Models
{
    public class ProductComment : BaseEntity, IAggregateRoot
    {
        public long ProductId { get; set; }

        public long CustomerId { get; set; }

        public string CommentText { get; set; }

        public ProductComment(long productId, long customerId, string commentText)
        {
            this.CommentText = commentText;
            this.CustomerId = customerId;
            this.ProductId = productId;
        }
    }
}
