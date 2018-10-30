using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Model
{
    public abstract class Aggregate : IAggregate
    {
        private List<IEvent> _unpublishedEvents = new List<IEvent>();

        public Guid Id { get; protected set; }

        public IReadOnlyCollection<IEvent> UnpublishedEvents => _unpublishedEvents.AsReadOnly();

        protected void AddEvent(IEvent @event)
        {
            _unpublishedEvents.Add(@event);
        }
    }
}
