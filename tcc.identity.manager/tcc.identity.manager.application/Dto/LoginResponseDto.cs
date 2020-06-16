using System;
using System.Collections.Generic;
using System.Text;

namespace tcc.identity.manager.application.Dto
{
    public class LoginResponseDto
    {
        public LoginResponseDto(string jwt)
        {
            Jwt = jwt;
        }

        public string Jwt { get; set; }
    }
}
