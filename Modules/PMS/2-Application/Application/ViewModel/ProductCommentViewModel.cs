using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ProductCommentViewModel
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public long CustomerId { get; set; }

        public string CommentText { get; set; }
    }
}
