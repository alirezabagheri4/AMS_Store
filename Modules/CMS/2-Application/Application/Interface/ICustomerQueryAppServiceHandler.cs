using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.Interface
{
    public interface ICustomerQueryAppServiceHandler
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();

        Task<CustomerViewModel> GetById(long id);
    }
}
