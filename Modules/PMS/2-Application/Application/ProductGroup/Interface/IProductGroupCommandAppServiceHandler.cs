using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;
using FluentValidation.Results;

namespace Application.ProductGroup.Interface
{
    public interface IProductGroupCommandAppServiceHandler
    {
        Task<ValidationResult> Remove(long id);
        Task<ValidationResult> Update(ProductGroupViewModel productGroupViewModel);
        Task<ValidationResult> Register(ProductGroupViewModel productGroupViewModel);
    }
}
