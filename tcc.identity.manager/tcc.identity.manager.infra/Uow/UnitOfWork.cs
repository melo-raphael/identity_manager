using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tcc.identity.manager.domain.SeedWork;
using tcc.identity.manager.infra.Context;

namespace tcc.identity.manager.infra.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Commit()
        {
            return await _applicationDbContext.SaveEntitiesAsync();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
