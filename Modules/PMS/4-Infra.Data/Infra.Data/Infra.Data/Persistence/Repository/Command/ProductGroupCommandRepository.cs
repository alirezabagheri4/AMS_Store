﻿using Domain.Aggregates.ProductGroup.Interface;
using Domain.Aggregates.ProductGroup.Models;
using Domain.Common;
using Infra.Data.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistence.Repository.Command
{
    public class ProductGroupCommandRepository : IProductGroupCommandRepository
    {
        protected readonly ProductManagementDbContext DbContext;
        protected readonly DbSet<ProductGroup> DbSet;

        public IUnitOfWork UnitOfWork => DbContext;

        public ProductGroupCommandRepository(ProductManagementDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<ProductGroup>();
        }

        public void Add(ProductGroup customer)
        {
            DbSet.Add(customer);
        }

        public void Update(ProductGroup customer)
        {
            DbSet.Update(customer);
        }

        public void Remove(ProductGroup customer)
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
