using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tcc.identity.manager.application.Commands;
using tcc.identity.manager.application.Dto;
using tcc.identity.manager.domain.AuthorizationAggregate;
using tcc.identity.manager.domain.Exception;
using tcc.identity.manager.domain.SeedWork;

namespace tcc.identity.manager.application.CommandHandlers
{
    public class DoLoginCommandHandler : CommandHandler, IRequestHandler<DoLoginCommand, LoginResponseDto>
    {
        private readonly IAuthorizationRepositoy _authorizationRepository;
        private readonly PasswordHasher<Authorization> passwordHasher = new PasswordHasher<Authorization>();

        public DoLoginCommandHandler(INotificationHandler<ExceptionNotification> notifications, IMediator bus, IAuthorizationRepositoy authorizationRepositoy, IUnitOfWork uow) : base(notifications, bus, uow)
        {
            _authorizationRepository = authorizationRepositoy;
        }

        public async Task<LoginResponseDto> Handle(DoLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _authorizationRepository.GetUserByEmail(request.User);

            if (user != null)
            {
                PasswordVerificationResult verify = this.passwordHasher.VerifyHashedPassword(user, user.UserIdentity.Password, request.Password);

                if (verify == PasswordVerificationResult.Success)
                {
                    var token = user.GenereteTokenJwt();
                    return new LoginResponseDto(token);
                }

                else
                {
                    await _bus.Publish(new ExceptionNotification("003", "User or password invalid"));
                    return null;
                }
            }

            else
            {
                await _bus.Publish(new ExceptionNotification("004", "User or password invalid4"));
                return null;

            }


        }
    }
}