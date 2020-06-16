using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc.identity.manager.domain.Exception;

namespace tcc.identity.manager.Controllers
{
    [Route("IM/[controller]")]
    //[ServiceFilter(typeof(GlobalExceptionFilterAttribute))]
    public class BaseController : Controller
    {
        private readonly ExceptionNotificationHandler _notifications;

        protected IEnumerable<ExceptionNotification> Notifications => _notifications.GetNotifications();

        protected BaseController(INotificationHandler<ExceptionNotification> notifications)
        {
            _notifications = (ExceptionNotificationHandler)notifications;
        }

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(int statusCode, object result = null)
        {
            if (IsValidOperation())
            {
                return StatusCode(statusCode, new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications()
            });
        }
    }
}
