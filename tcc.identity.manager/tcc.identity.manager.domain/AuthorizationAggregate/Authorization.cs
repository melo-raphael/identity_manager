using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tcc.identity.manager.domain.SeedWork;

namespace tcc.identity.manager.domain.AuthorizationAggregate
{
    public class Authorization : Entity, IAggregateRoot
    {
        private string _profile;
        public UserIdentity UserIdentity { get; private set; }

        public Authorization(string profile)
        {
            _profile = profile;
        }

        public string GenereteTokenJwt()
        {
            return UserIdentity.GenerateToken();
        }

    }
}
