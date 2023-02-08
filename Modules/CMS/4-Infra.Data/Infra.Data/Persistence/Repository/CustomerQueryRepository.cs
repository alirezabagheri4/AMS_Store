using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.CustomerAggregate.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository
{
    public class CustomerReadRepository : ICustomerRepository
    {
        protected readonly CustomerDbContext DbContext;
        protected readonly DbSet<Customer> DbSet;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public CustomerReadRepository(CustomerDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Customer>();
        }


    }
}
