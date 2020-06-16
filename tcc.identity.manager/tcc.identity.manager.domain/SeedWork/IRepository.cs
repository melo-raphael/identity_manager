using System;
using System.Collections.Generic;
using System.Text;

namespace tcc.identity.manager.domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        void Add(TEntity obj);
    }
}
