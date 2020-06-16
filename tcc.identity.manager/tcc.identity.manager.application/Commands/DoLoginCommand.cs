using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using tcc.identity.manager.application.Dto;

namespace tcc.identity.manager.application.Commands
{
    public class DoLoginCommand : Command, IRequest<LoginResponseDto>
    {
        public string User { get; set; }
        public string Password { get; set; }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
