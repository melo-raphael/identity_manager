using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tcc.identity.manager.domain.AuthorizationAggregate
{
    public interface IAuthorizationRepositoy
    {
        Task<Authorization> GetUserByEmail(string user);
    }
}
