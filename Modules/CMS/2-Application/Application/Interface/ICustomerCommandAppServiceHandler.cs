using Application.ViewModel;
using FluentValidation.Results;

namespace Application.Interface
{
    public interface ICustomerCommandAppServiceHandler
    {
        Task<ValidationResult> Register(CustomerViewModel customerViewModel);

        Task<ValidationResult> Update(CustomerViewModel customerViewModel);

        Task<ValidationResult> Remove(long id);
    }
}
