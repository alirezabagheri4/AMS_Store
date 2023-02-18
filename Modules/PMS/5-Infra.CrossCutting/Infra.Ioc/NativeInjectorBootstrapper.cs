using Application.ProductComment.Command;
using Application.ProductComment.Interface;
using Application.ProductComment.Query;
using Application.ProductGroup.Command;
using Application.ProductGroup.Interface;
using Application.ProductGroup.Query;
using Application.ProductService.Command;
using Application.ProductService.Interface;
using Application.ProductService.Query;
using Domain.Aggregates.Product.Commands.Command;
using Domain.Aggregates.Product.Commands.Handlers;
using Domain.Aggregates.Product.Event.EventHandler;
using Domain.Aggregates.Product.Event.EventModel;
using Domain.Aggregates.Product.Interfaces.IRepository;
using Domain.Aggregates.Product.Interfaces.IRepository.ICommand;
using Domain.Aggregates.Product.Interfaces.IRepository.IQuery;
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
using Infra.Data.Persistence.Repository.Command;
using Infra.Data.Persistence.Repository.Query;
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

            // Application - Command
            services.AddScoped<IProductCommandAppServiceHandler, ProductCommandAppServiceHandler>();
            services.AddScoped<IProductGroupCommandAppServiceHandler, ProductGroupCommandAppServiceHandler>();
            services.AddScoped<IProductCommentCommandAppServiceHandler, ProductCommentCommandAppServiceHandler>();

            // Application - Query
            services.AddScoped<IProductQueryAppServiceHandler, ProductQueryAppServiceHandler>();
            services.AddScoped<IProductGroupQueryAppServiceHandler, ProductGroupQueryAppServiceHandler>();
            services.AddScoped<IProductCommentQueryAppServiceHandler, ProductCommentQueryAppServiceHandler>();

            // Domain - Events - product
            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            // Domain - Events - product Group
            //services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            //services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            //services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            // Domain - Events - product Comment
            //services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            //services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            //services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

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

            // Infra - Data - Commands
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductGroupCommandRepository, ProductGroupCommandRepository>();
            services.AddScoped<IProductCommentCommandRepository, ProductCommentCommandRepository>();
            services.AddScoped<IProductDescriptionCommandRepository, ProductDescriptionCommandRepository>();

            // Infra - Data - Queries
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<IProductGroupQueryRepository, ProductGroupQueryRepository>();
            services.AddScoped<IProductCommentQueryRepository, ProductCommentQueryRepository>();
            services.AddScoped<IProductDescriptionQueryRepository, ProductDescriptionQueryRepository>();

            services.AddScoped<ProductManagementDbContext>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSqlContext>();
        }
    }
}