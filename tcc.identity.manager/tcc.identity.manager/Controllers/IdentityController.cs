using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using tcc.identity.manager.application.Commands;
using tcc.identity.manager.domain.Exception;

namespace tcc.identity.manager.Controllers
{
    public class IdentityController : BaseController
    {
        private readonly IMediator _mediator;

        public IdentityController(INotificationHandler<ExceptionNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> EfetiveOrder([FromBody] DoLoginCommand doLoginCommand)
        {
            var requestReturn =  await _mediator.Send(doLoginCommand);

            return Response(201, requestReturn);
        }
    }
}
