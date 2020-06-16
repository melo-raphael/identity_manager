using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tcc.identity.manager.domain.AuthorizationAggregate;
using tcc.identity.manager.infra.Context;

namespace tcc.identity.manager.infra.Repository
{
    public class AuthorizationRepository : Repository<Authorization>, IAuthorizationRepositoy
    {
        public AuthorizationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<Authorization> GetUserByEmail(string user)
        {
           return await _dbSet.Include(x => x.UserIdentity).FirstOrDefaultAsync(Y => Y.UserIdentity._email == user);
        }
    }
}
