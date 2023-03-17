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
        Task<IEnumerable<ProductViewModel>> GetAllProduct();
        Task<IEnumerable<ProductTitleViewModel>> GetAllProductTitle();
        Task<ProductTitleViewModel> GetProductTitleById(long id);
        Task<ProductViewModel> GetProductById(long id);
        Task<IEnumerable<ProductViewModel>> GetActiveProduct();
        Task<IEnumerable<ProductTitleViewModel>> GetActiveProductTitle();
        Task<IEnumerable<ProductViewModel>> GetProductByProductState();
        Task<IEnumerable<ProductTitleViewModel>> GetProductTitleByProductState();
    }
}
