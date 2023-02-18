using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.ProductGroup.Interface
{
    public interface IProductGroupQueryAppServiceHandler
    {
        Task<ProductCommentViewModel> GetById(long id);
        Task<IEnumerable<ProductGroupViewModel>> GetAll();
    }
}
