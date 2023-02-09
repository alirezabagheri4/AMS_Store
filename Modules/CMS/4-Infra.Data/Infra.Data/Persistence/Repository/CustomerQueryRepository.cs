using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Aggregates.CustomerAggregate.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Infra.Data.Persistence.Context.DapperContext;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository
{
    //TODO https://ubiq.co/database-blog/how-to-speed-up-sql-queries/
    //TODO Bad Performance
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        protected readonly CustomerDapperContext DbContext;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public CustomerQueryRepository(CustomerDapperContext dbContext)
        {
            DbContext = dbContext;
        }


        public void Dispose()
        {
            DbContext.Dispose();
        }

        public Task<Customer> GetByNationalCode(string nationalCode)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetById(long id)
        {
            var query = "SELECT * FROM cms.Customer WHERE Id = @Id";
            using (var connection = DbContext.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Customer>(query, new { id });
                return company;
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            const string query = "SELECT * FROM cms.Customer ";
            using var connection = DbContext.CreateConnection();
            var companies = await connection.QueryAsync<Customer>(query);
            return companies.AsEnumerable();
        }
    }
}
