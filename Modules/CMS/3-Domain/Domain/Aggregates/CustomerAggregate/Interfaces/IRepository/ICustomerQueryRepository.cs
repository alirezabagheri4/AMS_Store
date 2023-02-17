using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.CustomerAggregate.Models;

namespace Domain.Aggregates.CustomerAggregate.Interfaces.IRepository
{
    public interface ICustomerQueryRepository /*: IRepository<Customer>*/
    {
        Task<Customer> GetByNationalCode(string nationalCode);
        Task<Customer> GetById(long id);
        Task<IEnumerable<Customer>> GetAll();
    }
}
