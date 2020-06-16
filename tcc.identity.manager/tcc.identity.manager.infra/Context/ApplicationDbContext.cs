using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tcc.identity.manager.infra.Mapping;

namespace tcc.identity.manager.infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
  

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Server=database-2.crrtyjh5anqo.sa-east-1.rds.amazonaws.com;Port=5432;Database=tcc_im;User Id=postgres;Password=polivel12;",
                        // => options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString"),
                        npgsqlOptionsAction: pgOptions =>
                        {
                            pgOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorizationMap());
            modelBuilder.ApplyConfiguration(new UserIdentityMap());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            return await base.SaveChangesAsync(cancellationToken) > 0;
        }
    }   
}
