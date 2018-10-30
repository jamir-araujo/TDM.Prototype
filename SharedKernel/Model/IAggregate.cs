using System;
using System.Collections.Generic;

namespace SharedKernel.Model
{
    public interface IAggregate
    {
        Guid Id { get; }
        IReadOnlyCollection<IEvent> UnpublishedEvents { get; }
    }
}
