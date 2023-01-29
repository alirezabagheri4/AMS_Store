using Application.ViewModel;
using FluentValidation.Results;

namespace Application.Interface
{
    public interface ICustomerAppService
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();

        Task<CustomerViewModel> GetById(long id);

        Task<ValidationResult> Register(CustomerViewModel customerViewModel);

        Task<ValidationResult> Update(CustomerViewModel customerViewModel);

        Task<ValidationResult> Remove(long id);
    }
}
