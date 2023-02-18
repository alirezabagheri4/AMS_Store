using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;
using FluentValidation.Results;

namespace Application.ProductService.Interface
{
    public interface IProductCommandAppServiceHandler
    {
        Task<ValidationResult> Remove(long id);
        Task<ValidationResult> Update(ProductViewModel productViewModel);
        Task<ValidationResult> Register(ProductViewModel productViewModel);
    }
}
