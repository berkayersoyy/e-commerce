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

        public Guid RequestId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}