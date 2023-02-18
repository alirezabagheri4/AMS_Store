using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.ProductService.Interface
{
    public interface IProductQueryAppServiceHandler
    {
        Task<ProductCommentViewModel> GetById(long id);
        Task<IEnumerable<ProductGroupViewModel>> GetAll();
    }
}
