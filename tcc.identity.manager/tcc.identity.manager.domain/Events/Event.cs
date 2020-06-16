using MediatR;
using System;

namespace tcc.identity.manager.domain.Events
{
    public abstract class Event : INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
