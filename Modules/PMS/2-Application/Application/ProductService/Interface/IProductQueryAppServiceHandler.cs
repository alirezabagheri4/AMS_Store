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
        Task<ProductViewModel> GetById(long id);
        Task<IEnumerable<ProductViewModel>> GetAll();
    }
}
