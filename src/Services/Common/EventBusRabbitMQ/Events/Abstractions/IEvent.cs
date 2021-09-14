using System;

namespace EventBusRabbitMQ.Events.Abstractions
{
    public abstract class IEvent
    {
        protected IEvent()
        {
            CreationDate = DateTime.UtcNow;
            RequestId = Guid.NewGuid();
        }

        protected IEvent(Guid requestId, DateTime creationDate)
        {
            RequestId = requestId;
            CreationDate = creationDate;
        }

        public Guid RequestId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}