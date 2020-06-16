using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tcc.identity.manager.domain.SeedWork;
using tcc.identity.manager.infra.Context;

namespace tcc.identity.manager.infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<TEntity> _dbSet;


        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _applicationDbContext.Add(obj);
        }

    }
}
