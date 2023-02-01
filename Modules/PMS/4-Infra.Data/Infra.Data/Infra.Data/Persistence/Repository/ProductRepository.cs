using Domain.Aggregates.ProductAggregate.Interfaces.IRepository;
using Domain.Aggregates.ProductAggregate.Models;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Infra.Data.Persistence.Repository
{
    internal class ProductRepository : IProductRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<Product> DbSet;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public ProductRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Product>();
        }

        public async Task<Product> GetById(long id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id) ?? new Product();
        }

        public void Add(Product customer)
        {
            DbSet.Add(customer);
        }

        public void Update(Product customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(Product customer)
        {
            DbSet.Remove(customer);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public void RemoveById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
