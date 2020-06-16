using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using tcc.identity.manager.domain.AuthorizationAggregate;
using tcc.identity.manager.domain.Exception;
using tcc.identity.manager.domain.SeedWork;
using tcc.identity.manager.infra.Context;
using tcc.identity.manager.infra.Repository;
using tcc.identity.manager.infra.Uow;

namespace tcc.identity.crosscutting.ioc
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterData(services);
            RegisterMediatR(services);

        }

        private static void RegisterData(IServiceCollection services)
        {
            services.AddScoped<IAuthorizationRepositoy, AuthorizationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApplicationDbContext>();
        }

        private static void RegisterMediatR(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<ExceptionNotification>, ExceptionNotificationHandler>();
        }
    }
}
