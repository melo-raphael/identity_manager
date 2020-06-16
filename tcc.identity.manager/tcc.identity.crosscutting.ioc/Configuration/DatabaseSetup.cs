using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using tcc.identity.manager.infra.Context;

namespace tcc.identity.crosscutting.ioc.Configuration
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
        }
    }
}
