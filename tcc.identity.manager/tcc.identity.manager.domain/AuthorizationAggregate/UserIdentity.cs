using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tcc.identity.manager.domain.SeedWork;

namespace tcc.identity.manager.domain.AuthorizationAggregate
{
    public class UserIdentity : Entity
    {
        public string _email { get; private set; }
        private string _password;
        public string Password => _password;
        private string _name;

        public UserIdentity(string email, string password, string nome)
        {
            _email = email;
            _password = password;
            _name = nome;
        }

        protected UserIdentity(){ }



        public string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, this._email.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, this.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
