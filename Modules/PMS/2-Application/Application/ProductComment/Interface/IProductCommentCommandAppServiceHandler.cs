using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;
using FluentValidation.Results;

namespace Application.ProductComment.Interface
{
    public interface IProductCommentCommandAppServiceHandler
    {
        Task<ValidationResult> Register(ProductCommentViewModel productCommentViewModel);
        Task<ValidationResult> Update(ProductCommentViewModel productCommentViewModel);
        Task<ValidationResult> Remove(long id);
    }
}
