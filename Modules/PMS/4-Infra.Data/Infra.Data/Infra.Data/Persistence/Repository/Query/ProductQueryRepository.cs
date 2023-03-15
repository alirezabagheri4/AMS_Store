﻿using Domain.Aggregates.Product.Interfaces.IRepository;
using Domain.Aggregates.Product.Interfaces.IRepository.ICommand;
using Domain.Aggregates.Product.Interfaces.IRepository.IQuery;
using Domain.Aggregates.Product.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository.Query
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<Product> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;

        public ProductQueryRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Product>();
        }

        public async Task<Product> GetById(long id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id) ?? new Product();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
