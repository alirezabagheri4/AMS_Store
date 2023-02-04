﻿namespace Domain.Aggregates.ProductAggregate.Commands.Command
{
    public class ProductCommentCommand: Common.Command
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public long CustomerId { get; set; }

        public string CommentText { get; set; }
    }
}
