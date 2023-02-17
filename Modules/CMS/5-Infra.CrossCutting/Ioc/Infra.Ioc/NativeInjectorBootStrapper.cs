using Application.CustomerService.Command;
using Application.Interface;
using Domain.Aggregates.CustomerAggregate.Commands.Command;
using Domain.Aggregates.CustomerAggregate.Commands.Handlers;
using Domain.Aggregates.CustomerAggregate.Interfaces.IRepository;
using Domain.Common;
using Domain.Events.EventModel;
using Domain.Events.Handler;
using FluentValidation.Results;
using Infra.Bus;
using Infra.Data.Persistence.Context;
using Infra.Data.Persistence.Context.DapperContext;
using Infra.Data.Persistence.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppServiceHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<CustomerDbContext>();

            services.AddSingleton<CustomerDapperContext>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSqlContext>();
        }
    }
}