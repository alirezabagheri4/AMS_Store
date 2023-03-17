using Dapper;
using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Interfaces.IRepository.IQuery;
using Domain.Aggregates.Product.Models;
using Domain.Aggregates.Product.ValueObjects;
using Domain.Common;
using Infra.Data.Persistence.Context.DapperDbContext;

namespace Infra.Data.Persistence.Repository.Query
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        protected readonly ProductDapperContext DbContext;

        public ProductQueryRepository(ProductDapperContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<ProductDto> GetById(long id)
        {
            const string query = @"SELECT TOP (1000) p.[Id]
                             ,[Name]
                             ,[ProductState]
                             ,[Price]
                             ,[ProductDescriptionId]
                             ,[ProductGroupId]
                             ,p.[SubmitDate] 
                             ,pd.ProductDescriptionText
                    FROM [PMS-DB].[PMS].[Product] p
                    inner join  [PMS-DB].[PMS].ProductDescription pd 
                    on p.ProductDescriptionId=pd.Id
                    where p.[Id]=@Id";
            using var connection = DbContext.CreateConnection();
            var company = await connection.QuerySingleOrDefaultAsync<ProductDto>(query, new { id });
            return company;
        }

        public async Task<Product> GetProductTitleById(long id)
        {
            const string query = @"SELECT TOP (1000) p.[Id]
                             ,[Name]
                             ,[ProductState]
                             ,[Price]
                             ,[ProductDescriptionId]
                             ,[ProductGroupId]
                             ,p.[SubmitDate] 
                    FROM [PMS-DB].[PMS].[Product] p
                    where p.[Id]=@Id";
            using var connection = DbContext.CreateConnection();
            var company = await connection.QuerySingleOrDefaultAsync<Product>(query, new { id });
            return company;
        }

        public async Task<Product> GetProductById(long id)
        {
            const string query = @"SELECT TOP (1000) p.[Id]
                             ,[Name]
                             ,[ProductState]
                             ,[Price]
                             ,[ProductDescriptionId]
                             ,[ProductGroupId]
                             ,p.[SubmitDate] 
                    FROM [PMS-DB].[PMS].[Product] p
                    where p.[Id]=@Id";
            using var connection = DbContext.CreateConnection();
            var company = await connection.QuerySingleOrDefaultAsync<Product>(query, new { id });
            return company;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            const string query = @"SELECT TOP (1000)
                                p.[Id]
                                ,[Name]
                                ,[ProductState]
                                ,[Price]
                                ,p.[SubmitDate]
                                ,p.ProductGroupId
	                            ,pd.ProductDescriptionText
                                 FROM [PMS-DB].[PMS].[Product] p
                                 inner join  [PMS-DB].[PMS].ProductDescription pd
                                 on p.ProductDescriptionId = pd.Id";
            using var connection = DbContext.CreateConnection();
            var companies = await connection.QueryAsync<ProductDto>(query);
            return companies.AsEnumerable();
        }

        public async Task<IEnumerable<Product>> GetAllProductTitle()
        {
            const string query = @"SELECT TOP (1000)
                                 [Id]
                                ,[Name]
                                ,[ProductState]
                                ,[Price]
                                 FROM [PMS-DB].[PMS].[Product]";
            using var connection = DbContext.CreateConnection();
            var companies = await connection.QueryAsync<Product>(query);
            return companies.AsEnumerable();
        }

        public async Task<IEnumerable<ProductDto>> GetActiveProduct()
        {
            const string query = @"SELECT TOP (1000)
                                p.[Id]
                                ,[Name]
                                ,[ProductState]
                                ,[Price]
                                ,p.[SubmitDate]
                                ,p.ProductGroupId
	                            ,pd.ProductDescriptionText
                                 FROM [PMS-DB].[PMS].[Product] p
                                 inner join  [PMS-DB].[PMS].ProductDescription pd
                                 on p.ProductDescriptionId = pd.Id
                                 where ProductState=1";
            using var connection = DbContext.CreateConnection();
            var companies = await connection.QueryAsync<ProductDto>(query);
            return companies.AsEnumerable();
        }

        public async Task<IEnumerable<Product>> GetActiveProductTitle()
        {
            const string query = @"SELECT TOP (1000)
                                 [Id]
                                ,[Name]
                                ,[ProductState]
                                ,[Price]
                                 FROM [PMS-DB].[PMS].[Product]
								 where ProductState=1";
            using var connection = DbContext.CreateConnection();
            var companies = await connection.QueryAsync<Product>(query);
            return companies.AsEnumerable();
        }

        public Task<IEnumerable<ProductDto>> GetProductByProductState(eProductState productState)
        {
            const string query = @"SELECT TOP (1000) p.[Id]
                             ,[Name]
                             ,[ProductState]
                             ,[Price]
                             ,[ProductDescriptionId]
                             ,[ProductGroupId]
                             ,p.[SubmitDate] 
                    FROM [PMS-DB].[PMS].[Product] p
                    where p.[ProductState]=@stateCode";
            using var connection = DbContext.CreateConnection();
            var company = await connection.QuerySingleOrDefaultAsync<Product>(query, new { id });
            return company;
        }

        public Task<IEnumerable<Product>> GetProductTitleByProductState()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public IUnitOfWork UnitOfWork { get; }
    }
}
