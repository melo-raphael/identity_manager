using System;
using System.Collections.Generic;
using System.Text;
using tcc.identity.manager.domain.Events;

namespace tcc.identity.manager.domain.Exception
{
    public class ExceptionNotification : Event
    {
        public string Code { get; private set; }
        public string Message { get; private set; }
        public string ParamName { get; private set; }

        public ExceptionNotification(string code, string message, string paramName = null)
        {
            Code = code;
            Message = message;
            ParamName = paramName;
        }
    }
}
