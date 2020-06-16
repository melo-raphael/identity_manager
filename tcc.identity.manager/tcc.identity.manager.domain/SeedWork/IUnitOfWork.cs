using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tcc.identity.manager.domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
