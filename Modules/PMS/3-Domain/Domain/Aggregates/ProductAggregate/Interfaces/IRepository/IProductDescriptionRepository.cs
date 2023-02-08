﻿using Domain.Aggregates.ProductAggregate.Models;

namespace Domain.Aggregates.ProductAggregate.Interfaces.IRepository
{
    public interface IProductDescriptionRepository : IRepository<ProductDescription>
    {
        Task<ProductDescription> GetById(long id);
        Task<IEnumerable<ProductDescription>> GetAll();
        void Add(ProductDescription customer);
        void Update(ProductDescription customer);
        void Remove(ProductDescription customer);
        void RemoveById(long id);
    }
}
