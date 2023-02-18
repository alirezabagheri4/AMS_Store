using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.ProductComment.Interface
{
    public interface IProductCommentQueryAppServiceHandler
    {
        Task<ProductCommentViewModel> GetById(long id);
        Task<IEnumerable<ProductCommentViewModel>> GetAll();
    }
}
