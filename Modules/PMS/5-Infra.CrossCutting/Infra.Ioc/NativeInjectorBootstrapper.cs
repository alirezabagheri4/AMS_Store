using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.Product.Commands.Handlers;
using Domain.Aggregates.Product.Event.EventHandler;
using Domain.Aggregates.Product.Event.EventModel;
using Domain.Aggregates.Product.Interfaces.IRepository;
using Domain.Aggregates.ProductComment.Commands.Command;
using Domain.Aggregates.ProductComment.Commands.Handler;
using Domain.Aggregates.ProductComment.Interface;
using Domain.Aggregates.ProductGroup.Commands.Command;
using Domain.Aggregates.ProductGroup.Commands.Handler;
using Domain.Aggregates.ProductGroup.Interface;
using Domain.Common;
using FluentValidation.Results;
using Infra.Bus;
using Infra.Data.Persistence.Context;
using Infra.Data.Persistence.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            //services.AddScoped<ICustomerAppService, CustomerAppServiceHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, ValidationResult>, ProductCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewProductCommentCommand, ValidationResult>, ProductCommentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommentCommand, ValidationResult>, ProductCommentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommentCommand, ValidationResult>, ProductCommentCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewProductGroupCommand, ValidationResult>, ProductGroupCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductGroupCommand, ValidationResult>, ProductGroupCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductGroupCommand, ValidationResult>, ProductGroupCommandHandler>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductGroupCommandRepository, ProductGroupRepository>();
            services.AddScoped<IProductCommentQueryRepository, ProductCommentRepository>();
            services.AddScoped<IProductDescriptionRepository, IProductDescriptionRepository>();

            services.AddScoped<ProductManagementDbContext>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSqlContext>();
        }
    }
}