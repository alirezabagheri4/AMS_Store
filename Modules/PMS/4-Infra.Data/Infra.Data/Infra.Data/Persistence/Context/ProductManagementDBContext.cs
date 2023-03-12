using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Domain.Aggregates.Product.Models;
using Domain.Aggregates.ProductComment.Models;
using Domain.Aggregates.ProductGroup.Models;
using Domain.Common;
using Domain.Framework;

namespace Infra.Data.Persistence.Context
{
    public class ProductManagementDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options,
            IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!Database.IsSqlServer()) return;
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                         e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.UseCollation("Persian_100_CI_AS");
            modelBuilder.HasDefaultSchema("PMS");
        }

        public async Task<bool> Commit()
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            //TODO
            //await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
